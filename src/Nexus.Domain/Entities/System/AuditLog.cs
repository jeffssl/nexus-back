using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.System;

public class AuditLog
{
    public Guid AuditLogId { get; set; }
    public string TableName { get; set; }
    public string RecordId { get; set; }
    public string Operation { get; set; }
    public Guid? UserId { get; set; }
    public DateTimeOffset OperatedAt { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
}
