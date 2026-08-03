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
    }
}
