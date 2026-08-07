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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Practitioner>().WithMany().HasForeignKey(e => e.PractitionerId);
        builder.HasOne<Nexus.Domain.Entities.Organization.LocationSpecialty>().WithMany().HasForeignKey(e => e.LocationSpecialtyId);
        builder.HasOne<Nexus.Domain.Entities.Facility.Room>().WithMany().HasForeignKey(e => e.RoomId);
        builder.HasOne<Nexus.Domain.Entities.Scheduling.Weekday>().WithMany().HasForeignKey(e => e.WeekdayId);
    }
}
