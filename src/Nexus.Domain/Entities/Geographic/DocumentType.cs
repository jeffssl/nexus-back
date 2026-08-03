using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Geographic;

public class DocumentType
{
    public int TypeId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int? CountryId { get; set; }
    public string? ValidationRegex { get; set; }
    public bool IsActive { get; set; }
}
