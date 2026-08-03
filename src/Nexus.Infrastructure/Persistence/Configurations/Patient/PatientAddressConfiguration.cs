using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Infrastructure.Persistence.Configurations.Patient;

/// <summary>
/// Entity Framework configuration for the PatientAddress entity.
/// Configuración de Entity Framework para la entidad PatientAddress.
/// </summary>
public class PatientAddressConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Patient.PatientAddress>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Patient.PatientAddress> builder)
    {
        builder.ToTable("patient_addresses", "patient");

        builder.HasKey(e => e.AddressId);

        builder.HasIndex(e => e.TenantId);
    }
}
