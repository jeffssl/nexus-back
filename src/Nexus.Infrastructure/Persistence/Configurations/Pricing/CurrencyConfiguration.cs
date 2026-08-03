using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Pricing;

namespace Nexus.Infrastructure.Persistence.Configurations.Pricing;

public class CurrencyConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Pricing.Currency>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Pricing.Currency> builder)
    {
        builder.ToTable("currencies", "pricing");

        builder.HasKey(e => e.CurrencyCode);


        builder.HasData(
            new Currency { CurrencyCode = "USD", Name = "US Dollar", Symbol = "$", DecimalPlaces = 2 },
            new Currency { CurrencyCode = "EUR", Name = "Euro", Symbol = "€", DecimalPlaces = 2 },
            new Currency { CurrencyCode = "MXN", Name = "Mexican Peso", Symbol = "$", DecimalPlaces = 2 },
            new Currency { CurrencyCode = "COP", Name = "Colombian Peso", Symbol = "$", DecimalPlaces = 0 },
            new Currency { CurrencyCode = "PEN", Name = "Peruvian Sol", Symbol = "S/", DecimalPlaces = 2 },
            new Currency { CurrencyCode = "CLP", Name = "Chilean Peso", Symbol = "$", DecimalPlaces = 0 }
        );
    }
}
