using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Scheduling;

/// <summary>
/// Represents a patient waiting for an available appointment slot.
/// Representa a un paciente en lista de espera para un turno de cita disponible.
/// </summary>
public class Waitlist : AuditableEntity
{
    /// <summary>
    /// Unique identifier for the waitlist entry.
    /// Identificador único para el registro de la lista de espera.
    /// </summary>
    public int WaitlistId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The patient waiting for an appointment.
    /// El paciente que espera una cita.
    /// </summary>
    public Guid PatientId { get; set; }

    /// <summary>
    /// The specific practitioner requested (optional).
    /// El médico específico solicitado (opcional).
    /// </summary>
    public Guid? PractitionerId { get; set; }

    /// <summary>
    /// The specialty requested.
    /// La especialidad solicitada.
    /// </summary>
    public int SpecialtyId { get; set; }

    /// <summary>
    /// Preferred start date for the appointment (ISO 8601).
    /// Fecha de inicio preferida para la cita (ISO 8601).
    /// </summary>
    public string PreferredDateFrom { get; set; }

    /// <summary>
    /// Preferred end date for the appointment (ISO 8601).
    /// Fecha de fin preferida para la cita (ISO 8601).
    /// </summary>
    public string PreferredDateTo { get; set; }

    /// <summary>
    /// Current status of the waitlist entry (e.g., Pending, Fulfilled, Cancelled).
    /// Estado actual de la entrada en lista de espera (ej., Pendiente, Cumplido, Cancelado).
    /// </summary>
    public string Status { get; set; }
}
