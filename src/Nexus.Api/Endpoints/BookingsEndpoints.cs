using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Scheduling.Queries.SearchSlots;

namespace Nexus.Api.Endpoints;

public static class BookingsEndpoints
{
    public static void MapBookingsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1")
            .WithTags("Bookings")
            .RequireAuthorization();

        group.MapGet("/slots", async ([FromQuery] Guid practitionerId, [FromQuery] string startDate, [FromQuery] string endDate, IMediator mediator) =>
        {
            var query = new SearchAvailableSlotsQuery(practitionerId, startDate, endDate);
            var results = await mediator.Send(query);
            return Results.Ok(results);
        })
        .WithName("SearchSlots")
        .Produces<List<SlotDto>>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/appointments", async ([FromBody] Nexus.Application.Appointments.Commands.CreateAppointment.CreateAppointmentCommand command, IMediator mediator) =>
        {
            try
            {
                var id = await mediator.Send(command);
                return Results.Created($"/api/v1/appointments/{id}", new { Id = id });
            }
            catch (Exception ex)
            {
                return Results.Conflict(new { Error = ex.Message });
            }
        })
        .WithName("CreateAppointment")
        .Produces<object>(StatusCodes.Status201Created)
        .Produces<object>(StatusCodes.Status409Conflict)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/appointments/{id}/telehealth-link", async (Guid id, IMediator mediator) =>
        {
            try
            {
                var command = new Nexus.Application.Appointments.Commands.Telehealth.GenerateTelehealthLinkCommand(id);
                var link = await mediator.Send(command);
                return Results.Ok(new { TelehealthLink = link });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { Error = ex.Message });
            }
        })
        .WithName("GenerateTelehealthLink")
        .Produces<object>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/appointments/{id}/clinical-notes", async (Guid id, [FromBody] Nexus.Application.Appointments.Commands.AddClinicalNote.AddClinicalNoteCommand command, IMediator mediator) =>
        {
            try
            {
                // Ensure the ID in the route matches the command
                var actualCommand = command with { AppointmentId = id };
                var noteId = await mediator.Send(actualCommand);
                return Results.Ok(new { ClinicalDetailId = noteId });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { Error = ex.Message });
            }
        })
        .WithName("AddClinicalNote")
        .Produces<object>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
