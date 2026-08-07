using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Infrastructure.Persistence.Configurations.Patient;

/// <summary>
/// Entity Framework configuration for the PatientContact entity.
/// Configuración de Entity Framework para la entidad PatientContact.
/// </summary>
public class PatientContactConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Patient.PatientContact>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Patient.PatientContact> builder)
    {
        builder.ToTable("patient_contacts", "patient");

        builder.HasKey(e => e.PatientContactId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.PatientId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.System.ContactType>().WithMany().HasForeignKey(e => e.ContactTypeId);
    }
}
