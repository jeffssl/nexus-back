using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Scheduling;

public class PractitionerSchedule : AuditableEntity
{
    public int ScheduleId { get; set; }
    public Guid TenantId { get; set; }
    public Guid PractitionerId { get; set; }
    public int LocationSpecialtyId { get; set; }
    public int? RoomId { get; set; }
    public short WeekdayId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public short SlotDurationMinutes { get; set; }
    public short MaxPatientsPerSlot { get; set; }
    public string ValidFrom { get; set; }
    public string? ValidTo { get; set; }
    public bool IsActive { get; set; }
}
