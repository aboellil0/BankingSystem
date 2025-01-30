using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Events
{
    public class LoginFailedEvent
    {
        public string UserName { get; }
        public string IpAddress { get; }
        public int FailedAttempts { get; }
        public DateTime AttemptedAt { get; }


        public LoginFailedEvent(string username,string ip,int failedAttempts,DateTime date)
        {
            UserName = username;
            IpAddress = ip;
            FailedAttempts = failedAttempts;
            AttemptedAt = date;
        }
    }
}
