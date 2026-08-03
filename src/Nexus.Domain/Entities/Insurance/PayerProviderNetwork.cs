using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Insurance;

public class PayerProviderNetwork
{
    public int NetworkId { get; set; }
    public int PayerId { get; set; }
    public Guid OrganizationId { get; set; }
    public string? ContractCode { get; set; }
    public string ValidFrom { get; set; }
    public string? ValidTo { get; set; }
    public bool IsActive { get; set; }
}
