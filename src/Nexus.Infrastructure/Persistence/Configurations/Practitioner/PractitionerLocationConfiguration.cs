using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Practitioner;

namespace Nexus.Infrastructure.Persistence.Configurations.Practitioner;

/// <summary>
/// Entity Framework configuration for the PractitionerLocation entity.
/// Configuración de Entity Framework para la entidad PractitionerLocation.
/// </summary>
public class PractitionerLocationConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Practitioner.PractitionerLocation>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Practitioner.PractitionerLocation> builder)
    {
        builder.ToTable("practitioner_locations", "practitioner");

        builder.HasKey(e => e.PractitionerLocationId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Practitioner>().WithMany().HasForeignKey(e => e.PractitionerId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Location>().WithMany().HasForeignKey(e => e.LocationId);
    }
}
