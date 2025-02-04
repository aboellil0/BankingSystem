namespace BankingSystem.TransactionService.Domain.Entities
{
    public class TransactionStatus
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsFinal { get; private set; } = false;
        public static TransactionStatus Create(string name, string description)
        {
            return new TransactionStatus
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
        }
        public void VerfyIsFinal(bool isFinal)
        {
            this.IsFinal = isFinal;
        }

    }

}
