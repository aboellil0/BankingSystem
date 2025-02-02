using BankingSystem.UserService.Application.Interfaces;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.Services
{
    public class FirebaseService : IFirebaseService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<FirebaseService> _logger;
        private readonly FirebaseApp _firebaseApp;

        public FirebaseService(IConfiguration configuration,ILogger<FirebaseService> logger,FirebaseApp firebaseApp)
        {
            this._configuration = configuration;
            this._logger = logger;
            this._firebaseApp = firebaseApp;
            try
            {
                var firebaseConfiguration = _configuration["Firebase:ServiceAccountKey"];
                var credintails = GoogleCredential.FromJson(firebaseConfiguration);

                _firebaseApp = FirebaseApp.Create(new AppOptions
                {
                    Credential = credintails,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Firebase Faild");
                throw;
            }
        }
    }
}
