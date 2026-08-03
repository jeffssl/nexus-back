using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Pricing;

namespace Nexus.Infrastructure.Persistence.Configurations.Pricing;

/// <summary>
/// Entity Framework configuration for the ServicePrice entity.
/// Configuración de Entity Framework para la entidad ServicePrice.
/// </summary>
public class ServicePriceConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Pricing.ServicePrice>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Pricing.ServicePrice> builder)
    {
        builder.ToTable("service_prices", "pricing");

        builder.HasKey(e => e.ServicePriceId);

        builder.HasIndex(e => e.TenantId);
    }
}
