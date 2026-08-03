using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Billing;

public class RefundStatus
{
    public string StatusCode { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsFinal { get; set; }
}
