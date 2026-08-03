using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Pricing;

public class Service
{
    public int ServiceId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public short? DefaultDurationMinutes { get; set; }
    public bool RequiresPreAuth { get; set; }
    public bool IsActive { get; set; }
}
