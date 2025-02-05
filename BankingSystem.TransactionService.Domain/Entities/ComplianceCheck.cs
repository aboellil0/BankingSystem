using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class ComplianceCheck
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid TypeId { get; set; }
        public Dictionary<string,object> CheckDetails_json { get; set; }
        public bool Passed { get; set; }
        public DateTime CheckendAt { get; set; }

    }
}
