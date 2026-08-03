namespace Nexus.Domain.Common;

public interface ISoftDeletable
{
    DateTimeOffset? DeletedAt { get; set; }
    Guid? DeletedBy { get; set; }
    
    // In Entity Framework we will use this to automatically filter deleted items
    // and prevent physical deletes.
}
