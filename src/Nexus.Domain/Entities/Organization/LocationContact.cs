using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Organization;

/// <summary>
/// Represents a contact method for a clinic location.
/// Representa un método de contacto para una sede de clínica.
/// </summary>
public class LocationContact
{
    /// <summary>
    /// Unique identifier for the location contact.
    /// Identificador único para el contacto de la sede.
    /// </summary>
    public int ContactId { get; set; }

    /// <summary>
    /// The location this contact belongs to.
    /// La sede a la que pertenece este contacto.
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Type of contact (e.g., Phone, Email).
    /// Tipo de contacto (ej., Teléfono, Email).
    /// </summary>
    public int ContactTypeId { get; set; }

    /// <summary>
    /// The actual contact value (e.g., phone number or email address).
    /// El valor real del contacto (ej., número de teléfono o correo electrónico).
    /// </summary>
    public string ContactValue { get; set; }

    /// <summary>
    /// Purpose of this contact (e.g., General Inquiries, Emergency).
    /// Propósito de este contacto (ej., Consultas Generales, Emergencia).
    /// </summary>
    public string? Purpose { get; set; }

    /// <summary>
    /// Indicates if this is the primary contact for the location.
    /// Indica si este es el contacto principal de la sede.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Indicates if the contact is active.
    /// Indica si el contacto está activo.
    /// </summary>
    public bool IsActive { get; set; }
}
