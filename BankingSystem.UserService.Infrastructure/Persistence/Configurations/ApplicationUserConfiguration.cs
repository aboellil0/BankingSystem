using BankingSystem.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Infrastructure.Persistence.Configurations
{
    public partial class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(t => t.Id);

            builder.
                HasMany(u => u.DocumentList)
                .WithOne(a=>a.ApplicationUser)
                .HasForeignKey(d => d.UserId);

            builder.
               HasMany(u => u.AddressList)
               .WithOne(a=>a.User)
               .HasForeignKey(a=>a.UserId);

            builder
                .HasMany(u=>u.LoginAttempts)
                .WithOne(a=>a.User)
                .HasForeignKey(a=>a.UserId);

            builder
                .HasMany(u=>u.refreshTokens)
                .WithOne(t=>t.ApplicationUser)
                .HasForeignKey(t=>t.UserId);

            builder.HasOne(u=>u.Status)
                .WithMany()
                .HasForeignKey(u=>u.StatusId);


            OnConfigurePartial(builder);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<ApplicationUser> builder);
    }

}
