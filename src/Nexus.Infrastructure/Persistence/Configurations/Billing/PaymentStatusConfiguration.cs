using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

public class PaymentStatusConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.PaymentStatus>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.PaymentStatus> builder)
    {
        builder.ToTable("payment_statuses", "billing");

        builder.HasKey(e => e.StatusCode);


        builder.HasData(
            new PaymentStatus { StatusCode = "PENDING", Name = "Pendiente", IsFinal = false },
            new PaymentStatus { StatusCode = "COMPLETED", Name = "Completado", IsFinal = true },
            new PaymentStatus { StatusCode = "FAILED", Name = "Fallido", IsFinal = true },
            new PaymentStatus { StatusCode = "REFUNDED", Name = "Reembolsado", IsFinal = true }
        );
    }
}
