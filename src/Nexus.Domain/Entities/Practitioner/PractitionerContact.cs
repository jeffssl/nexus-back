using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Practitioner;

/// <summary>
/// Represents a contact method (phone, email) for a practitioner.
/// Representa un método de contacto (teléfono, email) para un médico.
/// </summary>
public class PractitionerContact
{
    /// <summary>
    /// Unique identifier for the practitioner contact.
    /// Identificador único del contacto del médico.
    /// </summary>
    public int PractitionerContactId { get; set; }

    /// <summary>
    /// The practitioner this contact belongs to.
    /// El médico al que pertenece este contacto.
    /// </summary>
    public Guid PractitionerId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Type of contact (e.g., Mobile, Email, Office Phone).
    /// Tipo de contacto (ej., Móvil, Email, Teléfono de Oficina).
    /// </summary>
    public int ContactTypeId { get; set; }

    /// <summary>
    /// The actual contact value (e.g., phone number or email address).
    /// El valor real del contacto (ej., número de teléfono o correo electrónico).
    /// </summary>
    public string ContactValue { get; set; }

    /// <summary>
    /// Purpose of this contact.
    /// Propósito de este contacto.
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
