using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.System;

namespace Nexus.Infrastructure.Persistence.Configurations.System;

public class UserConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.System.User>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.System.User> builder)
    {
        builder.ToTable("users", "system");

        builder.HasKey(e => e.UserId);
        builder.HasIndex(e => e.Email).IsUnique();
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.CreatedBy);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UpdatedBy);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.DeletedBy);
    }
}
