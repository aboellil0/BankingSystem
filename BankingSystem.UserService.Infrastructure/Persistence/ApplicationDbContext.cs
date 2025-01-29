using BankingSystem.UserService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.UserService.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("userClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("userLogins");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("userRoles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            modelBuilder.ApplyConfiguration(new Configurations.ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ApplicationRoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserStatusConfiguration());


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
