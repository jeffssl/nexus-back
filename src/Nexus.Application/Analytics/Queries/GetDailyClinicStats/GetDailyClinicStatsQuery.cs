using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Analytics.Queries.GetDailyClinicStats;

public record DailyClinicStatsDto(
    int TotalAppointments,
    int Scheduled,
    int Cancelled,
    int Completed
);

public record GetDailyClinicStatsQuery(int LocationId, string Date) : IRequest<DailyClinicStatsDto>;

public class GetDailyClinicStatsQueryValidator : AbstractValidator<GetDailyClinicStatsQuery>
{
    public GetDailyClinicStatsQueryValidator()
    {
        RuleFor(v => v.LocationId).GreaterThan(0);
        RuleFor(v => v.Date).NotEmpty();
    }
}

public class GetDailyClinicStatsQueryHandler : IRequestHandler<GetDailyClinicStatsQuery, DailyClinicStatsDto>
{
    private readonly INexusDbContext _context;

    public GetDailyClinicStatsQueryHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<DailyClinicStatsDto> Handle(GetDailyClinicStatsQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _context.Appointments
            .Where(a => a.LocationId == request.LocationId && a.AppointmentDate == request.Date)
            .ToListAsync(cancellationToken);

        var total = appointments.Count;
        var scheduled = appointments.Count(a => a.StatusCode == "SCHEDULED");
        var cancelled = appointments.Count(a => a.StatusCode == "CANCELLED" || a.StatusCode == "NO_SHOW");
        var completed = appointments.Count(a => a.StatusCode == "COMPLETED");

        return new DailyClinicStatsDto(total, scheduled, cancelled, completed);
    }
}
