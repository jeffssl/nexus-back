using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Scheduling;

public class Slot
{
    public int SlotId { get; set; }
    public Guid TenantId { get; set; }
    public Guid PractitionerId { get; set; }
    public int LocationSpecialtyId { get; set; }
    public int? RoomId { get; set; }
    public DateTimeOffset SlotStartAt { get; set; }
    public DateTimeOffset SlotEndAt { get; set; }
    public short MaxCapacity { get; set; }
    public string ReservationStatus { get; set; }
    public DateTimeOffset? HeldUntil { get; set; }
    public int Version { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
