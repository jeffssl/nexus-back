using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Organization;

namespace Nexus.Application.Locations.Commands.CreateLocation;

public record CreateLocationCommand(
    Guid OrganizationId,
    Guid TenantId,
    string Name,
    string? Code,
    string Timezone,
    int? CityId,
    string? AddressLine1,
    decimal? Latitude,
    decimal? Longitude,
    bool IsHeadOffice = false) : IRequest<int>;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(v => v.OrganizationId).NotEmpty();
        RuleFor(v => v.TenantId).NotEmpty();
        RuleFor(v => v.Name).MaximumLength(150).NotEmpty();
        RuleFor(v => v.Code).MaximumLength(20);
        RuleFor(v => v.Timezone).MaximumLength(50).NotEmpty();
    }
}

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, int>
{
    private readonly INexusDbContext _context;

    public CreateLocationCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = new Location
        {
            OrganizationId = request.OrganizationId,
            TenantId = request.TenantId,
            Name = request.Name,
            Code = request.Code,
            Timezone = request.Timezone,
            IsHeadOffice = request.IsHeadOffice,
            IsActive = true
        };

        _context.Locations.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        if (request.Latitude.HasValue && request.Longitude.HasValue && request.CityId.HasValue)
        {
            var address = new LocationAddress
            {
                LocationId = entity.LocationId,
                TenantId = request.TenantId,
                CityId = request.CityId.Value,
                AddressLine1 = request.AddressLine1 ?? "N/A",
                Latitude = request.Latitude.Value,
                Longitude = request.Longitude.Value,
                IsPrimary = true,
                IsActive = true
            };
            _context.LocationAddresses.Add(address);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return entity.LocationId;
    }
}
