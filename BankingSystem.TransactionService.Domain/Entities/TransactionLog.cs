using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class TransactionLog
    {
        public Guid Id { get; private set; }
        public Guid transactionId { get; private set; }
        public string Action { get; private set; }
        public string Description { get; private set; }
        public Dictionary<string, object> Metadata_Json { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static TransactionLog Create(Guid TransId,string Action,string Description, Dictionary<string, object> metadata)
        {
            return new TransactionLog
            {
                Id = Guid.NewGuid(),
                transactionId = TransId,
                Action = Action,
                Description = Description,
                Metadata_Json = metadata,
                CreatedAt = DateTime.UtcNow,
            };
        }
    }
}
