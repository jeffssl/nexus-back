using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Practitioner;

namespace Nexus.Application.Catalogs.Commands.CreateSpecialty;

public record CreateSpecialtyCommand(
    string SnomedCode,
    string NameEs,
    string NameEn,
    int CategoryId,
    bool IsActive) : IRequest<int>;

public class CreateSpecialtyCommandValidator : AbstractValidator<CreateSpecialtyCommand>
{
    public CreateSpecialtyCommandValidator()
    {
        RuleFor(v => v.SnomedCode).MaximumLength(20).NotEmpty();
        RuleFor(v => v.NameEs).MaximumLength(150).NotEmpty();
        RuleFor(v => v.NameEn)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.CategoryId).GreaterThan(0);
    }
}

public class CreateSpecialtyCommandHandler : IRequestHandler<CreateSpecialtyCommand, int>
{
    private readonly INexusDbContext _context;

    public CreateSpecialtyCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var entity = new Specialty
        {
            SnomedCode = request.SnomedCode,
            NameEs = request.NameEs,
            NameEn = request.NameEn,
            CategoryId = request.CategoryId,
            IsActive = request.IsActive
        };

        _context.Specialties.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.SpecialtyId;
    }
}
