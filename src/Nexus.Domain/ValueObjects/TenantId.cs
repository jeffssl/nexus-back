namespace Nexus.Domain.ValueObjects;

/// <summary>
/// A strongly-typed identifier for Tenants (Organizations).
/// Prevents accidental mixing of Guids (e.g., passing a UserId where a TenantId is expected).
/// </summary>
public readonly record struct TenantId(Guid Value)
{
    public static TenantId Empty => new(Guid.Empty);
    public static TenantId New() => new(Guid.NewGuid()); // In the future, this can use UUIDv7 generation
    
    public override string ToString() => Value.ToString();
}
