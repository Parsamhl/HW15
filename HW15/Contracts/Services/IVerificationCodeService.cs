﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Contracts.Services
{
    public interface IVerificationCodeService
    {
        string GenerateAndSaveCode();
        void SaveVerificationCodeToFile(string verificationCode);
        Result ValidateCode(string enteredCode);



    }
}
