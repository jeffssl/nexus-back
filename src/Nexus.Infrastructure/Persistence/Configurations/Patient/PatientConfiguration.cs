using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Infrastructure.Persistence.Configurations.Patient;

public class PatientConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Patient.Patient>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Patient.Patient> builder)
    {
        builder.ToTable("patients", "patient");

        builder.HasKey(e => e.PatientId);
    }
}
