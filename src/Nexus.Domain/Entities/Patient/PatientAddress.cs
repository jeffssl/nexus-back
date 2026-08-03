using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Patient;

/// <summary>
/// Represents a physical address associated with a patient.
/// Representa una dirección física asociada a un paciente.
/// </summary>
public class PatientAddress
{
    /// <summary>
    /// Unique identifier for the patient address.
    /// Identificador único de la dirección del paciente.
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// The patient this address belongs to.
    /// El paciente al que pertenece esta dirección.
    /// </summary>
    public Guid PatientId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The city of the address.
    /// La ciudad de la dirección.
    /// </summary>
    public int CityId { get; set; }

    /// <summary>
    /// First line of the address.
    /// Primera línea de la dirección.
    /// </summary>
    public string AddressLine1 { get; set; }

    /// <summary>
    /// Second line of the address (optional).
    /// Segunda línea de la dirección (opcional).
    /// </summary>
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Postal code or ZIP code.
    /// Código postal.
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// Indicates if this is the patient's primary address.
    /// Indica si esta es la dirección principal del paciente.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Indicates if the address is currently active.
    /// Indica si la dirección está actualmente activa.
    /// </summary>
    public bool IsActive { get; set; }
}
