using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Pricing;

namespace Nexus.Application.Pricing.Commands.CreatePriceList;

/// <summary>
/// Command to create a new price list for a tenant.
/// Comando para crear una nueva lista de precios para un inquilino.
/// </summary>
public record CreatePriceListCommand(
    Guid TenantId,
    string Code,
    string Name,
    string? Description,
    bool IsDefault) : IRequest<int>;

/// <summary>
/// Validates the CreatePriceListCommand properties.
/// Valida las propiedades del CreatePriceListCommand.
/// </summary>
public class CreatePriceListCommandValidator : AbstractValidator<CreatePriceListCommand>
{
    public CreatePriceListCommandValidator()
    {
        RuleFor(v => v.TenantId).NotEmpty();
        RuleFor(v => v.Code).MaximumLength(20).NotEmpty();
        RuleFor(v => v.Name).MaximumLength(100).NotEmpty();
        RuleFor(v => v.Description).MaximumLength(255);
    }
}

/// <summary>
/// Handles the creation of a new price list.
/// Maneja la creación de una nueva lista de precios.
/// </summary>
public class CreatePriceListCommandHandler : IRequestHandler<CreatePriceListCommand, int>
{
    private readonly INexusDbContext _context;

    public CreatePriceListCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePriceListCommand request, CancellationToken cancellationToken)
    {
        var entity = new PriceList
        {
            TenantId = request.TenantId,
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            IsDefault = request.IsDefault,
            IsActive = true
        };

        _context.PriceLists.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.PriceListId;
    }
}
