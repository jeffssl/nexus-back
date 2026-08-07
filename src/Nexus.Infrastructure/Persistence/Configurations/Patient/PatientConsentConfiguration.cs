using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Infrastructure.Persistence.Configurations.Patient;

/// <summary>
/// Entity Framework configuration for the PatientConsent entity.
/// Configuración de Entity Framework para la entidad PatientConsent.
/// </summary>
public class PatientConsentConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Patient.PatientConsent>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Patient.PatientConsent> builder)
    {
        builder.ToTable("patient_consents", "patient");

        builder.HasKey(e => e.ConsentId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.PatientId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
    }
}
