using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Patient;

/// <summary>
/// Represents a relationship between two patients (e.g., Parent/Child, Guardian).
/// Representa una relación entre dos pacientes (ej., Padre/Hijo, Tutor).
/// </summary>
public class PatientRelation
{
    /// <summary>
    /// Unique identifier for the relation.
    /// Identificador único para la relación.
    /// </summary>
    public Guid RelationId { get; set; }

    /// <summary>
    /// The primary patient (e.g., the parent).
    /// El paciente principal (ej., el padre).
    /// </summary>
    public Guid PrimaryPatientId { get; set; }

    /// <summary>
    /// The dependent patient (e.g., the child).
    /// El paciente dependiente (ej., el hijo).
    /// </summary>
    public Guid DependentPatientId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Type of relationship (e.g., Parent, Spouse, Guardian).
    /// Tipo de relación (ej., Padre, Cónyuge, Tutor).
    /// </summary>
    public string RelationshipType { get; set; }

    /// <summary>
    /// Indicates if the primary patient can book appointments for the dependent.
    /// Indica si el paciente principal puede agendar citas para el dependiente.
    /// </summary>
    public bool CanBookAppointments { get; set; }

    /// <summary>
    /// Indicates if the primary patient can access the dependent's medical records.
    /// Indica si el paciente principal puede acceder a los registros médicos del dependiente.
    /// </summary>
    public bool CanAccessMedicalRecords { get; set; }

    /// <summary>
    /// Indicates if this relationship is active.
    /// Indica si esta relación está activa.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Timestamp when the relationship was created.
    /// Marca de tiempo de cuando se creó la relación.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
}
