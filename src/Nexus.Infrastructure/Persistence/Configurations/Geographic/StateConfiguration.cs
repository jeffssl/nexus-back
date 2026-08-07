using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Geographic;

namespace Nexus.Infrastructure.Persistence.Configurations.Geographic;

public class StateConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Geographic.State>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Geographic.State> builder)
    {
        builder.ToTable("states", "geographic");

        builder.HasKey(e => e.StateId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Geographic.Country>().WithMany().HasForeignKey(e => e.CountryId);

        builder.HasData(
            new Nexus.Domain.Entities.Geographic.State { StateId = 1, CountryId = 1, Name = "Guayas", Code = "G", IsActive = true }
        );
    }
}
