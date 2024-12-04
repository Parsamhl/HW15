using HW15.Contracts.Repositories;
using HW15.Contracts.Services;
using HW15.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class CardService : ICardService
    {

        private readonly ICardRepository _cardRepository;

        public CardService()
        {
            _cardRepository = new CardRepository();
        }

        public void ChangePassword(string cardNumbert, string password, string newPassword)
        {
            var card = _cardRepository.GetCardBy(cardNumbert);
            if (password == card.Password)
            {
                card.Password = newPassword;
                _cardRepository.ChangePassword(cardNumbert, password, newPassword);
            }
        }

        public string GetCardBalance(string cardNumber)
        {
            var card = _cardRepository.GetCardBy(cardNumber);
            if (card is null)
            {
                return "404";
            }
            else
            {
                return $"your card balance : {card.Balance}";
            }
        }

        public Result PasswordIsValid(string cardNumber, string password)
        {
            var count = _cardRepository.GetWrongPasswordCount(cardNumber);

            if (count > 3)
            {
                return new Result() { IsSuccess = false, Erorr = "wrong password attemp limit reached" };
            }
            var passwordValid = _cardRepository.PasswordIsValid(cardNumber, password);
            if (passwordValid == false)
            {
                return new Result() { IsSuccess = false, Erorr = "Password is incorrect!" };
            }
            else
            {
                _cardRepository.ClearWrongPasswordTry(cardNumber);
                return new Result() { IsSuccess = true, Erorr = "Welcome!" };
            }
        }
    }
}
