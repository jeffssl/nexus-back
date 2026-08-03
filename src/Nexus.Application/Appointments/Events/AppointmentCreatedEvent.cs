using MediatR;
using System;

namespace Nexus.Application.Appointments.Events;

public record AppointmentCreatedEvent(Guid AppointmentId, Guid PatientId, Guid? PractitionerId, DateTimeOffset AppointmentDate) : INotification;
