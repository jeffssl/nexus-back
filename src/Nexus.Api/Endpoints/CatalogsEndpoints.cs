using MediatR;
using Nexus.Application.Catalogs.Commands.CreateSpecialty;
using Nexus.Application.Catalogs.Commands.CreateService;

namespace Nexus.Api.Endpoints;

public static class CatalogsEndpoints
{
    public static void MapCatalogsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/catalogs")
            .WithTags("Catalogs")
            .RequireAuthorization();

        group.MapPost("/specialties", async (CreateSpecialtyCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/catalogs/specialties/{id}", new { Id = id });
        })
        .WithName("CreateSpecialty")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/services", async (CreateServiceCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/catalogs/services/{id}", new { Id = id });
        })
        .WithName("CreateService")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
