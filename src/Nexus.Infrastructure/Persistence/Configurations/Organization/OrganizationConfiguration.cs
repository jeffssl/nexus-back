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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Geographic.DocumentType>().WithMany().HasForeignKey(e => e.DocumentTypeId);
        builder.HasOne<Nexus.Domain.Entities.Organization.OrganizationType>().WithMany().HasForeignKey(e => e.OrganizationTypeId);
        builder.HasOne<Nexus.Domain.Entities.Geographic.Country>().WithMany().HasForeignKey(e => e.CountryId);
    }
}
