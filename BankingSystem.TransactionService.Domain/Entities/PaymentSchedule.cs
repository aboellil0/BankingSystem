using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.TransactionService.Domain.Entities
{
    public class PaymentSchedule
    {
        public Guid Id { get; private set; }
        public string Frequency { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; } = DateTime.MaxValue;
        public Dictionary<string, object> ScheduleDetails { get; private set; } = new(); 

        public static PaymentSchedule Create(string freq, Dictionary<string, object> scheduleDetails)
        {
            return new PaymentSchedule()
            {
                Id = Guid.NewGuid(),
                Frequency = freq,
                ScheduleDetails = scheduleDetails,
                StartDate = DateTime.UtcNow,
            };
        }

        public void EndThePayment(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}
