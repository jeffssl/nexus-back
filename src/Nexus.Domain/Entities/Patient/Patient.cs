using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Patient;

public class Patient : AuditableEntity
{
    public Guid PatientId { get; set; }
    public Guid TenantId { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? SecondLastName { get; set; }
    public string? BirthDate { get; set; }
    public string? Gender { get; set; }
    public Guid? UserId { get; set; }
    public bool IsActive { get; set; }
}
