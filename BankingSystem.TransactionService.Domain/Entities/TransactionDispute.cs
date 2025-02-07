using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class TransactionDispute
    {
        public Guid Id { get; private set; }
        public Guid TransactoiinId { get; private set; }
        public Guid StatusId { get; private set; }
        public string Reason { get; private set; }
        public DateTime FiledAt { get; private set; }
        public DateTime ResolvedAt { get; private set; }


        public static TransactionDispute Create(Guid TransId, Guid statusId, string reason)
        {
            return new TransactionDispute
            {
                Id = Guid.NewGuid(),
                TransactoiinId = TransId,
                StatusId = statusId,
                Reason = reason,
                FiledAt = DateTime.UtcNow,
                ResolvedAt = DateTime.UtcNow,
            };
        }
    }
}
