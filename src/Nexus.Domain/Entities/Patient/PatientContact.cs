using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Patient;

/// <summary>
/// Represents a contact method (phone, email) for a patient.
/// Representa un método de contacto (teléfono, email) para un paciente.
/// </summary>
public class PatientContact
{
    /// <summary>
    /// Unique identifier for the patient contact.
    /// Identificador único del contacto del paciente.
    /// </summary>
    public int PatientContactId { get; set; }

    /// <summary>
    /// The patient this contact belongs to.
    /// El paciente al que pertenece este contacto.
    /// </summary>
    public Guid PatientId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Type of contact (e.g., Mobile, Email, Home Phone).
    /// Tipo de contacto (ej., Móvil, Email, Teléfono de Casa).
    /// </summary>
    public int ContactTypeId { get; set; }

    /// <summary>
    /// The actual contact value (e.g., phone number or email address).
    /// El valor real del contacto (ej., número de teléfono o correo electrónico).
    /// </summary>
    public string ContactValue { get; set; }

    /// <summary>
    /// Purpose of this contact (e.g., Emergency, Billing).
    /// Propósito de este contacto (ej., Emergencia, Facturación).
    /// </summary>
    public string? Purpose { get; set; }

    /// <summary>
    /// Indicates if this is the primary contact method.
    /// Indica si este es el método de contacto principal.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Indicates if the contact is active.
    /// Indica si el contacto está activo.
    /// </summary>
    public bool IsActive { get; set; }
}
