using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Practitioner;

/// <summary>
/// Associates a practitioner with a medical specialty.
/// Asocia a un médico con una especialidad médica.
/// </summary>
public class PractitionerSpecialty
{
    /// <summary>
    /// Unique identifier for the practitioner-specialty association.
    /// Identificador único para la asociación médico-especialidad.
    /// </summary>
    public int PractitionerSpecialtyId { get; set; }

    /// <summary>
    /// The practitioner being associated.
    /// El médico que se está asociando.
    /// </summary>
    public Guid PractitionerId { get; set; }

    /// <summary>
    /// The specialty associated with the practitioner.
    /// La especialidad asociada al médico.
    /// </summary>
    public int SpecialtyId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Indicates if this is the practitioner's primary specialty.
    /// Indica si esta es la especialidad principal del médico.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Date when the practitioner was certified in this specialty (ISO 8601).
    /// Fecha en la que el médico se certificó en esta especialidad (ISO 8601).
    /// </summary>
    public string? CertificationDate { get; set; }

    /// <summary>
    /// Indicates if the association is currently active.
    /// Indica si la asociación está actualmente activa.
    /// </summary>
    public bool IsActive { get; set; }
}
