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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Pricing.PriceList>().WithMany().HasForeignKey(e => e.PriceListId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Location>().WithMany().HasForeignKey(e => e.LocationId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Specialty>().WithMany().HasForeignKey(e => e.SpecialtyId);
        builder.HasOne<Nexus.Domain.Entities.Pricing.Service>().WithMany().HasForeignKey(e => e.ServiceId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Practitioner>().WithMany().HasForeignKey(e => e.PractitionerId);
        builder.HasOne<Nexus.Domain.Entities.Pricing.Currency>().WithMany().HasForeignKey(e => e.CurrencyCode);
    }
}
