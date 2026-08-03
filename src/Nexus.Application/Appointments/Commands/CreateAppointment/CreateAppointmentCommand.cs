using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Appointment;
using Nexus.Domain.Entities.Scheduling;
using Nexus.Application.Appointments.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Appointments.Commands.CreateAppointment;

public record CreateAppointmentCommand(
    int SlotId,
    Guid TenantId,
    Guid PatientId,
    int ServiceId,
    int? PatientInsuranceId,
    bool IsTelehealth,
    Guid? BookedByUserId,
    string? BookingChannel) : IRequest<Guid>;

public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        RuleFor(v => v.SlotId).GreaterThan(0);
        RuleFor(v => v.TenantId).NotEmpty();
        RuleFor(v => v.PatientId).NotEmpty();
        RuleFor(v => v.ServiceId).GreaterThan(0);
    }
}

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
{
    private readonly INexusDbContext _context;
    private readonly IPublisher _publisher;

    public CreateAppointmentCommandHandler(INexusDbContext context, IPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var slot = await _context.Slots
            .FirstOrDefaultAsync(s => s.SlotId == request.SlotId, cancellationToken);

        if (slot == null)
            throw new Exception("Slot not found.");

        if (slot.ReservationStatus != "AVAILABLE")
            throw new Exception("Slot is no longer available.");

        slot.ReservationStatus = "BOOKED";
        slot.Version++; 

        var appointment = new Appointment
        {
            AppointmentId = Guid.NewGuid(),
            TenantId = request.TenantId,
            AppointmentNumber = $"APT-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}",
            PatientId = request.PatientId,
            PractitionerId = slot.PractitionerId,
            LocationId = 1, 
            SpecialtyId = slot.LocationSpecialtyId, 
            ServiceId = request.ServiceId,
            SlotId = slot.SlotId,
            AppointmentDate = slot.SlotStartAt.ToString("yyyy-MM-dd"),
            StartAt = slot.SlotStartAt,
            EndAt = slot.SlotEndAt,
            StatusCode = "SCHEDULED",
            IsTelehealth = request.IsTelehealth,
            PatientInsuranceId = request.PatientInsuranceId,
            RequiresPreAuth = false,
            BookedByUserId = request.BookedByUserId,
            BookingChannel = request.BookingChannel ?? "ONLINE",
            Version = 1
        };

        _context.Appointments.Add(appointment);
        
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            await _publisher.Publish(new AppointmentCreatedEvent(
                appointment.AppointmentId,
                appointment.PatientId,
                appointment.PractitionerId,
                appointment.StartAt
            ), cancellationToken);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new Exception("The slot was booked by another user. Please try a different slot.");
        }

        return appointment.AppointmentId;
    }
}
