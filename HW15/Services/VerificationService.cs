using HW15.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Services
{
    public class VerificationService : IVerificationCodeService
    {

        private readonly string _verificationCodeFilePath = @"D:\verify.txt";

        public string GenerateAndSaveCode()
        {
            var verificationCode = new Random().Next(10000, 99999).ToString();

            
            SaveVerificationCodeToFile(verificationCode);

            return verificationCode;
        }

        public void SaveVerificationCodeToFile(string verificationCode)
        {
            using (StreamWriter writer = new StreamWriter(_verificationCodeFilePath, false))
            {
                writer.WriteLine(verificationCode);
                writer.WriteLine(DateTime.Now); 
            }
        }

        public Result ValidateCode(string enteredCode)
        {
            if (File.Exists(_verificationCodeFilePath))
            {
                var lines = File.ReadAllLines(_verificationCodeFilePath);
                string storedCode = lines[0];
                DateTime timestamp = DateTime.Parse(lines[1]);


                if (storedCode == enteredCode && DateTime.Now - timestamp <= TimeSpan.FromMinutes(5))
                {
                    return new Result { IsSuccess = true };
                }
            }
            return new Result { IsSuccess = false , Erorr ="Code is not valid!" };
        }
    }
}
