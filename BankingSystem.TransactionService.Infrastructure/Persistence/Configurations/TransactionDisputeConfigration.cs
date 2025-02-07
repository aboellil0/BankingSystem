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
    public class TransactionDisputeConfigration : IEntityTypeConfiguration<TransactionDispute>
    {
        public void Configure(EntityTypeBuilder<TransactionDispute> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne<DisputeStatus>()
                .WithOne()
                .HasForeignKey<TransactionDispute>(d => d.StatusId);
        }
    }
}
