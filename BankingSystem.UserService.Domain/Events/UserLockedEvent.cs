using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Events
{
    public class UserLockedEvent
    {
        public Guid UserId { get; }
        public string Reason { get; }
        public DateTime LockedAt { get; }
        public DateTime? UnlockAt { get; }

        public UserLockedEvent(Guid userId, string reason, DateTime lockedAt, DateTime? unlockAt)
        {
            UserId = userId;
            Reason = reason;
            LockedAt = lockedAt;
            UnlockAt = unlockAt;
        }
    }
}
