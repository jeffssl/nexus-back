using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Pricing;

namespace Nexus.Application.Pricing.Commands.CreateServicePrice;

/// <summary>
/// Command to create a new service price within a price list.
/// Comando para crear un nuevo precio de servicio dentro de una lista de precios.
/// </summary>
public record CreateServicePriceCommand(
    int PriceListId,
    int? LocationId,
    int? SpecialtyId,
    int ServiceId,
    Guid? PractitionerId,
    decimal Price,
    string CurrencyCode,
    string ValidFrom,
    string? ValidTo) : IRequest<int>;

/// <summary>
/// Validates the CreateServicePriceCommand properties.
/// Valida las propiedades del CreateServicePriceCommand.
/// </summary>

public class CreateServicePriceCommandValidator : AbstractValidator<CreateServicePriceCommand>
{
    public CreateServicePriceCommandValidator()
    {
        RuleFor(v => v.PriceListId).GreaterThan(0);
        RuleFor(v => v.ServiceId).GreaterThan(0);
        RuleFor(v => v.Price).GreaterThanOrEqualTo(0);
        RuleFor(v => v.CurrencyCode).MaximumLength(3).NotEmpty();
        RuleFor(v => v.ValidFrom).NotEmpty();
    }
}

/// <summary>
/// Handles the creation of a new service price, inheriting the TenantId from the PriceList.
/// Maneja la creación de un nuevo precio de servicio, heredando el TenantId de la lista de precios.
/// </summary>
public class CreateServicePriceCommandHandler : IRequestHandler<CreateServicePriceCommand, int>
{
    private readonly INexusDbContext _context;

    public CreateServicePriceCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateServicePriceCommand request, CancellationToken cancellationToken)
    {
        var priceList = await _context.PriceLists
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PriceListId == request.PriceListId, cancellationToken);

        if (priceList == null)
        {
            throw new InvalidOperationException($"La lista de precios con ID {request.PriceListId} no existe.");
        }

        var entity = new ServicePrice
        {
            PriceListId = request.PriceListId,
            TenantId = priceList.TenantId,
            LocationId = request.LocationId,
            SpecialtyId = request.SpecialtyId,
            ServiceId = request.ServiceId,
            PractitionerId = request.PractitionerId,
            Price = request.Price,
            CurrencyCode = request.CurrencyCode,
            ValidFrom = request.ValidFrom,
            ValidTo = request.ValidTo,
            IsActive = true
        };

        _context.ServicePrices.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.ServicePriceId;
    }
}
