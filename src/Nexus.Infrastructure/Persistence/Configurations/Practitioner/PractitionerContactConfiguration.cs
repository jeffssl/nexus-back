using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Practitioner;

namespace Nexus.Infrastructure.Persistence.Configurations.Practitioner;

/// <summary>
/// Entity Framework configuration for the PractitionerContact entity.
/// Configuración de Entity Framework para la entidad PractitionerContact.
/// </summary>
public class PractitionerContactConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Practitioner.PractitionerContact>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Practitioner.PractitionerContact> builder)
    {
        builder.ToTable("practitioner_contacts", "practitioner");

        builder.HasKey(e => e.PractitionerContactId);

        builder.HasIndex(e => e.TenantId);
    }
}
