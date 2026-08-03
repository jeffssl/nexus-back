using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Geographic;

public class Country
{
    public int CountryId { get; set; }
    public string CountryCode { get; set; }
    public string Iso3Code { get; set; }
    public string Name { get; set; }
    public string? PhoneCode { get; set; }
    public bool IsActive { get; set; }
}
