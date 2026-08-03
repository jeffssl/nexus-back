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
    }
}
