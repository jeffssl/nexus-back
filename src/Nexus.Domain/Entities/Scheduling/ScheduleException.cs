using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Scheduling;

/// <summary>
/// Represents an exception or block in a practitioner's schedule (e.g., vacation, illness).
/// Representa una excepción o bloqueo en el horario de un médico (ej., vacaciones, enfermedad).
/// </summary>
public class ScheduleException
{
    /// <summary>
    /// Unique identifier for the schedule exception.
    /// Identificador único para la excepción de horario.
    /// </summary>
    public int ExceptionId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The specific schedule this exception applies to (if applicable).
    /// El horario específico al que aplica esta excepción (si aplica).
    /// </summary>
    public int? ScheduleId { get; set; }

    /// <summary>
    /// The practitioner affected by the exception.
    /// El médico afectado por la excepción.
    /// </summary>
    public Guid PractitionerId { get; set; }

    /// <summary>
    /// The specific location and specialty affected (if applicable).
    /// La sede y especialidad específicas afectadas (si aplica).
    /// </summary>
    public int? LocationSpecialtyId { get; set; }

    /// <summary>
    /// The date of the exception (ISO 8601).
    /// La fecha de la excepción (ISO 8601).
    /// </summary>
    public string ExceptionDate { get; set; }

    /// <summary>
    /// Indicates if the schedule is completely closed on this date.
    /// Indica si el horario está completamente cerrado en esta fecha.
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// The overridden start time for the day (if not fully closed).
    /// La hora de inicio modificada para el día (si no está completamente cerrado).
    /// </summary>
    public string? OverrideStartTime { get; set; }

    /// <summary>
    /// The overridden end time for the day (if not fully closed).
    /// La hora de fin modificada para el día (si no está completamente cerrado).
    /// </summary>
    public string? OverrideEndTime { get; set; }

    /// <summary>
    /// Reason for the exception (e.g., Vacation, Sick Leave).
    /// Motivo de la excepción (ej., Vacaciones, Licencia Médica).
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Indicates if the exception is currently active.
    /// Indica si la excepción está actualmente activa.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Timestamp when the exception was created.
    /// Marca de tiempo de cuando se creó la excepción.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
}
