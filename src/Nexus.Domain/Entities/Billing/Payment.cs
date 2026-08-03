using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Billing;

public class Payment
{
    public Guid PaymentId { get; set; }
    public Guid TenantId { get; set; }
    public string PaymentNumber { get; set; }
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public int PaymentMethodId { get; set; }
    public string StatusCode { get; set; }
    public string? TransactionReference { get; set; }
    public DateTimeOffset? ProcessedAt { get; set; }
    public int? PatientInsuranceId { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
}
