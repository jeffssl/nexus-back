using FluentValidation;
using MediatR;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Patient;

namespace Nexus.Application.Patients.Commands.CreatePatient;

public record CreatePatientCommand(
    Guid TenantId,
    int DocumentTypeId,
    string DocumentNumber,
    string FirstName,
    string? MiddleName,
    string LastName,
    string? SecondLastName,
    string? BirthDate,
    string? Gender) : IRequest<Guid>;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(v => v.TenantId).NotEmpty();
        RuleFor(v => v.DocumentTypeId).GreaterThan(0);
        RuleFor(v => v.DocumentNumber).MaximumLength(50).NotEmpty();
        RuleFor(v => v.FirstName).MaximumLength(100).NotEmpty();
        RuleFor(v => v.LastName).MaximumLength(100).NotEmpty();
        RuleFor(v => v.MiddleName).MaximumLength(100);
        RuleFor(v => v.SecondLastName).MaximumLength(100);
        RuleFor(v => v.BirthDate).MaximumLength(10);
        RuleFor(v => v.Gender).MaximumLength(20);
    }
}

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly INexusDbContext _context;

    public CreatePatientCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var entityId = Guid.NewGuid();

        var entity = new Patient
        {
            PatientId = entityId,
            TenantId = request.TenantId,
            DocumentTypeId = request.DocumentTypeId,
            DocumentNumber = request.DocumentNumber,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            SecondLastName = request.SecondLastName,
            BirthDate = request.BirthDate,
            Gender = request.Gender,
            IsActive = true
        };

        _context.Patients.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entityId;
    }
}
