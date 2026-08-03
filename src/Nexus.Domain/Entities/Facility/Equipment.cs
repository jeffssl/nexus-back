using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Facility;

/// <summary>
/// Represents a piece of medical or operational equipment within a Location or Room.
/// Representa una pieza de equipamiento médico u operativo dentro de una Sede o Sala.
/// </summary>
public class Equipment
{
    /// <summary>
    /// Unique identifier for the equipment.
    /// Identificador único del equipamiento.
    /// </summary>
    public int EquipmentId { get; set; }

    /// <summary>
    /// The location where this equipment is currently placed.
    /// La sede donde este equipo está actualmente ubicado.
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// The specific room where this equipment is located (optional).
    /// La sala específica donde este equipo está ubicado (opcional).
    /// </summary>
    public int? RoomId { get; set; }

    /// <summary>
    /// The tenant this equipment belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este equipo (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The name of the equipment (e.g., MRI Scanner, Ultrasound Machine).
    /// El nombre del equipo (ej., Escáner MRI, Máquina de Ultrasonido).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Serial number of the equipment.
    /// Número de serie del equipo.
    /// </summary>
    public string? SerialNumber { get; set; }

    /// <summary>
    /// Indicates if the equipment requires regular maintenance.
    /// Indica si el equipo requiere mantenimiento regular.
    /// </summary>
    public bool RequiresMaintenance { get; set; }

    /// <summary>
    /// Indicates if the equipment is active and ready to be used.
    /// Indica si el equipo está activo y listo para ser usado.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Timestamp when the equipment was created/registered.
    /// Marca de tiempo de cuando el equipo fue creado/registrado.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
}
