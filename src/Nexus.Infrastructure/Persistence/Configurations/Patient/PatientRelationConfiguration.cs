using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Infrastructure.Persistence.Configurations.Patient;

/// <summary>
/// Entity Framework configuration for the PatientRelation entity.
/// Configuración de Entity Framework para la entidad PatientRelation.
/// </summary>
public class PatientRelationConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Patient.PatientRelation>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Patient.PatientRelation> builder)
    {
        builder.ToTable("patient_relations", "patient");

        builder.HasKey(e => e.RelationId);

        builder.HasIndex(e => e.TenantId);
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.PrimaryPatientId);
        builder.HasOne<Nexus.Domain.Entities.Organization.Organization>().WithMany().HasForeignKey(e => e.TenantId);
        builder.HasOne<Nexus.Domain.Entities.Patient.Patient>().WithMany().HasForeignKey(e => e.DependentPatientId);
    }
}
