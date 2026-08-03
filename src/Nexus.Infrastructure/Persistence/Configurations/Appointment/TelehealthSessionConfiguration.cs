using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Appointment;

namespace Nexus.Infrastructure.Persistence.Configurations.Appointment;

/// <summary>
/// Entity Framework configuration for the TelehealthSession entity.
/// Configuración de Entity Framework para la entidad TelehealthSession.
/// </summary>
public class TelehealthSessionConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Appointment.TelehealthSession>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Appointment.TelehealthSession> builder)
    {
        builder.ToTable("telehealth_sessions", "appointment");

        builder.HasKey(e => e.SessionId);
        builder.HasIndex(e => e.AppointmentId).IsUnique();

        builder.HasIndex(e => e.TenantId);
    }
}
