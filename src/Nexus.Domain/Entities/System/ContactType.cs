using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.System;

public class ContactType
{
    public int ContactTypeId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? ValidationRegex { get; set; }
    public bool IsActive { get; set; }
}
