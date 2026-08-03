using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Scheduling.Commands.Waitlist;

namespace Nexus.Api.Endpoints;

public static class WaitlistsEndpoints
{
    public static void MapWaitlistsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/waitlists")
            .WithTags("Waitlists")
            .RequireAuthorization();

        group.MapPost("/", async ([FromBody] JoinWaitlistCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Ok(new { WaitlistId = id });
        })
        .WithName("JoinWaitlist")
        .Produces(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
