using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Billing;

/// <summary>
/// Represents a single line item within an invoice.
/// Representa un ítem o línea individual dentro de una factura.
/// </summary>
public class InvoiceLineItem
{
    /// <summary>
    /// Unique identifier for the invoice line item.
    /// Identificador único para el ítem de la factura.
    /// </summary>
    public int LineItemId { get; set; }

    /// <summary>
    /// The invoice this line item belongs to.
    /// La factura a la que pertenece este ítem.
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The service being billed.
    /// El servicio que se está facturando.
    /// </summary>
    public int ServiceId { get; set; }

    /// <summary>
    /// Description of the line item.
    /// Descripción del ítem.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Quantity of the service.
    /// Cantidad del servicio.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Unit price of the service.
    /// Precio unitario del servicio.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Subtotal (Quantity * UnitPrice).
    /// Subtotal (Cantidad * Precio Unitario).
    /// </summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// Tax applied to this line item.
    /// Impuesto aplicado a este ítem.
    /// </summary>
    public decimal Tax { get; set; }

    /// <summary>
    /// Total amount for this line item (Subtotal + Tax).
    /// Monto total para este ítem (Subtotal + Impuesto).
    /// </summary>
    public decimal Total { get; set; }
}
