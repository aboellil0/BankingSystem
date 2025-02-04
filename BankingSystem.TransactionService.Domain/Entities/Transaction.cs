using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public Guid sourceAccountId { get; private set; }
        public Guid destinationAccountId { get; private set; }
        public Guid currencyId { get; private set; }
        public Guid typeId { get; private set; }
        public Guid statusId { get; private set; }
        public decimal amount { get; private set; }
        public string description { get; private set; }
        public string reference { get; private set; }
        public DateTime createdAt { get; private set; }
        public DateTime updatedAt { get; private set; }

    }
}
