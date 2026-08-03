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
    }
}
