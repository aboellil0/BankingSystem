using BankingSystem.AccountBankService.Domain.Entities;
using BankingSystem.TransactionService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Infrastructure.Persistence.Configurations
{
    public class TransactionConfigration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder) 
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne<Account>()
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.sourceAccountId);

            builder
                .HasOne<Account>()
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.destinationAccountId);

            builder
                .HasMany(t => t.TransactionLogs)
                .WithOne()
                .HasForeignKey(tL => tL.transactionId);

            builder
                .HasMany(t=>t.TransactionNotifications)
                .WithOne()
                .HasForeignKey(n=>n.TransactionId);

            builder
                .HasOne(t => t.Settlement)
                .WithOne()
                .HasForeignKey<Settlement>(s => s.TransactionId);

            builder
                .HasOne(t => t.ComplianceCheck)
                .WithOne()
                .HasForeignKey<ComplianceCheck>(c => c.TransactionId);

            builder
                .HasOne(t=>t.TransactionDispute)
                .WithOne()
                .HasForeignKey<TransactionDispute>(r => r.TransactoiinId);

            builder
                .HasOne(t => t.RecurringTransaction)
                .WithMany();

            builder
                .HasOne(t => t.Type)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.typeId);

            builder
                .HasOne(t => t.Status)
                .WithOne()
                .HasForeignKey<Transaction>(t => t.statusId);

            builder
                .HasOne(t => t.Currency)
                .WithOne()
                .HasForeignKey<Transaction>(t=>t.currencyId);
        }
    }
}
