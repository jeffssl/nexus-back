using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Scheduling;

namespace Nexus.Application.Scheduling.Commands.GenerateSlots;

/// <summary>
/// Command to generate appointment slots for a practitioner for a specific month.
/// Comando para generar los espacios (slots) de agenda de un médico para un mes específico.
/// </summary>
public record GenerateSlotsCommand(Guid PractitionerId, int Year, int Month) : IRequest<int>;

/// <summary>
/// Validator for GenerateSlotsCommand.
/// Validador para GenerateSlotsCommand.
/// </summary>
public class GenerateSlotsCommandValidator : AbstractValidator<GenerateSlotsCommand>
{
    public GenerateSlotsCommandValidator()
    {
        RuleFor(v => v.PractitionerId).NotEmpty();
        RuleFor(v => v.Year).GreaterThan(2024);
        RuleFor(v => v.Month).InclusiveBetween(1, 12);
    }
}

/// <summary>
/// Handler to process the generation of appointment slots based on schedule rules.
/// Manejador para procesar la generación de espacios de agenda en base a las reglas de horario.
/// </summary>
public class GenerateSlotsCommandHandler : IRequestHandler<GenerateSlotsCommand, int>
{
    private readonly INexusDbContext _context;

    public GenerateSlotsCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(GenerateSlotsCommand request, CancellationToken cancellationToken)
    {
        // 1. Fetch active schedules for practitioner
        var schedules = await _context.PractitionerSchedules
            .Where(s => s.PractitionerId == request.PractitionerId && s.IsActive)
            .ToListAsync(cancellationToken);

        if (!schedules.Any()) return 0;

        // 2. Fetch exceptions
        var exceptions = await _context.ScheduleExceptions
            .Where(e => e.PractitionerId == request.PractitionerId && e.IsActive)
            .ToListAsync(cancellationToken);

        var slotsCreated = 0;
        var daysInMonth = DateTime.DaysInMonth(request.Year, request.Month);

        // 3. Iterate over every day in the month
        for (int day = 1; day <= daysInMonth; day++)
        {
            var currentDate = new DateTime(request.Year, request.Month, day, 0, 0, 0, DateTimeKind.Utc);
            
            var csharpDay = (int)currentDate.DayOfWeek;
            var systemDay = csharpDay == 0 ? 7 : csharpDay; // Make Sunday 7
            
            var currentDateStr = currentDate.ToString("yyyy-MM-dd");
            
            var dayException = exceptions.FirstOrDefault(e => e.ExceptionDate == currentDateStr);
            if (dayException != null && dayException.IsClosed)
            {
                continue; // Closed for the day
            }

            var daySchedules = schedules.Where(s => s.WeekdayId == systemDay).ToList();
            
            foreach (var schedule in daySchedules)
            {
                if (!TimeSpan.TryParse(schedule.StartTime, out var startTime) || 
                    !TimeSpan.TryParse(schedule.EndTime, out var endTime))
                {
                    continue;
                }

                var currentSlotStart = currentDate.Add(startTime);
                var shiftEnd = currentDate.Add(endTime);
                
                while (currentSlotStart.AddMinutes(schedule.SlotDurationMinutes) <= shiftEnd)
                {
                    var currentSlotEnd = currentSlotStart.AddMinutes(schedule.SlotDurationMinutes);

                    var slot = new Slot
                    {
                        TenantId = schedule.TenantId,
                        PractitionerId = schedule.PractitionerId,
                        LocationSpecialtyId = schedule.LocationSpecialtyId,
                        RoomId = schedule.RoomId,
                        SlotStartAt = new DateTimeOffset(currentSlotStart, TimeSpan.Zero),
                        SlotEndAt = new DateTimeOffset(currentSlotEnd, TimeSpan.Zero),
                        MaxCapacity = schedule.MaxPatientsPerSlot,
                        ReservationStatus = "AVAILABLE",
                        Version = 1,
                        CreatedAt = DateTimeOffset.UtcNow
                    };

                    _context.Slots.Add(slot);
                    slotsCreated++;

                    currentSlotStart = currentSlotEnd;
                }
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
        return slotsCreated;
    }
}
