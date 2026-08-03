using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Practitioner;

/// <summary>
/// Associates a practitioner with a specific location where they work.
/// Asocia a un médico con una sede específica donde trabaja.
/// </summary>
public class PractitionerLocation
{
    /// <summary>
    /// Unique identifier for the practitioner-location association.
    /// Identificador único de la asociación médico-sede.
    /// </summary>
    public int PractitionerLocationId { get; set; }

    /// <summary>
    /// The practitioner being associated.
    /// El médico que se está asociando.
    /// </summary>
    public Guid PractitionerId { get; set; }

    /// <summary>
    /// The location where the practitioner works.
    /// La sede donde trabaja el médico.
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Indicates if this is the practitioner's primary location.
    /// Indica si esta es la sede principal del médico.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Start date of this association (ISO 8601).
    /// Fecha de inicio de esta asociación (ISO 8601).
    /// </summary>
    public string StartDate { get; set; }

    /// <summary>
    /// End date of this association (ISO 8601).
    /// Fecha de fin de esta asociación (ISO 8601).
    /// </summary>
    public string? EndDate { get; set; }

    /// <summary>
    /// Indicates if the association is currently active.
    /// Indica si la asociación está actualmente activa.
    /// </summary>
    public bool IsActive { get; set; }
}
