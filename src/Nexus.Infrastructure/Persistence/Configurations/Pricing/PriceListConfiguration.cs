using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Pricing;

namespace Nexus.Infrastructure.Persistence.Configurations.Pricing;

/// <summary>
/// Entity Framework configuration for the PriceList entity.
/// Configuración de Entity Framework para la entidad PriceList.
/// </summary>
public class PriceListConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Pricing.PriceList>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Pricing.PriceList> builder)
    {
        builder.ToTable("price_lists", "pricing");

        builder.HasKey(e => e.PriceListId);

        builder.HasIndex(e => e.TenantId);
    }
}
