using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Insurance;

public class Plan
{
    public int PlanId { get; set; }
    public int PayerId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal? CoveragePercentage { get; set; }
    public bool RequiresPreAuth { get; set; }
    public bool IsActive { get; set; }
}
