using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Scheduling.Commands.CreateSchedule;

namespace Nexus.Api.Endpoints;

public static class SchedulesEndpoints
{
    public static void MapSchedulesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/schedules")
            .WithTags("Scheduling")
            .RequireAuthorization();

        group.MapPost("/", async (CreatePractitionerScheduleCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/schedules/{id}", new { Id = id });
        })
        .WithName("CreateSchedule")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/exceptions", async (Nexus.Application.Scheduling.Commands.CreateException.CreateScheduleExceptionCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/schedules/exceptions/{id}", new { Id = id });
        })
        .WithName("CreateException")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/generate-slots", async (Nexus.Application.Scheduling.Commands.GenerateSlots.GenerateSlotsCommand command, IMediator mediator) =>
        {
            var totalCreated = await mediator.Send(command);
            return Results.Ok(new { SlotsCreated = totalCreated });
        })
        .WithName("GenerateSlots")
        .Produces<object>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
