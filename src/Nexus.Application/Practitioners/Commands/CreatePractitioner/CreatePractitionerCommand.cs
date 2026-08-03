using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Practitioner;
using Nexus.Domain.ValueObjects;

namespace Nexus.Application.Practitioners.Commands.CreatePractitioner;

/// <summary>
/// Command to create a new practitioner.
/// Comando para crear un nuevo médico/profesional.
/// </summary>
public record CreatePractitionerCommand(
    Guid TenantId,
    int DocumentTypeId,
    string DocumentNumber,
    string FirstName,
    string LastName,
    string? MedicalLicense,
    List<int> SpecialtyIds,
    List<int> LocationIds) : IRequest<Guid>;

/// <summary>
/// Validator for CreatePractitionerCommand.
/// Validador para CreatePractitionerCommand.
/// </summary>
public class CreatePractitionerCommandValidator : AbstractValidator<CreatePractitionerCommand>
{
    public CreatePractitionerCommandValidator()
    {
        RuleFor(v => v.TenantId).NotEmpty();
        RuleFor(v => v.DocumentTypeId).GreaterThan(0);
        RuleFor(v => v.DocumentNumber).MaximumLength(50).NotEmpty();
        RuleFor(v => v.FirstName).MaximumLength(100).NotEmpty();
        RuleFor(v => v.LastName).MaximumLength(100).NotEmpty();
        RuleFor(v => v.MedicalLicense).MaximumLength(50);
        RuleFor(v => v.SpecialtyIds).NotEmpty().WithMessage("At least one specialty is required.");
        RuleFor(v => v.LocationIds).NotEmpty().WithMessage("At least one location is required.");
    }
}

/// <summary>
/// Handler to process the creation of a practitioner and its relationships.
/// Manejador para procesar la creación de un médico y sus relaciones.
/// </summary>
public class CreatePractitionerCommandHandler : IRequestHandler<CreatePractitionerCommand, Guid>
{
    private readonly INexusDbContext _context;

    public CreatePractitionerCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePractitionerCommand request, CancellationToken cancellationToken)
    {
        var entityId = Guid.NewGuid();
        
        var entity = new Practitioner
        {
            PractitionerId = entityId,
            TenantId = request.TenantId,
            DocumentTypeId = request.DocumentTypeId,
            DocumentNumber = request.DocumentNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MedicalLicense = request.MedicalLicense,
            IsActive = true
        };

        _context.Practitioners.Add(entity);

        foreach (var specialtyId in request.SpecialtyIds)
        {
            _context.PractitionerSpecialties.Add(new PractitionerSpecialty
            {
                PractitionerId = entityId,
                TenantId = request.TenantId,
                SpecialtyId = specialtyId,
                IsPrimary = request.SpecialtyIds.First() == specialtyId,
                IsActive = true
            });
        }

        foreach (var locationId in request.LocationIds)
        {
            _context.PractitionerLocations.Add(new PractitionerLocation
            {
                PractitionerId = entityId,
                TenantId = request.TenantId,
                LocationId = locationId,
                IsPrimary = request.LocationIds.First() == locationId,
                StartDate = DateTime.UtcNow.ToString("O"),
                IsActive = true
            });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return entityId;
    }
}
