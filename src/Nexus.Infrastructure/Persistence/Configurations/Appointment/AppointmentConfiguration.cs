using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Appointment;

namespace Nexus.Infrastructure.Persistence.Configurations.Appointment;

public class AppointmentConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Appointment.Appointment>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Appointment.Appointment> builder)
    {
        builder.ToTable("appointments", "appointment");

        builder.HasKey(e => e.AppointmentId);
        builder.HasIndex(e => e.AppointmentNumber).IsUnique();
        builder.HasIndex(e => e.SlotId).IsUnique();
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.PatientId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Practitioner>().WithMany().HasForeignKey(e => e.PractitionerId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Location>().WithMany().HasForeignKey(e => e.LocationId);
        builder.HasOne<Nexus.Domain.Entities.Practitioner.Specialty>().WithMany().HasForeignKey(e => e.SpecialtyId);
        builder.HasOne<Nexus.Domain.Entities.Pricing.Service>().WithMany().HasForeignKey(e => e.ServiceId);
        builder.HasOne<Nexus.Domain.Entities.Scheduling.Slot>().WithMany().HasForeignKey(e => e.SlotId);
        builder.HasOne<Nexus.Domain.Entities.Appointment.AppointmentStatus>().WithMany().HasForeignKey(e => e.StatusCode);
        builder.HasOne<Nexus.Domain.Entities.Patient.PatientInsurance>().WithMany().HasForeignKey(e => e.PatientInsuranceId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.BookedByUserId);
        builder.HasOne<Nexus.Domain.Entities.Appointment.CancellationReason>().WithMany().HasForeignKey(e => e.CancellationReasonId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.CreatedBy);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UpdatedBy);
    }
}
