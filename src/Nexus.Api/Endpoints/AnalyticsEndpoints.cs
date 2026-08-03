using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Analytics.Queries.GetDailyClinicStats;

namespace Nexus.Api.Endpoints;

public static class AnalyticsEndpoints
{
    public static void MapAnalyticsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/analytics")
            .WithTags("Analytics")
            .RequireAuthorization();

        group.MapGet("/daily-stats", async ([FromQuery] int locationId, [FromQuery] string date, IMediator mediator) =>
        {
            var query = new GetDailyClinicStatsQuery(locationId, date);
            var results = await mediator.Send(query);
            return Results.Ok(results);
        })
        .WithName("GetDailyStats")
        .Produces<DailyClinicStatsDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapGet("/practitioner-utilization", async ([FromQuery] Guid practitionerId, [FromQuery] int year, [FromQuery] int month, IMediator mediator) =>
        {
            var query = new Nexus.Application.Analytics.Queries.GetPractitionerUtilization.GetPractitionerUtilizationQuery(practitionerId, year, month);
            var results = await mediator.Send(query);
            return Results.Ok(results);
        })
        .WithName("GetPractitionerUtilization")
        .Produces<Nexus.Application.Analytics.Queries.GetPractitionerUtilization.PractitionerUtilizationDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
