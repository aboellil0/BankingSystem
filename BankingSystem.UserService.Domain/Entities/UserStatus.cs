using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Entities
{
    public class UserStatus
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected UserStatus()
        {
            
        }

        public static UserStatus CreateUserStatus(string name,string Disc)
        {
            return new UserStatus
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = Disc,
                CreatedAt = DateTime.Now,
            };
        }

        public static class SystemStatusIds
        {
            public static readonly Guid Active = new("67993ee9-26c8-8004-9cf2-b5477b429abe");
            public static readonly Guid Pending = new("2b77cc91-fed1-40cb-85af-d462d06721a5");
            public static readonly Guid Suspended = new("a2439c13-c3e1-4145-9af6-f6f729f35512");
            public static readonly Guid Locked = new("b232403f-ddbc-424c-bbf9-1f7e0524f41e");
            public static readonly Guid Dormant = new("317c39dc-e521-4268-a88e-8a0f48502b33");
            public static readonly Guid Blocked = new("1c816d9b-27c6-4cd3-90e1-d24b203852d7");
        }
    }
}
