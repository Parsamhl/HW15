using HW15.Contracts.Services;
using HW15.Dto;
using HW15.Entities;
using HW15.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly CardRepository _cardRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly UserRepository _userRepository;
        private readonly VerificationService _verificationService;
        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
            _cardRepository = new CardRepository();
            _userRepository = new UserRepository();
            _verificationService = new VerificationService();
        }

        public List<TransactionDto> GetTransactionLIst(string cardNumber)
        => _transactionRepository.GetAll(cardNumber);


        public Result TransferMoney(string sCardNumber, string DCardNumber, float amount)
        {
          
            if (DCardNumber.Length != 16) 
            {
                return new Result() { IsSuccess = false, Erorr = "Destination Card is not valid" };
            }

         
            var sCardVail = _cardRepository.CardIsActive(sCardNumber);
            if (!sCardVail)
            {
                return new Result() { IsSuccess = false, Erorr = "Your Card is not Active !" };
            }

         
            var dCardValid = _cardRepository.CardIsActive(DCardNumber);
            if (!dCardValid)
            {
                return new Result() { IsSuccess = false, Erorr = "Destination Card is not Active !" };
            }
            else
            {
                
                var sCard = _cardRepository.GetCardBy(sCardNumber);
                var dCard = _cardRepository.GetCardBy(DCardNumber);

                
                var recipientName = _userRepository.GetRecipientName(DCardNumber);
                if (string.IsNullOrEmpty(recipientName))
                {
                    return new Result() { IsSuccess = false, Erorr = "Recipient not found for the provided card number." };
                }

               
                Console.WriteLine($"Recipient: {recipientName}");

                
                if (sCard.Balance < amount)
                {
                    return new Result() { IsSuccess = false, Erorr = "Insufficient funds!" };
                }

               
                if ((_transactionRepository.DailyWithdrawal(sCardNumber) + amount) > 5000)
                {
                    return new Result() { IsSuccess = false, Erorr = "Daily transfer limit reached!" };
                }

                
                if (amount > 1000)
                {
                    float fee = (amount * 0.5F) / 100F;
                    sCard.Balance -= fee; 
                }
                else if (amount < 1000)
                {
                    float fee = (amount * 1.5F) / 100F;
                    sCard.Balance -= fee; 
                }

                //var verifyCode = _verificationService.GenerateAndSaveCode();

                
                _cardRepository.Whitdraw(sCardNumber, amount);

                try
                {
                    _cardRepository.Deposite(DCardNumber, amount);
                }
                catch (Exception e)
                {
                    
                    _cardRepository.Deposite(sCardNumber, amount);
                    return new Result() { IsSuccess = false, Erorr = "Transaction failed. Please try again later." };
                }
                finally
                {
                   
                    var transaction = new Transaction()
                    {
                        SourceCardNumberId = sCard.ID,
                        DestinationCardNumberID = dCard.ID,
                        Amount = amount,
                        TransactionDate = DateTime.Now,
                        IsSuccessful = true
                    };

                    _transactionRepository.Add(transaction);
                }

                return new Result() { IsSuccess = true, Erorr = "Transfer successful" };
            }
        }

    }
}
