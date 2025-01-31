using BankingSystem.UserService.Application.DTOs;
using BankingSystem.UserService.Application.Interfaces;
using BankingSystem.UserService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankingSystem.UserService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _manager;

        public AuthService(UserManager<ApplicationUser> manager)
        {
            this._manager = manager;
        }
        public async Task<AuthResponse> RegisterAsync(AuthRequest authreq)
        {
            if (await _manager.FindByEmailAsync(authreq.UserEmail) is not null)
            {
                return new AuthResponse { Error = "User Is already regiterd with same Email",Message = authreq.UserEmail,Success = false};
            }

            if (await _manager.FindByNameAsync(authreq.UserName) is not null)
            {
                return new AuthResponse { Error = "User Is already regiterd with same username", Message = authreq.UserName, Success = false };
            }

            var user = ApplicationUser.Create(authreq.UserEmail, authreq.FirstName, authreq.LastName, authreq.Birthaday,UserStatus.SystemStatusIds.Active);
            var result =  await _manager.CreateAsync(user,authreq.Password);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ",result.Errors);
                return new AuthResponse { Error = errors,Message = "User not Created" ,Success = false}
            }

        }
    }
}

