using BankingSystem.UserService.Application.Interfaces;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Type;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.Services
{
    public class FirebaseService : IFirebaseService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<FirebaseService> _logger; 
        private readonly FirebaseAuth _firebaseAuth;
        private readonly FirebaseService _firebaseApp;
        private static readonly object _lock = new object();
        private static bool _isInitialized;
        public FirebaseService(IConfiguration configuration,ILogger<FirebaseService> logger, FirebaseAuth firebaseAuth,FirebaseService firebaseApp)
        {
            this._configuration = configuration;
            this._logger = logger; 
            this._firebaseAuth = firebaseAuth;

            if (_isInitialized) return;

            lock (_lock)
            {
                if (_isInitialized) return;

                var firebaseConfig = configuration.GetSection("Firebase").Get<string>();
                var credential = GoogleCredential.FromJson(firebaseConfig);

                if (FirebaseApp.DefaultInstance == null)
                {
                    FirebaseApp.Create(new AppOptions
                    {
                        Credential = credential
                    });
                }

                _isInitialized = true;
            }
            _firebaseAuth = FirebaseAuth.DefaultInstance;
        }

        public async Task<string> SendVerificationCodeAsync(string phoneNumber)
        {
            try
            {
                var verificationCode = await _firebaseApp.SendVerificationCodeAsync(phoneNumber);
                return verificationCode;
            }
            catch (FirebaseAuthException ex)
            {
                _logger.LogError(ex.Message,$"Failed to send verification code: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> VerifyPhoneNumberAsync(string phoneNumber, string code)
        {
            try
            {
                var result = await _firebaseApp.VerifyPhoneNumberAsync(phoneNumber, code);

                return result;
            }
            catch (FirebaseAuthException ex)
            {
                _logger.LogError(ex.Message, "VerifyPhoneNumberAsync Failed");
                return false;
            }
        }
    }
}
