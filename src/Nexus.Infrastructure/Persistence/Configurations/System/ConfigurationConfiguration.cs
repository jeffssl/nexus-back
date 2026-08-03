using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.System;

namespace Nexus.Infrastructure.Persistence.Configurations.System;

public class ConfigurationConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.System.Configuration>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.System.Configuration> builder)
    {
        builder.ToTable("configurations", "system");

        builder.HasKey(e => e.ConfigKey);
    }
}
