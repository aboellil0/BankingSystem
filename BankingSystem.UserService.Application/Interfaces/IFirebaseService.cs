using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.Interfaces
{
    public interface IFirebaseService
    {
        Task<string> SendVerificationCodeAsync(string phoneNumber);
        Task<bool> VerifyPhoneNumberAsync(string phoneNumber, string code);
    }
}
