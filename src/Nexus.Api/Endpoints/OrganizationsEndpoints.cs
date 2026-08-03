using MediatR;
using Nexus.Application.Organizations.Commands.CreateOrganization;

namespace Nexus.Api.Endpoints;

public static class OrganizationsEndpoints
{
    public static void MapOrganizationsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/organizations")
            .WithTags("Organizations");

        group.MapPost("/", async (CreateOrganizationCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/organizations/{id}", new { Id = id });
        })
        .WithName("CreateOrganization")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi()
        .AllowAnonymous();
    }
}
