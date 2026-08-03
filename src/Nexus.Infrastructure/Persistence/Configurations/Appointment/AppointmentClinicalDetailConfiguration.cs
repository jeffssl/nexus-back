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
    }
}
