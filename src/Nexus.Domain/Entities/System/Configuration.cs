using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.System;

public class Configuration : AuditableEntity
{
    public string ConfigKey { get; set; }
    public string ConfigValue { get; set; }
    public string DataType { get; set; }
    public string? Description { get; set; }
}
