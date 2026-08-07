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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Practitioner>().WithMany().HasForeignKey(e => e.PractitionerId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.System.ContactType>().WithMany().HasForeignKey(e => e.ContactTypeId);
    }
}
