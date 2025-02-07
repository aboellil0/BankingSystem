using BankingSystem.TransactionService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Infrastructure.Persistence.Configurations
{
    public class ComplianceCheckConfigration : IEntityTypeConfiguration<ComplianceCheck>
    {
        public void Configure(EntityTypeBuilder<ComplianceCheck> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne<ComplianceType>()
                .WithOne()
                .HasForeignKey<ComplianceCheck>(t => t.TypeId);
        }
    }
}
