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
    public class UserService : IUserService
    {
      
        private readonly IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }


        public string UserDetails(string cardNumber)
        {
            var userName =_userRepository.GetRecipientName(cardNumber);
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Destination card number not found.");

            return userName;

        }
    }
}
