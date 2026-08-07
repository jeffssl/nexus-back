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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Geographic.State>().WithMany().HasForeignKey(e => e.StateId);

        builder.HasData(
            new Nexus.Domain.Entities.Geographic.City { CityId = 1, StateId = 1, Name = "Guayaquil", IsActive = true }
        );
    }
}
