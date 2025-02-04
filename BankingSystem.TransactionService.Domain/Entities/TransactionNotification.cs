using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class TransactionNotification
    {
        public Guid Id { get; set; }
        public Guid TransactionId {  get; set; }
        public string TransactionType { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime SendAt { get; set; }

        public static TransactionNotification Create(Guid TransId,string TransType,string content)
        {
            return new TransactionNotification()
            {
                Id = Guid.NewGuid(),
                TransactionType = TransType,
                Content = content,
                SendAt = DateTime.UtcNow,
            };
        }

        public void VerfiyIsReaded()
        {
            IsRead = true;
        }

    }
}
