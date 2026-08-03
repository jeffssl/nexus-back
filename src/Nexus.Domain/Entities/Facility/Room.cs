using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Facility;

/// <summary>
/// Represents a physical room or space within a Location where healthcare services are provided.
/// Representa una sala o espacio físico dentro de una Sede donde se proveen servicios de salud.
/// </summary>
public class Room : AuditableEntity
{
    /// <summary>
    /// Unique identifier for the room.
    /// Identificador único del consultorio/sala.
    /// </summary>
    public int RoomId { get; set; }

    /// <summary>
    /// The location (branch) this room belongs to.
    /// La sede a la que pertenece este consultorio.
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// The tenant this room belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este consultorio (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The name of the room (e.g., Consulting Room 1, Operating Theatre A).
    /// El nombre de la sala (ej., Consultorio 1, Quirófano A).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Type of the room (e.g., Consulting, Laboratory, OperatingTheatre).
    /// Tipo de sala (ej., Consulta, Laboratorio, Quirófano).
    /// </summary>
    public string RoomType { get; set; }

    /// <summary>
    /// Maximum patient capacity for this room at a given time.
    /// Capacidad máxima de pacientes simultáneos en esta sala.
    /// </summary>
    public short Capacity { get; set; }

    /// <summary>
    /// Indicates if the room is currently active and available.
    /// Indica si la sala está activa y disponible.
    /// </summary>
    public bool IsActive { get; set; }
}
