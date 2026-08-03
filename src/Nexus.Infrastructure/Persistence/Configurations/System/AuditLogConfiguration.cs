using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.System;

namespace Nexus.Infrastructure.Persistence.Configurations.System;

public class AuditLogConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.System.AuditLog>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.System.AuditLog> builder)
    {
        builder.ToTable("audit_logs", "system");

        builder.HasKey(e => e.AuditLogId);
        builder.Property(e => e.OldValues).HasColumnType("jsonb");
        builder.Property(e => e.NewValues).HasColumnType("jsonb");
    }
}
