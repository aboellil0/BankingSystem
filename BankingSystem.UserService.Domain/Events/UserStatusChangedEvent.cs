using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Events
{
    public class UserStatusChangedEvent
    {
        public Guid UserId { get; }
        public string OldSatatus { get; }
        public string NewSatatus { get; }
        public DateTime ChangedAt  { get; }

        public UserStatusChangedEvent(Guid guid,string oldstatus,string newstatus,DateTime changedat)
        {
            UserId = guid;
            OldSatatus = oldstatus;
            NewSatatus = newstatus;
            ChangedAt = changedat;
        }

    }
}
