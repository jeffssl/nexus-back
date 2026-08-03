using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Infrastructure.Persistence.Configurations.Scheduling;

/// <summary>
/// Entity Framework configuration for the Waitlist entity.
/// Configuración de Entity Framework para la entidad Waitlist.
/// </summary>
public class WaitlistConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Scheduling.Waitlist>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Scheduling.Waitlist> builder)
    {
        builder.ToTable("waitlists", "scheduling");

        builder.HasKey(e => e.WaitlistId);

        builder.HasIndex(e => e.TenantId);
    }
}
