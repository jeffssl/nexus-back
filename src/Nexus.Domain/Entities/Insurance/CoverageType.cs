using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Insurance;

public class CoverageType
{
    public int TypeId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
