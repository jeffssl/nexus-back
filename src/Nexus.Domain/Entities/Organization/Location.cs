using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Organization;

public class Location : AuditableEntity
{
    public int LocationId { get; set; }
    public Guid OrganizationId { get; set; }
    public Guid TenantId { get; set; }
    public string Name { get; set; }
    public string? Code { get; set; }
    public bool IsHeadOffice { get; set; }
    public string Timezone { get; set; }
    public bool IsActive { get; set; }
}
