using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Patients.Commands.CreatePatient;
using Nexus.Application.Patients.Commands.CreatePatientRelation;

namespace Nexus.Api.Endpoints;

public static class PatientsEndpoints
{
    public static void MapPatientsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/patients")
            .WithTags("Patients")
            .RequireAuthorization();

        group.MapPost("/", async (CreatePatientCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/patients/{id}", new { Id = id });
        })
        .WithName("CreatePatient")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/{primaryPatientId:guid}/dependents", async (
            Guid primaryPatientId, 
            [FromBody] CreatePatientRelationRequest request, 
            IMediator mediator) =>
        {
            var command = new CreatePatientRelationCommand(
                primaryPatientId,
                request.DependentPatientId,
                request.RelationshipType,
                request.CanBookAppointments,
                request.CanAccessMedicalRecords
            );

            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/patients/{primaryPatientId}/dependents/{request.DependentPatientId}", new { RelationId = id });
        })
        .WithName("CreatePatientRelation")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}

public record CreatePatientRelationRequest(
    Guid DependentPatientId,
    string RelationshipType,
    bool CanBookAppointments,
    bool CanAccessMedicalRecords);
