using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Infrastructure.Persistence.Configurations.Scheduling;

public class PractitionerScheduleConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Scheduling.PractitionerSchedule>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Scheduling.PractitionerSchedule> builder)
    {
        builder.ToTable("practitioner_schedules", "scheduling");

        builder.HasKey(e => e.ScheduleId);
    }
}
