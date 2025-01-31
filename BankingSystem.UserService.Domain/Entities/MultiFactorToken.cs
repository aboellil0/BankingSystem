using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Entities
{
    public class MultiFactorToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public MfaType Type { get; set; }
    }

    public enum MfaType
    {
        Authenticator,
        SMS,
        Email
    }
}
