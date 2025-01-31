using BankingSystem.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.DTOs
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; } = string.Empty;
        public string Message { get; set; }
        public RefreshToken token { get; set; }
        public MultiFactorToken MFToken { get; set; }
    }
}
