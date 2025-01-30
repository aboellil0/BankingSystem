using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Events
{
    public class UserAddressUpdatedEvent
    {
        public Guid UserId { get; }
        public string OldAddress { get; }
        public string NewAddress { get; }
        public DateTime UpdatedAt { get; }

        public UserAddressUpdatedEvent(Guid userId, string oldAddress, string newAddress, DateTime updatedAt)
        {
            UserId = userId;
            OldAddress = oldAddress;
            NewAddress = newAddress;
            UpdatedAt = updatedAt;
        }
    }
}
