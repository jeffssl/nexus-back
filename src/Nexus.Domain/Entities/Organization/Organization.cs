using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Organization;

public class Organization : AuditableEntity
{
    public Guid OrganizationId { get; set; }
    public string LegalName { get; set; }
    public string? TradeName { get; set; }
    public string? TaxId { get; set; }
    public int? DocumentTypeId { get; set; }
    public int OrganizationTypeId { get; set; }
    public int CountryId { get; set; }
    public string? Website { get; set; }
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; }
}
