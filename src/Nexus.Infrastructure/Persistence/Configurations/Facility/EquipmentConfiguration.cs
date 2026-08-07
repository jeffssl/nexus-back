using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Facility;

namespace Nexus.Infrastructure.Persistence.Configurations.Facility;

/// <summary>
/// Entity Framework configuration for the Equipment entity.
/// Configuración de Entity Framework para la entidad Equipment.
/// </summary>
public class EquipmentConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Facility.Equipment>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Facility.Equipment> builder)
    {
        builder.ToTable("equipments", "facility");

        builder.HasKey(e => e.EquipmentId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Location>().WithMany().HasForeignKey(e => e.LocationId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Facility.Room>().WithMany().HasForeignKey(e => e.RoomId);
    }
}
