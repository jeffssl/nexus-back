using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Appointment;

public class CancellationReason
{
    public int ReasonId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? AppliesToStatus { get; set; }
    public bool RequiresRefund { get; set; }
    public bool IsActive { get; set; }
}
