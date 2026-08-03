using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Archive;

public class AppointmentArchive
{
    public Guid AppointmentId { get; set; }
    public DateTimeOffset ArchivedAt { get; set; }
    public Guid? ArchivedByUserId { get; set; }
    public string OriginalData { get; set; }
}
