using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Pricing;

namespace Nexus.Infrastructure.Persistence.Configurations.Pricing;

public class ServiceConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Pricing.Service>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Pricing.Service> builder)
    {
        builder.ToTable("services", "pricing");

        builder.HasKey(e => e.ServiceId);


        builder.HasData(
            new Service { ServiceId = 1, Code = "GENERAL_CONSULTATION", Name = "Consulta Médica General", DefaultDurationMinutes = 30, RequiresPreAuth = false, IsActive = true },
            new Service { ServiceId = 2, Code = "SPECIALIST_CONSULTATION", Name = "Consulta de Especialidad", DefaultDurationMinutes = 45, RequiresPreAuth = false, IsActive = true },
            new Service { ServiceId = 3, Code = "FOLLOW_UP", Name = "Consulta de Seguimiento", DefaultDurationMinutes = 15, RequiresPreAuth = false, IsActive = true }
        );
    }
}
