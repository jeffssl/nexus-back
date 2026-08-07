using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Infrastructure.Persistence.Configurations.Patient;

/// <summary>
/// Entity Framework configuration for the PatientInsurance entity.
/// Configuración de Entity Framework para la entidad PatientInsurance.
/// </summary>
public class PatientInsuranceConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Patient.PatientInsurance>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Patient.PatientInsurance> builder)
    {
        builder.ToTable("patient_insurances", "patient");

        builder.HasKey(e => e.PatientInsuranceId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.PatientId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Insurance.Payer>().WithMany().HasForeignKey(e => e.PayerId);
        builder.HasOne<Nexus.Domain.Entities.Insurance.Plan>().WithMany().HasForeignKey(e => e.PlanId);
    }
}
