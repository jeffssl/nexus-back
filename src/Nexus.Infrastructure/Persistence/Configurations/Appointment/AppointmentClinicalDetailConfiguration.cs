using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Appointment;

namespace Nexus.Infrastructure.Persistence.Configurations.Appointment;

/// <summary>
/// Entity Framework configuration for the AppointmentClinicalDetail entity.
/// Configuración de Entity Framework para la entidad AppointmentClinicalDetail.
/// </summary>
public class AppointmentClinicalDetailConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Appointment.AppointmentClinicalDetail>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Appointment.AppointmentClinicalDetail> builder)
    {
        builder.ToTable("appointment_clinical_details", "appointment");

        builder.HasKey(e => e.ClinicalDetailId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Appointment.Appointment>().WithMany().HasForeignKey(e => e.AppointmentId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.CreatedBy);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UpdatedBy);
    }
}
