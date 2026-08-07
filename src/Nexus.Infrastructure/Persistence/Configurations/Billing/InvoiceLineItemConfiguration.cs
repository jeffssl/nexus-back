using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

/// <summary>
/// Entity Framework configuration for the InvoiceLineItem entity.
/// Configuración de Entity Framework para la entidad InvoiceLineItem.
/// </summary>
public class InvoiceLineItemConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.InvoiceLineItem>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.InvoiceLineItem> builder)
    {
        builder.ToTable("invoice_line_items", "billing");

        builder.HasKey(e => e.LineItemId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Billing.Invoice>().WithMany().HasForeignKey(e => e.InvoiceId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Pricing.Service>().WithMany().HasForeignKey(e => e.ServiceId);
    }
}
