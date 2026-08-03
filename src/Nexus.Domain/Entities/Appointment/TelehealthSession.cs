using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Appointment;

/// <summary>
/// Represents a telehealth (virtual) session associated with an appointment.
/// Representa una sesión de telemedicina (virtual) asociada con una cita.
/// </summary>
public class TelehealthSession : AuditableEntity
{
    /// <summary>
    /// Unique identifier for the telehealth session.
    /// Identificador único de la sesión de telemedicina.
    /// </summary>
    public Guid SessionId { get; set; }

    /// <summary>
    /// The appointment this session belongs to.
    /// La cita a la que pertenece esta sesión.
    /// </summary>
    public Guid AppointmentId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The URL to join the meeting.
    /// La URL para unirse a la reunión.
    /// </summary>
    public string MeetingUrl { get; set; }

    /// <summary>
    /// Host token or passcode for the practitioner.
    /// Token de anfitrión o contraseña para el médico.
    /// </summary>
    public string? HostToken { get; set; }

    /// <summary>
    /// Guest token or passcode for the patient.
    /// Token de invitado o contraseña para el paciente.
    /// </summary>
    public string? GuestToken { get; set; }

    /// <summary>
    /// Status of the session (e.g., Scheduled, InProgress, Completed).
    /// Estado de la sesión (ej., Programada, En Progreso, Completada).
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Timestamp when the session started.
    /// Marca de tiempo de cuando inició la sesión.
    /// </summary>
    public DateTimeOffset? StartedAt { get; set; }

    /// <summary>
    /// Timestamp when the session ended.
    /// Marca de tiempo de cuando finalizó la sesión.
    /// </summary>
    public DateTimeOffset? EndedAt { get; set; }
}
