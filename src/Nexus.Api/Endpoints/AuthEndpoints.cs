using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Auth.Commands.GenerateToken;

namespace Nexus.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/auth")
            .WithTags("Auth")
            .WithOpenApi();

        group.MapPost("/token", async ([FromBody] GenerateTokenCommand command, IMediator mediator) =>
        {
            var token = await mediator.Send(command);
            return Results.Ok(new { Token = token });
        });
    }
}
