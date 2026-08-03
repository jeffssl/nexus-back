using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;

namespace Nexus.Application.Scheduling.Queries.SearchSlots;

public record SlotDto(
    int SlotId,
    Guid PractitionerId,
    int LocationSpecialtyId,
    DateTimeOffset SlotStartAt,
    DateTimeOffset SlotEndAt
);

public record SearchAvailableSlotsQuery(
    Guid PractitionerId,
    string StartDate,
    string EndDate) : IRequest<List<SlotDto>>;

public class SearchAvailableSlotsQueryValidator : AbstractValidator<SearchAvailableSlotsQuery>
{
    public SearchAvailableSlotsQueryValidator()
    {
        RuleFor(v => v.PractitionerId).NotEmpty();
        RuleFor(v => v.StartDate).NotEmpty();
        RuleFor(v => v.EndDate).NotEmpty();
    }
}

public class SearchAvailableSlotsQueryHandler : IRequestHandler<SearchAvailableSlotsQuery, List<SlotDto>>
{
    private readonly INexusDbContext _context;

    public SearchAvailableSlotsQueryHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<List<SlotDto>> Handle(SearchAvailableSlotsQuery request, CancellationToken cancellationToken)
    {
        if (!DateTime.TryParse(request.StartDate, out var start) || 
            !DateTime.TryParse(request.EndDate, out var end))
        {
            return new List<SlotDto>();
        }

        var startOffset = new DateTimeOffset(start, TimeSpan.Zero);
        var endOffset = new DateTimeOffset(end.AddDays(1), TimeSpan.Zero);

        var slots = await _context.Slots
            .Where(s => s.PractitionerId == request.PractitionerId &&
                        s.ReservationStatus == "AVAILABLE" &&
                        s.SlotStartAt >= startOffset &&
                        s.SlotStartAt < endOffset)
            .OrderBy(s => s.SlotStartAt)
            .Select(s => new SlotDto(
                s.SlotId,
                s.PractitionerId,
                s.LocationSpecialtyId,
                s.SlotStartAt,
                s.SlotEndAt))
            .ToListAsync(cancellationToken);

        return slots;
    }
}
