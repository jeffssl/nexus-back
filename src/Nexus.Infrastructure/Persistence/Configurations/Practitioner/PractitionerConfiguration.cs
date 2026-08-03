using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Practitioner;

namespace Nexus.Infrastructure.Persistence.Configurations.Practitioner;

public class PractitionerConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Practitioner.Practitioner>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Practitioner.Practitioner> builder)
    {
        builder.ToTable("practitioners", "practitioner");

        builder.HasKey(e => e.PractitionerId);
    }
}
