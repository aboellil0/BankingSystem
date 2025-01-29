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
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder) 
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                ApplicationRole.CreateRole("Admin", "Administrator role with full access"),
                ApplicationRole.CreateRole("Customer", "Basic user role with account access"),
                ApplicationRole.CreateRole("BankTeller", "Handles customer transactions"),
                ApplicationRole.CreateRole("LoanOfficer", "Manages loan applications"),
                ApplicationRole.CreateRole("Auditor", "Monitors transactions for fraud detection"),
                ApplicationRole.CreateRole("SystemAdmin", "Manages banking system configurations")
                );
        }
    }
}
