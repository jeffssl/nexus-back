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
    }
}
