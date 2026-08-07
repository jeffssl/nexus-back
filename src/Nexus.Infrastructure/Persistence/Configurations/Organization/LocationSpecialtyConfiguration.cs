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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Location>().WithMany().HasForeignKey(e => e.LocationId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Specialty>().WithMany().HasForeignKey(e => e.SpecialtyId);
    }
}
