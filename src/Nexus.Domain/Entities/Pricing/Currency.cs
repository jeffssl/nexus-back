using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Pricing;

public class Currency
{
    public string CurrencyCode { get; set; }
    public string Name { get; set; }
    public string? Symbol { get; set; }
    public short DecimalPlaces { get; set; }
}
