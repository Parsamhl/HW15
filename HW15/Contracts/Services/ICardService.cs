﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Contracts.Services
{
    public interface ICardService
    {
        Result PasswordIsValid(string cardNumber, string password);
        Result GetCardBalance(string cardNumber);


    }
}