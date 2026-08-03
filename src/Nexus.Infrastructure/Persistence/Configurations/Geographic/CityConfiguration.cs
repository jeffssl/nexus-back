using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Geographic;

namespace Nexus.Infrastructure.Persistence.Configurations.Geographic;

public class CityConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Geographic.City>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Geographic.City> builder)
    {
        builder.ToTable("cities", "geographic");

        builder.HasKey(e => e.CityId);
    }
}
