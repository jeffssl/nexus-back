using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Facility;

namespace Nexus.Application.Facilities.Commands.CreateRoom;

/// <summary>
/// Command to create a new room in a specific location.
/// Comando para crear un nuevo consultorio en una sede específica.
/// </summary>
public record CreateRoomCommand(
    int LocationId,
    string Name,
    string RoomType,
    short Capacity,
    bool IsActive) : IRequest<int>;

/// <summary>
/// Validates the CreateRoomCommand properties.
/// Valida las propiedades del CreateRoomCommand.
/// </summary>

public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(v => v.LocationId).GreaterThan(0);
        RuleFor(v => v.Name).MaximumLength(100).NotEmpty();
        RuleFor(v => v.RoomType).MaximumLength(50).NotEmpty();
        RuleFor(v => v.Capacity).GreaterThanOrEqualTo((short)1);
    }
}

/// <summary>
/// Handles the creation of a new room, inheriting the TenantId from the parent location.
/// Maneja la creación de un nuevo consultorio, heredando el TenantId de la sede padre.
/// </summary>
public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
{
    private readonly INexusDbContext _context;

    public CreateRoomCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var location = await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.LocationId == request.LocationId, cancellationToken);

        if (location == null)
        {
            throw new InvalidOperationException($"La sede con ID {request.LocationId} no existe.");
        }

        var entity = new Room
        {
            LocationId = request.LocationId,
            TenantId = location.TenantId,
            Name = request.Name,
            RoomType = request.RoomType,
            Capacity = request.Capacity,
            IsActive = request.IsActive
        };

        _context.Rooms.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.RoomId;
    }
}
