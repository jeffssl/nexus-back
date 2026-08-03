using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Facilities.Commands.CreateRoom;

namespace Nexus.Api.Endpoints;

public static class FacilitiesEndpoints
{
    public static void MapFacilitiesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/locations/{locationId:int}/rooms")
            .WithTags("Facilities")
            .RequireAuthorization();

        group.MapPost("/", async (int locationId, [FromBody] CreateRoomRequest request, ISender sender) =>
        {
            var command = new CreateRoomCommand(
                locationId,
                request.Name,
                request.RoomType,
                request.Capacity,
                request.IsActive
            );
            
            var roomId = await sender.Send(command);
            return Results.Created($"/api/v1/locations/{locationId}/rooms/{roomId}", new { id = roomId });
        });
    }
}

public record CreateRoomRequest(
    string Name,
    string RoomType,
    short Capacity,
    bool IsActive);
