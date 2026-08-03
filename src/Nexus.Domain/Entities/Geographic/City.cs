using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Geographic;

public class City
{
    public int CityId { get; set; }
    public int StateId { get; set; }
    public string? Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
