using BankingSystem.UserService.Application.DTOs;
using BankingSystem.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponse> RegisterAsync(RegisterReq request);
        public Task<AuthResponse> LoginAsync(LoginReq request);
        public Task<AuthResponse> RefreshTokenAsync(RefreshTokenReq request);
    }
}
