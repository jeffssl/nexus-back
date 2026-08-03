using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Appointment;

namespace Nexus.Infrastructure.Persistence.Configurations.Appointment;

/// <summary>
/// Entity Framework configuration for the AppointmentHistory entity.
/// Configuración de Entity Framework para la entidad AppointmentHistory.
/// </summary>
public class AppointmentHistoryConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Appointment.AppointmentHistory>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Appointment.AppointmentHistory> builder)
    {
        builder.ToTable("appointment_histories", "appointment");

        builder.HasKey(e => e.HistoryId);
        builder.Property(e => e.OldValue).HasColumnType("jsonb");
        builder.Property(e => e.NewValue).HasColumnType("jsonb");

        builder.HasIndex(e => e.TenantId);
    }
}
