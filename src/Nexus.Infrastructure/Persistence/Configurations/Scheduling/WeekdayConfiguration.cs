using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Infrastructure.Persistence.Configurations.Scheduling;

public class WeekdayConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Scheduling.Weekday>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Scheduling.Weekday> builder)
    {
        builder.ToTable("weekdays", "scheduling");

        builder.HasKey(e => e.WeekdayId);


        builder.HasData(
            new Weekday { WeekdayId = 1, Code = "MON", Name = "Lunes" },
            new Weekday { WeekdayId = 2, Code = "TUE", Name = "Martes" },
            new Weekday { WeekdayId = 3, Code = "WED", Name = "Miércoles" },
            new Weekday { WeekdayId = 4, Code = "THU", Name = "Jueves" },
            new Weekday { WeekdayId = 5, Code = "FRI", Name = "Viernes" },
            new Weekday { WeekdayId = 6, Code = "SAT", Name = "Sábado" },
            new Weekday { WeekdayId = 7, Code = "SUN", Name = "Domingo" }
        );
    }
}
