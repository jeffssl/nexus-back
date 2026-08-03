using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Patient;

/// <summary>
/// Represents a consent or agreement signed by the patient.
/// Representa un consentimiento o acuerdo firmado por el paciente.
/// </summary>
public class PatientConsent
{
    /// <summary>
    /// Unique identifier for the consent record.
    /// Identificador único del registro de consentimiento.
    /// </summary>
    public Guid ConsentId { get; set; }

    /// <summary>
    /// The patient who gave the consent.
    /// El paciente que dio el consentimiento.
    /// </summary>
    public Guid PatientId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Optional appointment associated with this consent.
    /// Cita opcional asociada con este consentimiento.
    /// </summary>
    public Guid? AppointmentId { get; set; }

    /// <summary>
    /// Type of consent (e.g., General, Surgical, DataPrivacy).
    /// Tipo de consentimiento (ej., General, Quirúrgico, Privacidad de Datos).
    /// </summary>
    public string ConsentType { get; set; }

    /// <summary>
    /// URL or path to the signed document.
    /// URL o ruta al documento firmado.
    /// </summary>
    public string? DocumentUrl { get; set; }

    /// <summary>
    /// Timestamp when the consent was agreed upon.
    /// Marca de tiempo de cuando se aceptó el consentimiento.
    /// </summary>
    public DateTimeOffset AgreedAt { get; set; }

    /// <summary>
    /// IP address from where the consent was given.
    /// Dirección IP desde donde se dio el consentimiento.
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Indicates if the consent is currently active.
    /// Indica si el consentimiento está actualmente activo.
    /// </summary>
    public bool IsActive { get; set; }
}
