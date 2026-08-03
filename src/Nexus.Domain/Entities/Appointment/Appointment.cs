using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Appointment;

public class Appointment : AuditableEntity
{
    public Guid AppointmentId { get; set; }
    public Guid TenantId { get; set; }
    public string AppointmentNumber { get; set; }
    public Guid PatientId { get; set; }
    public Guid PractitionerId { get; set; }
    public int LocationId { get; set; }
    public int SpecialtyId { get; set; }
    public int ServiceId { get; set; }
    public int SlotId { get; set; }
    public string AppointmentDate { get; set; }
    public DateTimeOffset StartAt { get; set; }
    public DateTimeOffset EndAt { get; set; }
    public string StatusCode { get; set; }
    public bool IsTelehealth { get; set; }
    public int? PatientInsuranceId { get; set; }
    public bool RequiresPreAuth { get; set; }
    public string? PreAuthCode { get; set; }
    public Guid? BookedByUserId { get; set; }
    public string? BookingChannel { get; set; }
    public DateTimeOffset? ArrivedAt { get; set; }
    public DateTimeOffset? SeenAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public DateTimeOffset? CancelledAt { get; set; }
    public int? CancellationReasonId { get; set; }
    public string? CancellationNotes { get; set; }
    public int Version { get; set; }
}
