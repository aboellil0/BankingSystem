using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class Currency
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public decimal ExchangeRate { get; private set; }

        public static Currency Create(string code,string name,decimal rate)
        {
            return new Currency
            {
                Id = Guid.NewGuid(),
                Code = code,
                Name = name,
                ExchangeRate = rate
            };
        }
    }
}
