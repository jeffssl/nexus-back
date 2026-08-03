using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Billing;

public class Invoice : AuditableEntity
{
    public Guid InvoiceId { get; set; }
    public Guid TenantId { get; set; }
    public string InvoiceNumber { get; set; }
    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public string IssueDate { get; set; }
    public string? DueDate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public string CurrencyCode { get; set; }
    public string StatusCode { get; set; }
    public string? Notes { get; set; }
}
