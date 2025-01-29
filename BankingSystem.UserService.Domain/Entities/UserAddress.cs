using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Domain.Entities
{
    public class UserAddress
    {
        public Guid Id {get; private set; }
        public Guid UserId { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }
        public bool IsPrimary { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public ApplicationUser User { get; private set; }


        protected UserAddress()
        {
            
        }

        public static UserAddress CreateUserAddress(Guid userid, string Add1, string Add2, string city, string state, string Country, string code, bool isPrimary = false)
        {
            return new UserAddress() {
                Id = Guid.NewGuid(),
                UserId = userid,
                AddressLine1 = Add1,
                AddressLine2 = Add2,
                City = city,
                State = state,
                Country = Country,
                PostalCode = code,
                IsPrimary = isPrimary,
                CreatedAt = DateTime.Now,,
                UpdatedAt = DateTime.Now,
            };
        }

        public void SetPrimary(bool isPrimary) 
        {
            IsPrimary = isPrimary;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(string addressLine1,string addressLine2,string city,string state,string country,string postalCode)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
