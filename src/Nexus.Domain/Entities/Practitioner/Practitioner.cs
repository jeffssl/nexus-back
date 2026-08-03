using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Practitioner;

public class Practitioner : AuditableEntity
{
    public Guid PractitionerId { get; set; }
    public Guid TenantId { get; set; }
    public int DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MedicalLicense { get; set; }
    public Guid? UserId { get; set; }
    public bool IsActive { get; set; }
}
