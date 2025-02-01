using BankingSystem.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateJwtTokenAsync(ApplicationUser user);
        public Task<RefreshToken> GenerateRefreshTokenAsync(Guid userId, string deviceId);
        public Task<RefreshToken> GetStoredRefreshTokenAsync(string token);
        public Task StoreRefreshTokenAsync(RefreshToken token);
        public Task<bool> RevokeTokenAsync(string token);
    }
}
