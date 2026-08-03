using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.System.Commands.ArchiveAuditLogs;

public record ArchiveAuditLogsCommand(DateTimeOffset BeforeDate) : IRequest<int>;

public class ArchiveAuditLogsCommandHandler : IRequestHandler<ArchiveAuditLogsCommand, int>
{
    private readonly INexusDbContext _context;

    public ArchiveAuditLogsCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(ArchiveAuditLogsCommand request, CancellationToken cancellationToken)
    {
        var logsToArchive = await _context.AuditLogs
            .Where(a => a.OperatedAt < request.BeforeDate)
            .ToListAsync(cancellationToken);

        if (!logsToArchive.Any())
            return 0;

        var directory = Path.Combine(Directory.GetCurrentDirectory(), "ColdStorage");
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var fileName = $"AuditLogs_{DateTime.UtcNow:yyyyMMddHHmmss}.json";
        var filePath = Path.Combine(directory, fileName);

        var json = JsonSerializer.Serialize(logsToArchive, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json, cancellationToken);

        _context.AuditLogs.RemoveRange(logsToArchive);
        await _context.SaveChangesAsync(cancellationToken);

        return logsToArchive.Count;
    }
}
