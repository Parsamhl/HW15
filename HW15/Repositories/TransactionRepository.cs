﻿using HW15.Contracts.Repositories;
using HW15.Data;
using HW15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly AppDbContext _context;

        public TransactionRepository()
        {
            _context = new AppDbContext();

        }
        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public float DailyWithdrawal(string cardNumber)
        {
            var amountOfTransactions = _context.Transactions
            .Where(x => x.TransactionDate.Date == DateTime.Now.Date && x.SourceCard.CardNumber == cardNumber)
            .Sum(x => x.Amount);

            return amountOfTransactions;

        }
    }
}
