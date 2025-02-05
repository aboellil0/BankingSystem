using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class TransactionDispute
    {
        public Guid Id { get; set; }
        public Guid TransactoiinId { get; set; }
        public Guid StatusId { get; set; }
        public string Reason { get; set; }
        public DateTime FiledAt { get; set; }
        public DateTime ResolvedAt { get; set; }


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
