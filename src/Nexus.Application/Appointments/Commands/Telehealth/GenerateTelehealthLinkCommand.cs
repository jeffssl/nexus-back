using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Appointments.Commands.Telehealth;

public record GenerateTelehealthLinkCommand(Guid AppointmentId) : IRequest<string>;

public class GenerateTelehealthLinkCommandValidator : AbstractValidator<GenerateTelehealthLinkCommand>
{
    public GenerateTelehealthLinkCommandValidator()
    {
        RuleFor(v => v.AppointmentId).NotEmpty();
    }
}

public class GenerateTelehealthLinkCommandHandler : IRequestHandler<GenerateTelehealthLinkCommand, string>
{
    private readonly INexusDbContext _context;

    public GenerateTelehealthLinkCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(GenerateTelehealthLinkCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == request.AppointmentId, cancellationToken);

        if (appointment == null)
            throw new Exception("Appointment not found.");

        if (!appointment.IsTelehealth)
            throw new Exception("This appointment is not marked for Telehealth.");

        var randomString = Guid.NewGuid().ToString("N").Substring(0, 10);
        return $"https://nexus.meet/session/{randomString}";
    }
}
