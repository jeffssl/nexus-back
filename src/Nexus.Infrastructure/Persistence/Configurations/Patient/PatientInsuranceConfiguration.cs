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
    }
}
