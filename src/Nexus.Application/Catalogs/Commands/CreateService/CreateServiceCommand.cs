using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Pricing;

namespace Nexus.Application.Catalogs.Commands.CreateService;

public record CreateServiceCommand(
    string Code,
    string Name,
    string? Description,
    short? DefaultDurationMinutes,
    bool RequiresPreAuth,
    bool IsActive) : IRequest<int>;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(v => v.Code).MaximumLength(50).NotEmpty();
        RuleFor(v => v.Name).MaximumLength(150).NotEmpty();
        RuleFor(v => v.Description).MaximumLength(500);
        RuleFor(v => v.DefaultDurationMinutes).GreaterThan((short)0).When(v => v.DefaultDurationMinutes.HasValue);
    }
}

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
{
    private readonly INexusDbContext _context;

    public CreateServiceCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = new Service
        {
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            DefaultDurationMinutes = request.DefaultDurationMinutes,
            RequiresPreAuth = request.RequiresPreAuth,
            IsActive = request.IsActive
        };

        _context.Services.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.ServiceId;
    }
}
