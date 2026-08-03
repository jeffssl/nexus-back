using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Practitioner;

namespace Nexus.Infrastructure.Persistence.Configurations.Practitioner;

/// <summary>
/// Entity Framework configuration for the PractitionerSpecialty entity.
/// Configuración de Entity Framework para la entidad PractitionerSpecialty.
/// </summary>
public class PractitionerSpecialtyConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Practitioner.PractitionerSpecialty>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Practitioner.PractitionerSpecialty> builder)
    {
        builder.ToTable("practitioner_specialties", "practitioner");

        builder.HasKey(e => e.PractitionerSpecialtyId);

        builder.HasIndex(e => e.TenantId);
    }
}
