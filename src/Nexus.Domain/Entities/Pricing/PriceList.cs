using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Pricing;

/// <summary>
/// Represents a pricing list that groups different service prices for a tenant.
/// Representa una lista de precios que agrupa diferentes precios de servicios para un inquilino.
/// </summary>
public class PriceList : AuditableEntity
{
    /// <summary>
    /// Unique identifier for the price list.
    /// Identificador único para la lista de precios.
    /// </summary>
    public int PriceListId { get; set; }

    /// <summary>
    /// The tenant this price list belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece esta lista de precios (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// Code assigned to the price list.
    /// Código asignado a la lista de precios.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Name of the price list.
    /// Nombre de la lista de precios.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description or details about this price list.
    /// Descripción o detalles sobre esta lista de precios.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates if this is the default price list for the tenant.
    /// Indica si esta es la lista de precios predeterminada para el inquilino.
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Indicates if the price list is active.
    /// Indica si la lista de precios está activa.
    /// </summary>
    public bool IsActive { get; set; }
}
