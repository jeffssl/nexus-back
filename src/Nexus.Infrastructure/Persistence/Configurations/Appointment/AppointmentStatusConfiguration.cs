using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Appointment;

namespace Nexus.Infrastructure.Persistence.Configurations.Appointment;

public class AppointmentStatusConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Appointment.AppointmentStatus>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Appointment.AppointmentStatus> builder)
    {
        builder.ToTable("appointment_statuses", "appointment");

        builder.HasKey(e => e.StatusCode);


        builder.HasData(
            new AppointmentStatus { StatusCode = "SCHEDULED", Name = "Agendada", IsFinal = false, AllowedTransitions = "CONFIRMED,IN_PROGRESS,CANCELLED,NO_SHOW" },
            new AppointmentStatus { StatusCode = "CONFIRMED", Name = "Confirmada", IsFinal = false, AllowedTransitions = "IN_PROGRESS,CANCELLED,NO_SHOW" },
            new AppointmentStatus { StatusCode = "IN_PROGRESS", Name = "En Progreso", IsFinal = false, AllowedTransitions = "COMPLETED" },
            new AppointmentStatus { StatusCode = "COMPLETED", Name = "Completada", IsFinal = true },
            new AppointmentStatus { StatusCode = "CANCELLED", Name = "Cancelada", IsFinal = true },
            new AppointmentStatus { StatusCode = "NO_SHOW", Name = "No se presentó", IsFinal = true }
        );
    }
}
