using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Geographic;

public class State
{
    public int StateId { get; set; }
    public int CountryId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
