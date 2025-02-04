using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class TransactionLog
    {
        public Guid Id { get; set; }
        public Guid transactionId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public Dictionary<string, object> Metadata_Json { get; set; }
        public DateTime CreatedAt { get; set; }

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
