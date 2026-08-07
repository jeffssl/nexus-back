using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Organization;

namespace Nexus.Infrastructure.Persistence.Configurations.Organization;

/// <summary>
/// Entity Framework configuration for the LocationAddress entity.
/// Configuración de Entity Framework para la entidad LocationAddress.
/// </summary>
public class LocationAddressConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Organization.LocationAddress>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Organization.LocationAddress> builder)
    {
        builder.ToTable("location_addresses", "organization");

        builder.HasKey(e => e.AddressId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Location>().WithMany().HasForeignKey(e => e.LocationId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Geographic.City>().WithMany().HasForeignKey(e => e.CityId);
    }
}
