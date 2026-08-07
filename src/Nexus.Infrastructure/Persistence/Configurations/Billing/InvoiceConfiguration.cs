using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

public class InvoiceConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.Invoice>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.Invoice> builder)
    {
        builder.ToTable("invoices", "billing");

        builder.HasKey(e => e.InvoiceId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Appointment.Appointment>().WithMany().HasForeignKey(e => e.AppointmentId);
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.PatientId);
        builder.HasOne<Nexus.Domain.Entities.Pricing.Currency>().WithMany().HasForeignKey(e => e.CurrencyCode);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.CreatedBy);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.UpdatedBy);
    }
}
