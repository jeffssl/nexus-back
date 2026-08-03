using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

/// <summary>
/// Entity Framework configuration for the Refund entity.
/// Configuración de Entity Framework para la entidad Refund.
/// </summary>
public class RefundConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.Refund>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.Refund> builder)
    {
        builder.ToTable("refunds", "billing");

        builder.HasKey(e => e.RefundId);

        builder.HasIndex(e => e.TenantId);
    }
}
