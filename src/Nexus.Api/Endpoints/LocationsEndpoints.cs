using MediatR;
using Nexus.Application.Locations.Commands.CreateLocation;

namespace Nexus.Api.Endpoints;

public static class LocationsEndpoints
{
    public static void MapLocationsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/locations")
            .WithTags("Locations")
            .RequireAuthorization();

        group.MapPost("/", async (CreateLocationCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/locations/{id}", new { Id = id });
        })
        .WithName("CreateLocation")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
