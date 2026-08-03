using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Appointment;

/// <summary>
/// Represents clinical details and notes for an appointment.
/// Representa detalles y notas clínicas de una cita.
/// </summary>
public class AppointmentClinicalDetail : AuditableEntity
{
    /// <summary>
    /// Unique identifier for the clinical detail record.
    /// Identificador único del registro de detalle clínico.
    /// </summary>
    public Guid ClinicalDetailId { get; set; }

    /// <summary>
    /// The appointment this detail belongs to.
    /// La cita a la que pertenece este detalle.
    /// </summary>
    public Guid AppointmentId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Notes provided by the patient.
    /// Notas proporcionadas por el paciente.
    /// </summary>
    public string? PatientNotes { get; set; }

    /// <summary>
    /// Internal notes for the clinic staff.
    /// Notas internas para el personal de la clínica.
    /// </summary>
    public string? InternalNotes { get; set; }
}
