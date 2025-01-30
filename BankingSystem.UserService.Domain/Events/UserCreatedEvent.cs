using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Events
{
    public class UserCreatedEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string Username { get; }
        public DateTime CreatedAt { get; }

        public UserCreatedEvent(Guid userId, string email, string username, DateTime createdAt)
        {
            UserId = userId;
            Email = email;
            Username = username;
            CreatedAt = createdAt;
        }
    }
}
