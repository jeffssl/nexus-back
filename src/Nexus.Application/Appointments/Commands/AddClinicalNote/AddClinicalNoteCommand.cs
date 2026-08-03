using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Appointment;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Appointments.Commands.AddClinicalNote;

public record AddClinicalNoteCommand(
    Guid AppointmentId,
    string? PatientNotes,
    string? InternalNotes) : IRequest<Guid>;

public class AddClinicalNoteCommandValidator : AbstractValidator<AddClinicalNoteCommand>
{
    public AddClinicalNoteCommandValidator()
    {
        RuleFor(v => v.AppointmentId).NotEmpty();
    }
}

public class AddClinicalNoteCommandHandler : IRequestHandler<AddClinicalNoteCommand, Guid>
{
    private readonly INexusDbContext _context;

    public AddClinicalNoteCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(AddClinicalNoteCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == request.AppointmentId, cancellationToken);

        if (appointment == null)
            throw new Exception("Appointment not found.");

        var clinicalDetail = new AppointmentClinicalDetail
        {
            ClinicalDetailId = Guid.NewGuid(),
            AppointmentId = request.AppointmentId,
            PatientNotes = request.PatientNotes,
            InternalNotes = request.InternalNotes
        };

        _context.AppointmentClinicalDetails.Add(clinicalDetail);
        
        await _context.SaveChangesAsync(cancellationToken);

        return clinicalDetail.ClinicalDetailId;
    }
}
