using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Infrastructure.Persistence.Configurations.Scheduling;

public class SlotConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Scheduling.Slot>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Scheduling.Slot> builder)
    {
        builder.ToTable("slots", "scheduling");

        builder.HasKey(e => e.SlotId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Practitioner>().WithMany().HasForeignKey(e => e.PractitionerId);
        builder.HasOne<Nexus.Domain.Entities.Organization.LocationSpecialty>().WithMany().HasForeignKey(e => e.LocationSpecialtyId);
        builder.HasOne<Nexus.Domain.Entities.Facility.Room>().WithMany().HasForeignKey(e => e.RoomId);
    }
}
