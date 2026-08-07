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
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Insurance.Payer>().WithMany().HasForeignKey(e => e.PayerId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.OrganizationId);
    }
}
