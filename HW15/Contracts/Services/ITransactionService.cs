using HW15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Contracts.Services
{
    public interface ITransactionService
    {
        Result TransferMoney(string sCardNumber, string DCardNumber, float amount);
        List<Transaction> GetTransactionLIst(string cardNumber);
    }
}
