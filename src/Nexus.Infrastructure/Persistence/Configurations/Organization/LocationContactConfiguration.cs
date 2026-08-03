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
    }
}
