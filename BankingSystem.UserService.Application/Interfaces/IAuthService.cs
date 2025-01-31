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
        Task<RefreshToken> RegisterAsync(AuthRequest auth);
    }
}
