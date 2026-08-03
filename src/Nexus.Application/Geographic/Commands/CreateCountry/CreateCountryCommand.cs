using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Geographic;

namespace Nexus.Application.Geographic.Commands.CreateCountry;

public record CreateCountryCommand(
    string CountryCode,
    string Iso3Code,
    string Name,
    string? PhoneCode,
    bool IsActive) : IRequest<int>;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(v => v.CountryCode).MaximumLength(2).NotEmpty();
        RuleFor(v => v.Iso3Code).MaximumLength(3).NotEmpty();
        RuleFor(v => v.Name).MaximumLength(100).NotEmpty();
        RuleFor(v => v.PhoneCode).MaximumLength(20);
    }
}

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
{
    private readonly INexusDbContext _context;

    public CreateCountryCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Country
        {
            CountryCode = request.CountryCode,
            Iso3Code = request.Iso3Code,
            Name = request.Name,
            PhoneCode = request.PhoneCode,
            IsActive = request.IsActive
        };

        _context.Countries.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.CountryId;
    }
}
