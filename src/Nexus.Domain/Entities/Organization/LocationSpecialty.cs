using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Organization;

/// <summary>
/// Associates a medical specialty with a specific location.
/// Asocia una especialidad médica con una sede específica.
/// </summary>
public class LocationSpecialty
{
    /// <summary>
    /// Unique identifier for the location-specialty association.
    /// Identificador único de la asociación sede-especialidad.
    /// </summary>
    public int LocationSpecialtyId { get; set; }

    /// <summary>
    /// The location being associated.
    /// La sede que se está asociando.
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// The specialty available at this location.
    /// La especialidad disponible en esta sede.
    /// </summary>
    public int SpecialtyId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Indicates if the specialty is currently active at this location.
    /// Indica si la especialidad está actualmente activa en esta sede.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Timestamp when the specialty was activated at this location.
    /// Marca de tiempo de cuando se activó la especialidad en esta sede.
    /// </summary>
    public DateTimeOffset ActivatedAt { get; set; }
}
