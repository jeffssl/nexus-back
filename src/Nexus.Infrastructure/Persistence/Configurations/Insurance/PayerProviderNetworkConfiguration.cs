using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Insurance;

namespace Nexus.Infrastructure.Persistence.Configurations.Insurance;

public class PayerProviderNetworkConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Insurance.PayerProviderNetwork>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Insurance.PayerProviderNetwork> builder)
    {
        builder.ToTable("payer_provider_networks", "insurance");

        builder.HasKey(e => e.NetworkId);
    }
}
