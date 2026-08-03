using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Insurance;

public class Payer
{
    public int PayerId { get; set; }
    public int CoverageTypeId { get; set; }
    public int CountryId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? TaxId { get; set; }
    public bool IsActive { get; set; }
}
