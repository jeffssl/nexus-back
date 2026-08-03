using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.System;

public class User : AuditableEntity
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? ExternalProviderId { get; set; }
    public string FullName { get; set; }
    public string UserType { get; set; }
    public bool IsActive { get; set; }
}
