using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Appointment;

namespace Nexus.Infrastructure.Persistence.Configurations.Appointment;

public class AppointmentConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Appointment.Appointment>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Appointment.Appointment> builder)
    {
        builder.ToTable("appointments", "appointment");

        builder.HasKey(e => e.AppointmentId);
        builder.HasIndex(e => e.AppointmentNumber).IsUnique();
        builder.HasIndex(e => e.SlotId).IsUnique();
    }
}
