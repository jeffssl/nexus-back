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
    }
}
