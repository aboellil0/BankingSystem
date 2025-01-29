namespace BankingSystem.UserService.Domain.Entities
{
    public class UserDocument
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string DocumentType { get; private set; }
        public string DocumentNumber { get; private set; }
        public string DocumentUrl { get; private set; }
        public bool IsVerified { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public DateTime UploadedAt { get; private set; }
        public DateTime? VerifiedAt { get; private set; }
        public ApplicationUser ApplicationUser { get; private set; }

        public static UserDocument Create(Guid userId,string documentType,string documentNumber, string documentUrl,DateTime expiryDate)
        {
            return new UserDocument
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                DocumentType = documentType,
                DocumentNumber = documentNumber,
                DocumentUrl = documentUrl,
                IsVerified = false,
                ExpiryDate = expiryDate,
                UploadedAt = DateTime.UtcNow
            };
        }

        public void Verify()
        {
            IsVerified = true;
            VerifiedAt = DateTime.UtcNow;
        }
    }
}
