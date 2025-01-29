using BankingSystem.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.UserService.Infrastructure.Persistence.Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
            new
            {
                Id = Guid.Parse("3F2504E0-4F89-41D3-9A0C-0305E82C3301"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Administrator role with full access",
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) // Static DateTime
            },
            new
            {
                Id = Guid.Parse("6F9619FF-8B86-D011-B42D-00C04FC964FF"),
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                Description = "Regular customer role with account management",
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) // Static DateTime
            },
            new
            {
                Id = Guid.Parse("F47AC10B-58CC-4372-A567-0E02B2C3D479"),
                Name = "BankTeller",
                NormalizedName = "BANKTELLER",
                Description = "Bank teller handling customer transactions",
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) // Static DateTime
            }
        );
        }
    }
}
