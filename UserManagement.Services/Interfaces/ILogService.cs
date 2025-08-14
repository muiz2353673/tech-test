// File: ILogService.cs — logging service contract
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

/// <summary>
/// Service abstraction for recording and querying application log entries.
/// Supports basic paging and both sync and async access patterns.
/// </summary>
public interface ILogService
{
    IEnumerable<LogEntry> GetAll(int skip = 0, int take = 50);
    IEnumerable<LogEntry> GetByUser(long userId, int skip = 0, int take = 100);
    LogEntry? GetById(long id);
    void Log(string action, string? description = null, long? userId = null);

    // Async APIs
    Task<IEnumerable<LogEntry>> GetAllAsync(int skip = 0, int take = 50);
    Task<IEnumerable<LogEntry>> GetByUserAsync(long userId, int skip = 0, int take = 100);
    Task<LogEntry?> GetByIdAsync(long id);
    Task LogAsync(string action, string? description = null, long? userId = null);
}


