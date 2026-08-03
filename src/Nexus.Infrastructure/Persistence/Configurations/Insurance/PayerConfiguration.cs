using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Insurance;

namespace Nexus.Infrastructure.Persistence.Configurations.Insurance;

public class PayerConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Insurance.Payer>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Insurance.Payer> builder)
    {
        builder.ToTable("payers", "insurance");

        builder.HasKey(e => e.PayerId);
    }
}
