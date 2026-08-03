using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Application.Scheduling.Commands.CreateException;

public record CreateScheduleExceptionCommand(
    int? ScheduleId,
    Guid PractitionerId,
    int? LocationSpecialtyId,
    string ExceptionDate,
    bool IsClosed,
    string? OverrideStartTime,
    string? OverrideEndTime,
    string? Reason) : IRequest<int>;

public class CreateScheduleExceptionCommandValidator : AbstractValidator<CreateScheduleExceptionCommand>
{
    public CreateScheduleExceptionCommandValidator()
    {
        RuleFor(v => v.PractitionerId).NotEmpty();
        RuleFor(v => v.ExceptionDate).NotEmpty();
    }
}

public class CreateScheduleExceptionCommandHandler : IRequestHandler<CreateScheduleExceptionCommand, int>
{
    private readonly INexusDbContext _context;

    public CreateScheduleExceptionCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateScheduleExceptionCommand request, CancellationToken cancellationToken)
    {
        var entity = new ScheduleException
        {
            ScheduleId = request.ScheduleId,
            PractitionerId = request.PractitionerId,
            LocationSpecialtyId = request.LocationSpecialtyId,
            ExceptionDate = request.ExceptionDate,
            IsClosed = request.IsClosed,
            OverrideStartTime = request.OverrideStartTime,
            OverrideEndTime = request.OverrideEndTime,
            Reason = request.Reason,
            IsActive = true
        };

        _context.ScheduleExceptions.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.ExceptionId;
    }
}
