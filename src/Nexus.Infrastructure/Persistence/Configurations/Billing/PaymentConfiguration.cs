using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

public class PaymentConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.Payment>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.Payment> builder)
    {
        builder.ToTable("payments", "billing");

        builder.HasKey(e => e.PaymentId);
    }
}
