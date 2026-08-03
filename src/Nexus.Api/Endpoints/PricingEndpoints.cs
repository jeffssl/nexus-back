using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Nexus.Application.Pricing.Commands.CreatePriceList;
using Nexus.Application.Pricing.Commands.CreateServicePrice;

namespace Nexus.Api.Endpoints;

public static class PricingEndpoints
{
    public static void MapPricingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/pricing")
            .WithTags("Pricing")
            .RequireAuthorization();

        group.MapPost("/price-lists", async ([FromBody] CreatePriceListCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/pricing/price-lists/{id}", new { Id = id });
        })
        .WithName("CreatePriceList")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();

        group.MapPost("/service-prices", async ([FromBody] CreateServicePriceCommand command, IMediator mediator) =>
        {
            var id = await mediator.Send(command);
            return Results.Created($"/api/v1/pricing/service-prices/{id}", new { Id = id });
        })
        .WithName("CreateServicePrice")
        .Produces<object>(StatusCodes.Status201Created)
        .ProducesValidationProblem()
        .WithOpenApi();
    }
}
