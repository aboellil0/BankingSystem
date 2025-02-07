using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class ComplianceCheck
    {
        public Guid Id { get; private set; }
        public Guid TransactionId { get; private set; }
        public Guid TypeId { get; private set; }
        public bool Passed { get; private set; }
        public DateTime CheckendAt { get; private set; }
        public Dictionary<string,object> CheckDetails_json { get; private set; }

    }
}
