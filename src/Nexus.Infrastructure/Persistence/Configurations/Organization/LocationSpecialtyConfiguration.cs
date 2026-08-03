using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Organization;

namespace Nexus.Infrastructure.Persistence.Configurations.Organization;

/// <summary>
/// Entity Framework configuration for the LocationSpecialty entity.
/// Configuración de Entity Framework para la entidad LocationSpecialty.
/// </summary>
public class LocationSpecialtyConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Organization.LocationSpecialty>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Organization.LocationSpecialty> builder)
    {
        builder.ToTable("location_specialties", "organization");

        builder.HasKey(e => e.LocationSpecialtyId);

        builder.HasIndex(e => e.TenantId);
    }
}
