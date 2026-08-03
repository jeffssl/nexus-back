using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Organization;

namespace Nexus.Infrastructure.Persistence.Configurations.Organization;

public class OrganizationConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Organization.Organization>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Organization.Organization> builder)
    {
        builder.ToTable("organizations", "organization");

        builder.HasKey(e => e.OrganizationId);
        
        builder.HasIndex(e => e.TaxId).IsUnique();
    }
}
