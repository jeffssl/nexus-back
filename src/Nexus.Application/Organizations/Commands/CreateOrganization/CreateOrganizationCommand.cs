using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Organization;
using Nexus.Domain.Entities.Geographic;
using Microsoft.EntityFrameworkCore;

namespace Nexus.Application.Organizations.Commands.CreateOrganization;

public record CreateOrganizationCommand(
    string LegalName,
    string? TradeName,
    string? TaxId,
    int? DocumentTypeId,
    int CountryId,
    string? Website) : IRequest<Guid>;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(v => v.LegalName)
            .MaximumLength(150)
            .NotEmpty();

        RuleFor(v => v.TradeName)
            .MaximumLength(150);

        RuleFor(v => v.TaxId)
            .MaximumLength(50);
            
        RuleFor(v => v.DocumentTypeId)
            .NotEmpty()
            .When(v => !string.IsNullOrEmpty(v.TaxId))
            .WithMessage("DocumentTypeId is required when TaxId is provided.");

        RuleFor(v => v.CountryId)
            .GreaterThan(0);

        RuleFor(v => v.Website)
            .MaximumLength(200);
    }
}

public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, Guid>
{
    private readonly INexusDbContext _context;

    public CreateOrganizationCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.TaxId))
        {
            var exists = await _context.Organizations.AnyAsync(x => x.TaxId == request.TaxId, cancellationToken);
            if (exists)
            {
                throw new InvalidOperationException($"La organización con TaxId '{request.TaxId}' ya existe.");
            }
        }

        var entity = new Organization
        {
            LegalName = request.LegalName,
            TaxId = request.TaxId,
            DocumentTypeId = request.DocumentTypeId,
            TradeName = request.TradeName,
            CountryId = request.CountryId
        };

        _context.Organizations.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.OrganizationId;
    }
}
