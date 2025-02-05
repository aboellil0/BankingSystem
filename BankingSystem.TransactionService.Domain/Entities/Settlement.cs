using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class Settlement
    {
        public Guid Id { get; private set; }
        public Guid TransactionId { get; private set; }
        public string Status { get; private set; }
        public DateTime SettledAt { get; private set; }
        public Dictionary<string, object> SettlementDetails_Json { get; private set; }

        public static Settlement Create(Guid TransId, string status, Dictionary<string, object> settlementDetails_Json)
        {
            return new Settlement()
            {
                Id = Guid.NewGuid(),
                TransactionId = TransId,
                Status = status,
                SettledAt = DateTime.UtcNow,
                SettlementDetails_Json = settlementDetails_Json,
            };
        }
    }

}
