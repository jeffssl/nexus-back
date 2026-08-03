using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Application.Scheduling.Commands.CreateSchedule;

/// <summary>
/// Command to create a schedule rule for a practitioner in a location/specialty.
/// Comando para crear una regla de horario para un médico en una sede/especialidad.
/// </summary>
public record CreatePractitionerScheduleCommand(
    Guid TenantId,
    Guid PractitionerId,
    int LocationSpecialtyId,
    int? RoomId,
    short WeekdayId,
    string StartTime,
    string EndTime,
    short SlotDurationMinutes,
    short MaxPatientsPerSlot,
    string ValidFrom,
    string? ValidTo) : IRequest<int>;

/// <summary>
/// Validator for CreatePractitionerScheduleCommand.
/// Validador para CreatePractitionerScheduleCommand.
/// </summary>
public class CreatePractitionerScheduleCommandValidator : AbstractValidator<CreatePractitionerScheduleCommand>
{
    public CreatePractitionerScheduleCommandValidator()
    {
        RuleFor(v => v.TenantId).NotEmpty();
        RuleFor(v => v.PractitionerId).NotEmpty();
        RuleFor(v => v.LocationSpecialtyId).GreaterThan(0);
        RuleFor(v => v.WeekdayId).InclusiveBetween((short)1, (short)7);
        RuleFor(v => v.StartTime).NotEmpty().Matches("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
        RuleFor(v => v.EndTime).NotEmpty().Matches("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
        RuleFor(v => v.SlotDurationMinutes).GreaterThan((short)0);
        RuleFor(v => v.MaxPatientsPerSlot).GreaterThan((short)0);
        RuleFor(v => v.ValidFrom).NotEmpty();
    }
}

/// <summary>
/// Handler to process the creation of a new practitioner schedule rule.
/// Manejador para procesar la creación de una nueva regla de horario de médico.
/// </summary>
public class CreatePractitionerScheduleCommandHandler : IRequestHandler<CreatePractitionerScheduleCommand, int>
{
    private readonly INexusDbContext _context;

    public CreatePractitionerScheduleCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePractitionerScheduleCommand request, CancellationToken cancellationToken)
    {
        var entity = new PractitionerSchedule
        {
            TenantId = request.TenantId,
            PractitionerId = request.PractitionerId,
            LocationSpecialtyId = request.LocationSpecialtyId,
            RoomId = request.RoomId,
            WeekdayId = request.WeekdayId,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            SlotDurationMinutes = request.SlotDurationMinutes,
            MaxPatientsPerSlot = request.MaxPatientsPerSlot,
            ValidFrom = request.ValidFrom,
            ValidTo = request.ValidTo,
            IsActive = true
        };

        _context.PractitionerSchedules.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.ScheduleId;
    }
}
