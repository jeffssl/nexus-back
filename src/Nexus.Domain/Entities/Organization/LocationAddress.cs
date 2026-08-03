using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Organization;

/// <summary>
/// Represents a physical address for a clinic location.
/// Representa una dirección física de una sede de clínica.
/// </summary>
public class LocationAddress
{
    /// <summary>
    /// Unique identifier for the location address.
    /// Identificador único para la dirección de la sede.
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// The location this address belongs to.
    /// La sede a la que pertenece esta dirección.
    /// </summary>
    public int LocationId { get; set; }

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
    /// Neighborhood or district.
    /// Barrio o distrito.
    /// </summary>
    public string? Neighborhood { get; set; }

    /// <summary>
    /// Postal code or ZIP code.
    /// Código postal.
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// Reference or landmark.
    /// Referencia o punto de referencia.
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Geographical latitude.
    /// Latitud geográfica.
    /// </summary>
    public decimal Latitude { get; set; }

    /// <summary>
    /// Geographical longitude.
    /// Longitud geográfica.
    /// </summary>
    public decimal Longitude { get; set; }

    /// <summary>
    /// Indicates if this is the primary address.
    /// Indica si esta es la dirección principal.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Indicates if the address is currently active.
    /// Indica si la dirección está actualmente activa.
    /// </summary>
    public bool IsActive { get; set; }
}
