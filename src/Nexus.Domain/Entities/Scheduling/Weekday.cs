using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Scheduling;

public class Weekday
{
    public short WeekdayId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
}
