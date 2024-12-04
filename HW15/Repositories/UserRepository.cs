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

        public User GetUser(string cardNumber)
        {
            //var user = _context.Users.FirstOrDefault(u=> u.CardNumber == cardNumber);
            // if (user is null)
            // {
            //     throw new Exception("card Number is invalid");

            // }
            // else
            // {
            //     return user;
            // }

            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                foreach (var card in user.Cards)
                {
                    if (card.CardNumber == cardNumber)
                    {
                        return user;
                    }
                }
            }
            return null;
        }
    }
}
