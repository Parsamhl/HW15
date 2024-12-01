using HW15.Contracts.Services;
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

        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
            _cardRepository = new CardRepository();
        }

       

        public Result TransferMoney(string sCardNumber, string DCardNumber, float amount)
        {

            if (DCardNumber.Length > 16 || DCardNumber.Length < 16)
            {
                return new Result() { IsSuccess = false, Erorr = "Destination Card is not valid" };
            }
            var sCardVail = _cardRepository.CardIsActive(sCardNumber);
            if (sCardVail == false)
            {
                return new Result() { IsSuccess = false, Erorr = "Your Card is not Active !" };
            }
            var dCardValid = _cardRepository.CardIsActive(DCardNumber);
            if (dCardValid == false)
            {
                return new Result() { IsSuccess = false, Erorr = "Destination Card is not Active !" };
            }
            else
            {
                var sCard = _cardRepository.GetCardBy(sCardNumber);
                var dCard = _cardRepository.GetCardBy(DCardNumber);
                if (sCard.Balance < amount)
                {
                    return new Result() { IsSuccess = false, Erorr = "Adame mojodi kafi :)" };
                }
                if ((_transactionRepository.DailyWithdrawal(sCardNumber) + amount) > 5000)
                {
                    return new Result() { IsSuccess = false, Erorr = "Daily transfer limit reached !" };
                }
                if(amount > 1000)
                {
                    
                }
                if( amount < 1000)
                {

                }

                _cardRepository.Whitdraw(sCardNumber, amount);

                var transaction = new Transaction()
                {
                    SourceCard = sCard,
                    DestinationCard = dCard,
                    Amount = amount,
                    TransactionDate = DateTime.Now,
                    IsSuccessful = true

                };

                
                _transactionRepository.Add(transaction);

                _cardRepository.Deposite(DCardNumber, amount);
                return new Result() { IsSuccess = true };

            }
        }
    }
}
