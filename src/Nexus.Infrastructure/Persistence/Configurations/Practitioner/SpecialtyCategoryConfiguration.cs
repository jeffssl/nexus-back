using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Practitioner;

namespace Nexus.Infrastructure.Persistence.Configurations.Practitioner;

public class SpecialtyCategoryConfiguration : IEntityTypeConfiguration<SpecialtyCategory>
{
    public void Configure(EntityTypeBuilder<SpecialtyCategory> builder)
    {
        builder.ToTable("specialty_categories", "practitioner");

        builder.HasKey(e => e.CategoryId);

        builder.Property(e => e.CategoryId)
            .UseIdentityAlwaysColumn();

        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.NameEs)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.NameEn)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(e => e.Code)
            .IsUnique();

        builder.HasData(
            new SpecialtyCategory { CategoryId = 1, Code = "MEDICINA", NameEs = "Medicina", NameEn = "Medicine", IsActive = true },
            new SpecialtyCategory { CategoryId = 2, Code = "CIRUGIA", NameEs = "Cirugía", NameEn = "Surgery", IsActive = true },
            new SpecialtyCategory { CategoryId = 3, Code = "DIAGNOSTICO", NameEs = "Diagnóstico", NameEn = "Diagnostics", IsActive = true },
            new SpecialtyCategory { CategoryId = 4, Code = "SALUD_MENTAL", NameEs = "Salud Mental", NameEn = "Mental Health", IsActive = true },
            new SpecialtyCategory { CategoryId = 5, Code = "REHABILITACION", NameEs = "Rehabilitación", NameEn = "Rehabilitation", IsActive = true },
            new SpecialtyCategory { CategoryId = 6, Code = "ODONTOLOGIA", NameEs = "Odontología", NameEn = "Dentistry", IsActive = true },
            new SpecialtyCategory { CategoryId = 7, Code = "TERAPIAS", NameEs = "Terapias", NameEn = "Therapies", IsActive = true },
            new SpecialtyCategory { CategoryId = 8, Code = "OTRAS", NameEs = "Otras", NameEn = "Other", IsActive = true }
        );
    }
}
