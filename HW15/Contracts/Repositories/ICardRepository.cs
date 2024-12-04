using HW15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Contracts.Repositories
{
    public interface ICardRepository
    {
        bool PasswordIsValid(string cardNumber, string password);
        void Whitdraw(string cardNo, float amount);
        void Deposite(string cardNo, float amount);
        void SetWrongPasswordTry (string cardNo);
        int GetWrongPasswordCount(string cardNo);
        bool CardIsActive(string cardNumber);
        Card GetCardBy(string cardNumber);
        void ClearWrongPasswordTry(string cardNumber);
        void ChangePassword(string cardNumber, string password , string newPassword);
        
    }
}
