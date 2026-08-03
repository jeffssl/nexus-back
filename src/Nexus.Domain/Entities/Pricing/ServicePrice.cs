using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Pricing;

/// <summary>
/// Represents the price configuration for a specific service in a given price list.
/// Representa la configuración de precio para un servicio específico en una lista de precios dada.
/// </summary>
public class ServicePrice : AuditableEntity
{
    /// <summary>
    /// Unique identifier for the service price.
    /// Identificador único para el precio del servicio.
    /// </summary>
    public int ServicePriceId { get; set; }

    /// <summary>
    /// The tenant this service price belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este precio de servicio (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The price list this configuration belongs to.
    /// La lista de precios a la que pertenece esta configuración.
    /// </summary>
    public int PriceListId { get; set; }

    /// <summary>
    /// Optional specific location for this price.
    /// Sede específica opcional para este precio.
    /// </summary>
    public int? LocationId { get; set; }

    /// <summary>
    /// Optional specific specialty for this price.
    /// Especialidad específica opcional para este precio.
    /// </summary>
    public int? SpecialtyId { get; set; }

    /// <summary>
    /// The service being priced.
    /// El servicio que se está valorando.
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Optional specific practitioner for this price.
    /// Médico específico opcional para este precio.
    /// </summary>
    public Guid? PractitionerId { get; set; }

    /// <summary>
    /// The monetary value of the price.
    /// El valor monetario del precio.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Currency code (e.g., USD, MXN, EUR).
    /// Código de moneda (ej., USD, MXN, EUR).
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Validity start date (ISO 8601).
    /// Fecha de inicio de validez (ISO 8601).
    /// </summary>
    public string ValidFrom { get; set; }

    /// <summary>
    /// Validity end date (ISO 8601). Optional.
    /// Fecha de fin de validez (ISO 8601). Opcional.
    /// </summary>
    public string? ValidTo { get; set; }

    /// <summary>
    /// Indicates if the price configuration is active.
    /// Indica si la configuración de precio está activa.
    /// </summary>
    public bool IsActive { get; set; }
}
