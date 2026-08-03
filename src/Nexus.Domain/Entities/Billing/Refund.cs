using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Billing;

/// <summary>
/// Represents a refund issued for a payment.
/// Representa un reembolso emitido por un pago.
/// </summary>
public class Refund
{
    /// <summary>
    /// Unique identifier for the refund.
    /// Identificador único del reembolso.
    /// </summary>
    public int RefundId { get; set; }

    /// <summary>
    /// The payment that is being refunded.
    /// El pago que se está reembolsando.
    /// </summary>
    public Guid PaymentId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The refunded amount.
    /// El monto reembolsado.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Currency code (e.g., USD, EUR).
    /// Código de moneda (ej., USD, EUR).
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Reason for the refund.
    /// Motivo del reembolso.
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// Timestamp when the refund was processed.
    /// Marca de tiempo de cuando se procesó el reembolso.
    /// </summary>
    public DateTimeOffset? ProcessedAt { get; set; }

    /// <summary>
    /// Reference code from the payment gateway.
    /// Código de referencia de la pasarela de pagos.
    /// </summary>
    public string? TransactionReference { get; set; }

    /// <summary>
    /// Status of the refund (e.g., Pending, Completed).
    /// Estado del reembolso (ej., Pendiente, Completado).
    /// </summary>
    public string StatusCode { get; set; }

    /// <summary>
    /// Timestamp when the refund was requested.
    /// Marca de tiempo de cuando se solicitó el reembolso.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The user who initiated the refund.
    /// El usuario que inició el reembolso.
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
