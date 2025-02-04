using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class TransactionType
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }

        public static TransactionType Create(string name,string des)
        {
            return new TransactionType()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = des,
                IsActive = true
            };
        }
    }
}
