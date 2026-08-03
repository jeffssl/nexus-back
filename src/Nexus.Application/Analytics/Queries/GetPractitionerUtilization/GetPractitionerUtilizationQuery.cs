using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Analytics.Queries.GetPractitionerUtilization;

public record PractitionerUtilizationDto(
    Guid PractitionerId,
    int TotalSlots,
    int BookedSlots,
    double UtilizationPercentage
);

public record GetPractitionerUtilizationQuery(Guid PractitionerId, int Year, int Month) : IRequest<PractitionerUtilizationDto>;

public class GetPractitionerUtilizationQueryValidator : AbstractValidator<GetPractitionerUtilizationQuery>
{
    public GetPractitionerUtilizationQueryValidator()
    {
        RuleFor(v => v.PractitionerId).NotEmpty();
        RuleFor(v => v.Year).GreaterThan(2000);
        RuleFor(v => v.Month).InclusiveBetween(1, 12);
    }
}

public class GetPractitionerUtilizationQueryHandler : IRequestHandler<GetPractitionerUtilizationQuery, PractitionerUtilizationDto>
{
    private readonly INexusDbContext _context;

    public GetPractitionerUtilizationQueryHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<PractitionerUtilizationDto> Handle(GetPractitionerUtilizationQuery request, CancellationToken cancellationToken)
    {
        var startOfMonth = new DateTimeOffset(request.Year, request.Month, 1, 0, 0, 0, TimeSpan.Zero);
        var endOfMonth = startOfMonth.AddMonths(1);

        var slots = await _context.Slots
            .Where(s => s.PractitionerId == request.PractitionerId &&
                        s.SlotStartAt >= startOfMonth &&
                        s.SlotStartAt < endOfMonth)
            .ToListAsync(cancellationToken);

        var total = slots.Count;
        if (total == 0)
        {
            return new PractitionerUtilizationDto(request.PractitionerId, 0, 0, 0);
        }

        var booked = slots.Count(s => s.ReservationStatus == "BOOKED" || s.ReservationStatus == "RESERVED");
        var percentage = Math.Round((double)booked / total * 100, 2);

        return new PractitionerUtilizationDto(request.PractitionerId, total, booked, percentage);
    }
}
