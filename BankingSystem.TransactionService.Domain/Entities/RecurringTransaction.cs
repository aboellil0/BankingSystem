using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class RecurringTransaction
    {
        public Guid Id { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Guid CurrencyId { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; } = false;
        public decimal Amount { get; private set; }

        public static RecurringTransaction Create(Guid scheduleId, Guid currencyId, string des, decimal amount)
        {
            return new RecurringTransaction
            {
                Id = Guid.NewGuid(),
                Description = des,
                ScheduleId = scheduleId,
                CurrencyId = currencyId,
                Amount = amount
            };
        }

        public void VerfyIsActive()
        {
            IsActive = true;
        }
    }
}
