using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

public class PaymentConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.Payment>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.Payment> builder)
    {
        builder.ToTable("payments", "billing");

        builder.HasKey(e => e.PaymentId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Billing.Invoice>().WithMany().HasForeignKey(e => e.InvoiceId);
        builder.HasOne<Nexus.Domain.Entities.Pricing.Currency>().WithMany().HasForeignKey(e => e.CurrencyCode);
        builder.HasOne<Nexus.Domain.Entities.Billing.PaymentMethod>().WithMany().HasForeignKey(e => e.PaymentMethodId);
        builder.HasOne<Nexus.Domain.Entities.Billing.PaymentStatus>().WithMany().HasForeignKey(e => e.StatusCode);
        builder.HasOne<Nexus.Domain.Entities.Patient.PatientInsurance>().WithMany().HasForeignKey(e => e.PatientInsuranceId);
        builder.HasOne<Nexus.Domain.Entities.System.User>().WithMany().HasForeignKey(e => e.CreatedBy);
    }
}
