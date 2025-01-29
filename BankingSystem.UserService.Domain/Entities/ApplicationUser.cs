using Microsoft.AspNetCore.Identity;

namespace BankingSystem.UserService.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsEmailVerified { get; private set; }
        public bool IsPhoneVerified { get; private set; }
        public Guid StatusId { get; private set; }

        public ICollection<UserAddress> AddressList { get; private set; } = new List<UserAddress>();
        public ICollection<UserDocument> DocumentList { get; private set; } = new List<UserDocument>();
        public ICollection<RefreshToken> refreshTokens { get; private set; } = new List<RefreshToken>();
        public ICollection<LoginAttempt> LoginAttempts { get; private set; } = new List<LoginAttempt>();
        public virtual UserStatus Status { get; private set; }


        protected ApplicationUser() { } // عشان ال EFCore


        public static ApplicationUser Create(string email, string fName, string lName, DateTime dateBirhday, Guid statusId)
        {
            return new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                Email = email,
                UserName = email,
                FirstName = fName,
                LastName = lName,
                DateOfBirth = dateBirhday,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
        }

        public void UpdateProfile(string fname, string lname)
        {
            FirstName = fname;
            LastName = lname;
            UpdatedAt = DateTime.UtcNow;    
        }

        public void UpdateStatus(Guid statuseId)
        {
            statuseId = statuseId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void VirfyEmail()
        {
            IsEmailVerified = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void VirfyPhone()
        {
            IsPhoneVerified = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
