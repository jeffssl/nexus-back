using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Organization;

namespace Nexus.Infrastructure.Persistence.Configurations.Organization;

public class OrganizationTypeConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Organization.OrganizationType>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Organization.OrganizationType> builder)
    {
        builder.ToTable("organization_types", "organization");

        builder.HasKey(e => e.TypeId);


        builder.HasData(
            new OrganizationType { TypeId = 1, Code = "CLINIC", Name = "Clínica", IsActive = true },
            new OrganizationType { TypeId = 2, Code = "HOSPITAL", Name = "Hospital", IsActive = true },
            new OrganizationType { TypeId = 3, Code = "LAB", Name = "Laboratorio Clínico", IsActive = true },
            new OrganizationType { TypeId = 4, Code = "IMAGING_CENTER", Name = "Centro de Imágenes", IsActive = true },
            new OrganizationType { TypeId = 5, Code = "DENTAL", Name = "Clínica Dental", IsActive = true }
        );
    }
}
