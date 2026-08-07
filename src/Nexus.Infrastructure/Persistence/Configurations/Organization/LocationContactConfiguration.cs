using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Organization;

namespace Nexus.Infrastructure.Persistence.Configurations.Organization;

/// <summary>
/// Entity Framework configuration for the LocationContact entity.
/// Configuración de Entity Framework para la entidad LocationContact.
/// </summary>
public class LocationContactConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Organization.LocationContact>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Organization.LocationContact> builder)
    {
        builder.ToTable("location_contacts", "organization");

        builder.HasKey(e => e.ContactId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Location>().WithMany().HasForeignKey(e => e.LocationId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.System.ContactType>().WithMany().HasForeignKey(e => e.ContactTypeId);
    }
}
