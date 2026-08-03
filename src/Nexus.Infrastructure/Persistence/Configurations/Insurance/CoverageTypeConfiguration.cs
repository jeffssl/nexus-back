using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Insurance;

namespace Nexus.Infrastructure.Persistence.Configurations.Insurance;

public class CoverageTypeConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Insurance.CoverageType>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Insurance.CoverageType> builder)
    {
        builder.ToTable("coverage_types", "insurance");

        builder.HasKey(e => e.TypeId);


        builder.HasData(
            new CoverageType { TypeId = 1, Code = "MEDICAL", Name = "Médica", IsActive = true },
            new CoverageType { TypeId = 2, Code = "DENTAL", Name = "Dental", IsActive = true },
            new CoverageType { TypeId = 3, Code = "VISION", Name = "Visual", IsActive = true },
            new CoverageType { TypeId = 4, Code = "PHARMACY", Name = "Farmacéutica", IsActive = true }
        );
    }
}
