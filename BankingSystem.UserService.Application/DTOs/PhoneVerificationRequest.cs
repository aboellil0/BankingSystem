using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.DTOs
{
    public class PhoneVerificationRequest
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string VerificationCode { get; set; }
    }
    public class SendVerificationRequest
    {
        public string PhoneNumber { get; set; }
    }
    public class FirebaseSettings
    {
        public string Type { get; set; }
        public string ProjectId { get; set; }
        public string PrivateKeyId { get; set; }
        public string PrivateKey { get; set; }
        public string ClientEmail { get; set; }
        public string ClientId { get; set; }
        public string AuthUri { get; set; }
        public string TokenUri { get; set; }
        public string AuthProviderX509CertUrl { get; set; }
        public string ClientX509CertUrl { get; set; }
        public string UniverseDomain { get; set; }
    }
}
