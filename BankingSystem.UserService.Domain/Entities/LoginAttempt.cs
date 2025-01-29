using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Entities
{
    public class LoginAttempt
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string IpAddress { get; private set; }
        public string UserAgent { get; private set; }
        public bool IsSuccessful { get; private set; }
        public string FailureReason { get; private set; }
        public DateTime AttemptedAt { get; private set; }
        public ApplicationUser User { get; private set; }

        protected LoginAttempt()
        {
            
        }

        public static LoginAttempt CreateLoginAttemptSuccess(Guid userid,string ipaddress,string useragent)
        {
            return new LoginAttempt
            {
                Id = Guid.NewGuid(),
                UserId = userid,
                IpAddress = ipaddress,
                UserAgent = useragent,
                IsSuccessful = true,
                AttemptedAt = DateTime.UtcNow
            };
        }

        public static LoginAttempt CreateLoginAttemptFailed(Guid userid, string ipaddress, string useragent, string reason)
        {
            return new LoginAttempt
            {
                Id = Guid.NewGuid(),
                UserId = userid,
                IpAddress = ipaddress,
                UserAgent = useragent,
                FailureReason = reason,
                IsSuccessful = false,
                AttemptedAt = DateTime.UtcNow
            };
        }


    }
}
