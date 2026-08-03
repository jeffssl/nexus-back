using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Geographic;

namespace Nexus.Infrastructure.Persistence.Configurations.Geographic;

public class CountryConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Geographic.Country>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Geographic.Country> builder)
    {
        builder.ToTable("countries", "geographic");

        builder.HasKey(e => e.CountryId);

        builder.Property(e => e.CountryId)
            .UseIdentityAlwaysColumn();

        builder.Property(e => e.CountryCode)
            .IsRequired()
            .HasMaxLength(2);

        builder.HasIndex(e => e.CountryCode).IsUnique();

        builder.HasData(
            new Country { CountryId = 1, CountryCode = "EC", Iso3Code = "ECU", Name = "Ecuador", PhoneCode = "+593", IsActive = true },
            new Country { CountryId = 2, CountryCode = "CO", Iso3Code = "COL", Name = "Colombia", PhoneCode = "+57", IsActive = true },
            new Country { CountryId = 3, CountryCode = "PE", Iso3Code = "PER", Name = "Perú", PhoneCode = "+51", IsActive = true },
            new Country { CountryId = 4, CountryCode = "MX", Iso3Code = "MEX", Name = "México", PhoneCode = "+52", IsActive = true },
            new Country { CountryId = 5, CountryCode = "AR", Iso3Code = "ARG", Name = "Argentina", PhoneCode = "+54", IsActive = true },
            new Country { CountryId = 6, CountryCode = "CL", Iso3Code = "CHL", Name = "Chile", PhoneCode = "+56", IsActive = true },
            new Country { CountryId = 7, CountryCode = "ES", Iso3Code = "ESP", Name = "España", PhoneCode = "+34", IsActive = true },
            new Country { CountryId = 8, CountryCode = "US", Iso3Code = "USA", Name = "Estados Unidos", PhoneCode = "+1", IsActive = true },
            new Country { CountryId = 9, CountryCode = "BR", Iso3Code = "BRA", Name = "Brasil", PhoneCode = "+55", IsActive = true },
            new Country { CountryId = 10, CountryCode = "UY", Iso3Code = "URY", Name = "Uruguay", PhoneCode = "+598", IsActive = true }
        );
    }
}
