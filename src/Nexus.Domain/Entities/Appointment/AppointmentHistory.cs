using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Appointment;

/// <summary>
/// Represents the history of changes made to an appointment.
/// Representa el historial de cambios realizados en una cita.
/// </summary>
public class AppointmentHistory
{
    /// <summary>
    /// Unique identifier for the history record.
    /// Identificador único para el registro de historial.
    /// </summary>
    public int HistoryId { get; set; }

    /// <summary>
    /// The appointment this history belongs to.
    /// La cita a la que pertenece este historial.
    /// </summary>
    public Guid AppointmentId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Timestamp when the change occurred.
    /// Marca de tiempo de cuando ocurrió el cambio.
    /// </summary>
    public DateTimeOffset ChangedAt { get; set; }

    /// <summary>
    /// User who made the change.
    /// Usuario que realizó el cambio.
    /// </summary>
    public Guid? ChangedByUserId { get; set; }

    /// <summary>
    /// Type of change (e.g., Status, Reschedule).
    /// Tipo de cambio (ej., Estado, Reprogramación).
    /// </summary>
    public string ChangeType { get; set; }

    /// <summary>
    /// Previous value before the change.
    /// Valor anterior al cambio.
    /// </summary>
    public string? OldValue { get; set; }

    /// <summary>
    /// New value after the change.
    /// Nuevo valor tras el cambio.
    /// </summary>
    public string? NewValue { get; set; }

    /// <summary>
    /// Additional notes regarding the change.
    /// Notas adicionales sobre el cambio.
    /// </summary>
    public string? Notes { get; set; }
}
