using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Archive;

namespace Nexus.Infrastructure.Persistence.Configurations.Archive;

public class AppointmentArchiveConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Archive.AppointmentArchive>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Archive.AppointmentArchive> builder)
    {
        builder.ToTable("appointment_archives", "archive");

        builder.HasKey(e => e.AppointmentId);
        builder.Property(e => e.OriginalData).HasColumnType("jsonb");
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.ArchivedByUserId);
    }
}
