using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

public class RefundStatusConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.RefundStatus>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.RefundStatus> builder)
    {
        builder.ToTable("refund_statuses", "billing");

        builder.HasKey(e => e.StatusCode);


        builder.HasData(
            new RefundStatus { StatusCode = "PENDING", Name = "Pendiente", IsFinal = false },
            new RefundStatus { StatusCode = "APPROVED", Name = "Aprobado", IsFinal = true },
            new RefundStatus { StatusCode = "REJECTED", Name = "Rechazado", IsFinal = true },
            new RefundStatus { StatusCode = "COMPLETED", Name = "Completado", IsFinal = true }
        );
    }
}
