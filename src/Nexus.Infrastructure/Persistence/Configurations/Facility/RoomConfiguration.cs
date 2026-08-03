using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Facility;

namespace Nexus.Infrastructure.Persistence.Configurations.Facility;

/// <summary>
/// Entity Framework configuration for the Room entity.
/// Configuración de Entity Framework para la entidad Room.
/// </summary>
public class RoomConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Facility.Room>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Facility.Room> builder)
    {
        builder.ToTable("rooms", "facility");

        builder.HasKey(e => e.RoomId);

        builder.HasIndex(e => e.TenantId);
    }
}
