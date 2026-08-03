using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Billing;

public class PaymentMethod
{
    public int MethodId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool RequiresGateway { get; set; }
    public bool IsActive { get; set; }
}
