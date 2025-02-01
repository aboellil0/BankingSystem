using Azure.Core;
using BankingSystem.UserService.Application.DTOs;
using BankingSystem.UserService.Application.Interfaces;
using BankingSystem.UserService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankingSystem.UserService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ILogger<AuthService> _logger;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<ApplicationUser> manager, ILogger<AuthService> logger,ITokenService tokenService,IConfiguration configuration)
        {
            this._manager = manager;
            this._logger = logger;
            this._tokenService = tokenService;
            this._configuration = configuration;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterReq request)
        {
            if (await _manager.FindByNameAsync(request.UserName) is not null)
            {
                return new AuthResponse { Error = "User Is already regiterd with same Email",Message = request.UserEmail,Success = false};
            }

            if (await _manager.FindByNameAsync(request.UserName) is not null)
            {
                return new AuthResponse { Error = "User Is already regiterd with same username", Message = request.UserName, Success = false };
            }

            var user = ApplicationUser.Create(request.UserEmail, request.FirstName, request.LastName, request.Birthaday,UserStatus.SystemStatusIds.Active);
            var result =  await _manager.CreateAsync(user,request.Password);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ",result.Errors);
                return new AuthResponse { Error = errors, Message = "User not Created", Success = false };
            }


            return await GenerateAuthResponseAsync(user, request.IpAddress);

        }

        public async Task<AuthResponse> LoginAsync(LoginReq request)
        {
            try
            {
                var user = await _manager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    return new AuthResponse { Success = false, Error = "Invalid credentials" };
                }


                return await GenerateAuthResponseAsync(user, request.DeviceId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed for user {Username}", request.UserName);
                return new AuthResponse { Success = false, Error = string.Join(", ",ex), Message = "Login failed for user {Username}" };
            }
        }

        public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenReq request)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(request.AccessToken);
                if (principal == null)
                {
                    return new AuthResponse { Success = false, Error = "Invalid access token" };
                }

                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var storedToken = await _tokenService.GetStoredRefreshTokenAsync(request.RefreshToken);

                if (storedToken == null || storedToken.UserId != Guid.Parse(userId) ||
                    !storedToken.IsActive || DateTime.UtcNow >= storedToken.ExpireDate)
                {
                    return new AuthResponse { Success = false, Error = "Invalid refresh token" };
                }

                var user = await _manager.FindByNameAsync(userId);
                return await GenerateAuthResponseAsync(user, storedToken.CreatedByIp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Token refresh failed");
                return new AuthResponse { Success = false, Error = "Token refresh failed" };
            }
        }







        private async Task<AuthResponse> GenerateAuthResponseAsync(ApplicationUser user, string deviceId)
        {
            var accessToken = await _tokenService.GenerateJwtTokenAsync(user);
            var refreshToken = await _tokenService.GenerateRefreshTokenAsync(user.Id, deviceId);

            return new AuthResponse
            {
                Success = true,
                Token = accessToken,
                RefreshToken = refreshToken.Token,
                AccessTokenExpiration = DateTime.UtcNow.AddMinutes(
                    _configuration.GetValue<int>("Jwt:AccessTokenExpirationMinutes", 15))
            };
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateLifetime = false // Allow expired tokens
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
            return principal;
        }

    }
}

