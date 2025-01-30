using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Events
{
    public class UserRoleChangedEvent
    {
        public Guid UserId { get; }
        public string[] PreviousRoles { get; }
        public string[] NewRoles { get; }
        public DateTime ChangedAt { get; }
        public string ChangedBy { get; }

        public UserRoleChangedEvent(Guid userId, string[] previousRoles, string[] newRoles, DateTime changedAt, string changedBy)
        {
            UserId = userId;
            PreviousRoles = previousRoles;
            NewRoles = newRoles;
            ChangedAt = changedAt;
            ChangedBy = changedBy;
        }
    }
}
