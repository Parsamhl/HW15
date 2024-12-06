// See https://aka.ms/new-console-template for more information
using ConsoleTables;
using HW15;
using HW15.Contracts.Repositories;
using HW15.Contracts.Services;
using HW15.Data;
using HW15.Dto;
using HW15.Repositories;
using HW15.Services;
using System.ComponentModel.DataAnnotations;

AppDbContext appDbContext = new AppDbContext();
appDbContext.Database.EnsureCreated();
ICardService cardService = new CardService();
ITransactionService transactionService = new TransactionService();
IUserService userService = new UserService();
IVerificationCodeService verificationService = new VerificationService();


string cardNumber = "";
string password = "";
Console.WriteLine("welcome!");
Result validation;

do
{
    Console.Clear();

    Console.Write("Enter YourCard Number :");
    cardNumber = Console.ReadLine();

    Console.Write("Enter your password :");
    password = Console.ReadLine();

    validation = cardService.PasswordIsValid(cardNumber, password);

    Console.WriteLine(validation.Erorr);

    Console.ReadLine();
} while (!validation.IsSuccess);

while (true)
{
    Console.Clear();

    Console.WriteLine("1. Transfer Money");
    Console.WriteLine("2. Show balance");
    Console.WriteLine("3. Transaction history ");
    Console.WriteLine("4. Change yourCard Password");
    

    var option = Console.ReadKey();

    Console.Clear();

    switch (option.KeyChar)
    {
        case '1':
            TransferMoney(cardNumber);
            break;

        case '2':

            Console.WriteLine(cardService.GetCardBalance(cardNumber));
            Console.WriteLine("press Any key to continue ");
            Console.ReadKey();
            break;
        case '3':
            ShowListOfTransactions();
            Console.ReadLine();
            break;
        case '4':
            Console.Write("Enter your current password :");
            password = Console.ReadLine();
            Console.Write("Enter your New password :");
            string newPassword = Console.ReadLine();
            cardService.ChangePassword(cardNumber, password, newPassword);
            Console.WriteLine("press Any key to continue ");
            Console.ReadKey();
            break;
     
    }

}
void TransferMoney(string cardNumber)
{
    Console.Write("Enter Destination Card Number: ");
    string destinationCardNumber = Console.ReadLine();

    Console.Write("Enter Amount to Transfer: ");
    float amount = float.Parse(Console.ReadLine());

    

    var result = transactionService.TransferMoney(cardNumber, destinationCardNumber, amount);

    var verifyCode = verificationService.GenerateAndSaveCode();

    Console.WriteLine("verification code has been generated !");
    Console.WriteLine("press any key to Enter the Code ! ");
    Console.WriteLine("bare in mind : The code available for 5 minutes only!");

    Console.ReadKey();
    Console.Clear();

    Console.Write("Verification Code :");
    string code = Console.ReadLine();

    verificationService.ValidateCode(code);


    if (result.IsSuccess)
    {
        Console.WriteLine("Transfer successful!");
    }
    else
    {
        Console.WriteLine($"Error: {result.Erorr}");
    }

    Console.ReadKey();

}
void ShowListOfTransactions()
{
    var transactions = transactionService.GetTransactionLIst(cardNumber);

    ConsoleTable
        .From<TransactionDto>(transactions)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Minimal);

    Console.ReadKey();
}
