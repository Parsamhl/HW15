using HW15.Contracts.Repositories;
using HW15.Data;
using HW15.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public string GetRecipientName(string destinationCardNumber)
        {
            var user = _context.Users
            .Include(u => u.Cards)
            .FirstOrDefault(u => u.Cards.Any(c => c.CardNumber == destinationCardNumber));

            return user?.Name;
        }
    }
}
