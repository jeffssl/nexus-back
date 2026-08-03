using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Scheduling;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Scheduling.Commands.Waitlist;

public record JoinWaitlistCommand(Guid PatientId, int SpecialtyId, Guid? PractitionerId, string PreferredDateFrom, string PreferredDateTo) : IRequest<int>;

public class JoinWaitlistCommandValidator : AbstractValidator<JoinWaitlistCommand>
{
    public JoinWaitlistCommandValidator()
    {
        RuleFor(v => v.PatientId).NotEmpty();
        RuleFor(v => v.SpecialtyId).GreaterThan(0);
        RuleFor(v => v.PreferredDateFrom).NotEmpty();
        RuleFor(v => v.PreferredDateTo).NotEmpty();
    }
}

public class JoinWaitlistCommandHandler : IRequestHandler<JoinWaitlistCommand, int>
{
    private readonly INexusDbContext _context;

    public JoinWaitlistCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(JoinWaitlistCommand request, CancellationToken cancellationToken)
    {
        var waitlist = new Nexus.Domain.Entities.Scheduling.Waitlist
        {
            PatientId = request.PatientId,
            PractitionerId = request.PractitionerId,
            SpecialtyId = request.SpecialtyId,
            PreferredDateFrom = request.PreferredDateFrom,
            PreferredDateTo = request.PreferredDateTo,
            Status = "ACTIVE"
        };

        _context.Waitlists.Add(waitlist);
        await _context.SaveChangesAsync(cancellationToken);

        return waitlist.WaitlistId;
    }
}
