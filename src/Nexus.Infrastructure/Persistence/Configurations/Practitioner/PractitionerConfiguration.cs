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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Geographic.DocumentType>().WithMany().HasForeignKey(e => e.DocumentTypeId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UserId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.CreatedBy);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UpdatedBy);
    }
}
