﻿using BankingSystem.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.UserService.Infrastructure.Persistence.Configurations
{
    public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasData(
                new
                {
                    Id = UserStatus.SystemStatusIds.Active,
                    Name = "Active",
                    Description = "User is active and can perform all operations",
                    CreatedAt = DateTime.UtcNow
                },
                new
                {
                    Id = UserStatus.SystemStatusIds.Pending,
                    Name = "Pending",
                    Description = "User registration is pending verification",
                    CreatedAt = DateTime.UtcNow
                },
                new
                {
                    Id = UserStatus.SystemStatusIds.Suspended,
                    Name = "Suspended",
                    Description = "User is temporarily suspended",
                    CreatedAt = DateTime.UtcNow
                },
                new
                {
                    Id = UserStatus.SystemStatusIds.Locked,
                    Name = "Locked",
                    Description = "User is locked due to suspicious activity",
                    CreatedAt = DateTime.UtcNow
                },
                new
                {
                    Id = UserStatus.SystemStatusIds.Dormant,
                    Name = "Dormant",
                    Description = "User account is dormant due to inactivity",
                    CreatedAt = DateTime.UtcNow
                }
            );


        }
    }
}
