using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Infrastructure.Persistence.Configurations.Scheduling;

/// <summary>
/// Entity Framework configuration for the ScheduleException entity.
/// Configuración de Entity Framework para la entidad ScheduleException.
/// </summary>
public class ScheduleExceptionConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Scheduling.ScheduleException>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Scheduling.ScheduleException> builder)
    {
        builder.ToTable("schedule_exceptions", "scheduling");

        builder.HasKey(e => e.ExceptionId);

        builder.HasIndex(e => e.TenantId);
    }
}
