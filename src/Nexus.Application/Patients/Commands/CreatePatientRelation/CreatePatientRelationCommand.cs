using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Application.Patients.Commands.CreatePatientRelation;

public record CreatePatientRelationCommand(
    Guid PrimaryPatientId,
    Guid DependentPatientId,
    string RelationshipType,
    bool CanBookAppointments,
    bool CanAccessMedicalRecords) : IRequest<Guid>;

public class CreatePatientRelationCommandValidator : AbstractValidator<CreatePatientRelationCommand>
{
    public CreatePatientRelationCommandValidator()
    {
        RuleFor(v => v.PrimaryPatientId).NotEmpty();
        RuleFor(v => v.DependentPatientId).NotEmpty();
        RuleFor(v => v.RelationshipType).MaximumLength(50).NotEmpty();
    }
}

public class CreatePatientRelationCommandHandler : IRequestHandler<CreatePatientRelationCommand, Guid>
{
    private readonly INexusDbContext _context;

    public CreatePatientRelationCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePatientRelationCommand request, CancellationToken cancellationToken)
    {
        var relationId = Guid.NewGuid();

        var entity = new PatientRelation
        {
            RelationId = relationId,
            PrimaryPatientId = request.PrimaryPatientId,
            DependentPatientId = request.DependentPatientId,
            RelationshipType = request.RelationshipType,
            CanBookAppointments = request.CanBookAppointments,
            CanAccessMedicalRecords = request.CanAccessMedicalRecords,
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _context.PatientRelations.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return relationId;
    }
}
