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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Geographic.DocumentType>().WithMany().HasForeignKey(e => e.DocumentTypeId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UserId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.CreatedBy);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UpdatedBy);
    }
}
