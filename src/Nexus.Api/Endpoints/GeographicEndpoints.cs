using MediatR;
using Nexus.Application.Geographic.Commands.CreateCountry;

namespace Nexus.Api.Endpoints;

public static class GeographicEndpoints
{
    public static void MapGeographicEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/geographic")
            .WithTags("Geographic")
            .RequireAuthorization();

        group.MapPost("/countries", async (CreateCountryCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/geographic/countries/{id}", new { Id = id });
        })
        .WithName("CreateCountry")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
