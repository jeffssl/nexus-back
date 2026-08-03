using Nexus.Domain.ValueObjects;

namespace Nexus.Domain.Common;

/// <summary>
/// Marks an entity as isolated by Tenant (Clinic, Hospital, Lab).
/// This interface is used to apply Global Query Filters in EF Core 
/// to implement Row-Level Security (RLS) in the application layer.
/// </summary>
public interface ITenantIsolated
{
    TenantId TenantId { get; }
}
