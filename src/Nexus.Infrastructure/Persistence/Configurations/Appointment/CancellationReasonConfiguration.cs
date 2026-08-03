using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Appointment;

namespace Nexus.Infrastructure.Persistence.Configurations.Appointment;

public class CancellationReasonConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Appointment.CancellationReason>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Appointment.CancellationReason> builder)
    {
        builder.ToTable("cancellation_reasons", "appointment");

        builder.HasKey(e => e.ReasonId);


        builder.HasData(
            new CancellationReason { ReasonId = 1, Code = "PATIENT_REQUEST", Name = "Solicitado por el paciente", RequiresRefund = true, IsActive = true },
            new CancellationReason { ReasonId = 2, Code = "CLINIC_REQUEST", Name = "Fuerza mayor / Clínica", RequiresRefund = true, IsActive = true },
            new CancellationReason { ReasonId = 3, Code = "NO_SHOW", Name = "Inasistencia", RequiresRefund = false, IsActive = true },
            new CancellationReason { ReasonId = 4, Code = "RESCHEDULED", Name = "Reagendamiento", RequiresRefund = false, IsActive = true }
        );
    }
}
