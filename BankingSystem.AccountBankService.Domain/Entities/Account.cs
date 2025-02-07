using BankingSystem.TransactionService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AccountBankService.Domain.Entities
{
    public class Account 
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public Guid AccountTypeId { get; set; }
        public string Currency { get; set; }

        // Relationship with ApplicationUser
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public AccountType AccountType { get; set; }

        // Navigation properties
        public ICollection<Transaction> Transactions { get; set; }
    }
}
