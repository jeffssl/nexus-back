using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.System.Commands.ArchiveAuditLogs;
using System;

namespace Nexus.Api.Endpoints;

public static class SystemEndpoints
{
    public static void MapSystemEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/system")
            .WithTags("System")
            .RequireAuthorization();

        group.MapPost("/archive-audit", async ([FromBody] ArchiveAuditLogsCommand command, IMediator mediator) =>
        {
            var count = await mediator.Send(command);
            return Results.Ok(new { ArchivedCount = count });
        })
        .WithName("ArchiveAuditLogs")
        .Produces(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
