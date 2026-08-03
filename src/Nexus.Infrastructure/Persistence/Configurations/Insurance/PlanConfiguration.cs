using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Insurance;

namespace Nexus.Infrastructure.Persistence.Configurations.Insurance;

public class PlanConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Insurance.Plan>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Insurance.Plan> builder)
    {
        builder.ToTable("plans", "insurance");

        builder.HasKey(e => e.PlanId);
    }
}
