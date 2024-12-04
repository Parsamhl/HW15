using HW15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Contracts.Repositories
{
    public interface ITransactionRepository
    {
        float DailyWithdrawal(string cardNumber);
        void Add(Transaction transaction);
        List<Transaction> GetAll(string cardNumber );
    }
}
