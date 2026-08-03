using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Billing;

namespace Nexus.Infrastructure.Persistence.Configurations.Billing;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Billing.PaymentMethod>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Billing.PaymentMethod> builder)
    {
        builder.ToTable("payment_methods", "billing");

        builder.HasKey(e => e.MethodId);


        builder.HasData(
            new PaymentMethod { MethodId = 1, Code = "CASH", Name = "Efectivo", RequiresGateway = false, IsActive = true },
            new PaymentMethod { MethodId = 2, Code = "CREDIT_CARD", Name = "Tarjeta de Crédito", RequiresGateway = true, IsActive = true },
            new PaymentMethod { MethodId = 3, Code = "DEBIT_CARD", Name = "Tarjeta de Débito", RequiresGateway = true, IsActive = true },
            new PaymentMethod { MethodId = 4, Code = "BANK_TRANSFER", Name = "Transferencia Bancaria", RequiresGateway = false, IsActive = true },
            new PaymentMethod { MethodId = 5, Code = "INSURANCE", Name = "Seguro Médico", RequiresGateway = false, IsActive = true }
        );
    }
}
