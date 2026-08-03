using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexus.Domain.ValueObjects;

namespace Nexus.Infrastructure.Persistence.ValueConverters;

/// <summary>
/// Tells EF Core how to convert the TenantId value object to a Guid for PostgreSQL.
/// </summary>
public class TenantIdConverter : ValueConverter<TenantId, Guid>
{
    public TenantIdConverter() 
        : base(
            v => v.Value,
            v => new TenantId(v))
    {
    }
}
