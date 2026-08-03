using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Appointment;

public class AppointmentStatus
{
    public string StatusCode { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsFinal { get; set; }
    public string? AllowedTransitions { get; set; }
}
