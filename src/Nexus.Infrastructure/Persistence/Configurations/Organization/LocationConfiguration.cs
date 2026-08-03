using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Organization;

namespace Nexus.Infrastructure.Persistence.Configurations.Organization;

public class LocationConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Organization.Location>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Organization.Location> builder)
    {
        builder.ToTable("locations", "organization");

        builder.HasKey(e => e.LocationId);
    }
}
