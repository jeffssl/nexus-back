using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Application.Billing.Queries.GetServicesPricing;

namespace Nexus.Api.Endpoints;

public static class BillingEndpoints
{
    public static void MapBillingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/billing")
            .WithTags("Billing")
            .RequireAuthorization();

        group.MapGet("/pricing", async ([FromQuery] int? locationId, IMediator mediator) =>
        {
            var query = new GetServicesPricingQuery(locationId);
            var results = await mediator.Send(query);
            return Results.Ok(results);
        })
        .WithName("GetServicesPricing")
        .Produces<System.Collections.Generic.List<ServicePricingDto>>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/invoices", async ([FromBody] Nexus.Application.Billing.Commands.GenerateInvoice.GenerateInvoiceCommand command, IMediator mediator) =>
        {
            var invoiceId = await mediator.Send(command);
            return Results.Ok(new { InvoiceId = invoiceId });
        })
        .WithName("GenerateInvoice")
        .Produces(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/invoices/{id}/pay", async (Guid id, [FromBody] Nexus.Application.Billing.Commands.PayInvoice.PayInvoiceCommand command, IMediator mediator) =>
        {
            if (id != command.InvoiceId)
                return Results.BadRequest("Invoice ID in path must match Invoice ID in body.");

            var success = await mediator.Send(command);
            return success ? Results.Ok() : Results.BadRequest();
        })
        .WithName("PayInvoice")
        .Produces(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
