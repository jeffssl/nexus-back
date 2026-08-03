using MediatR;
using Nexus.Application.Practitioners.Commands.CreatePractitioner;

namespace Nexus.Api.Endpoints;

public static class PractitionersEndpoints
{
    public static void MapPractitionersEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/practitioners")
            .WithTags("Practitioners");

        group.MapPost("/", async (CreatePractitionerCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/practitioners/{id}", new { Id = id });
        })
        .WithName("CreatePractitioner")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi()
        .RequireAuthorization();
    }
}
