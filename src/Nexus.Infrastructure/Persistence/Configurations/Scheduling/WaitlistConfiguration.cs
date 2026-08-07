using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Infrastructure.Persistence.Configurations.Scheduling;

/// <summary>
/// Entity Framework configuration for the Waitlist entity.
/// Configuración de Entity Framework para la entidad Waitlist.
/// </summary>
public class WaitlistConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Scheduling.Waitlist>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Scheduling.Waitlist> builder)
    {
        builder.ToTable("waitlists", "scheduling");

        builder.HasKey(e => e.WaitlistId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.PatientId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Practitioner>().WithMany().HasForeignKey(e => e.PractitionerId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Specialty>().WithMany().HasForeignKey(e => e.SpecialtyId);
    }
}
