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
    }
}
