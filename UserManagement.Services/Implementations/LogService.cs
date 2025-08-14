// File: LogService.cs — domain logging service implementation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

/// <summary>
/// Provides basic logging capabilities stored via the shared <see cref="IDataContext"/>.
/// Includes helpers to query logs globally or per user, with simple paging.
/// </summary>
public class LogService : ILogService
{
    private readonly IDataContext _dataContext;
    // We log into the same data context so logs are stored with the app data
    public LogService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    // Returns latest logs ordered by time, supports simple paging
    public IEnumerable<LogEntry> GetAll(int skip = 0, int take = 50)
    {
        return _dataContext.GetAll<LogEntry>()
            .OrderByDescending(l => l.CreatedAtUtc)
            .Skip(skip)
            .Take(take)
            .ToList();
    }

    // Returns latest logs for a specific user
    public IEnumerable<LogEntry> GetByUser(long userId, int skip = 0, int take = 100)
    {
        return _dataContext.GetAll<LogEntry>()
            .Where(l => l.UserId == userId)
            .OrderByDescending(l => l.CreatedAtUtc)
            .Skip(skip)
            .Take(take)
            .ToList();
    }

    // Creates a new log record
    public void Log(string action, string? description = null, long? userId = null)
    {
        var entry = new LogEntry
        {
            Action = action,
            Description = description,
            UserId = userId,
            CreatedAtUtc = DateTime.UtcNow
        };
        _dataContext.Create(entry);
    }

    // Load a single log entry by id
    public LogEntry? GetById(long id)
    {
        return _dataContext.GetAll<LogEntry>().FirstOrDefault(l => l.Id == id);
    }

    // Async wrappers for convenience
    public Task<IEnumerable<LogEntry>> GetAllAsync(int skip = 0, int take = 50)
        => Task.FromResult(GetAll(skip, take));

    public Task<IEnumerable<LogEntry>> GetByUserAsync(long userId, int skip = 0, int take = 100)
        => Task.FromResult(GetByUser(userId, skip, take));

    public Task<LogEntry?> GetByIdAsync(long id)
        => Task.FromResult(GetById(id));

    public Task LogAsync(string action, string? description = null, long? userId = null)
    {
        var entry = new LogEntry
        {
            Action = action,
            Description = description,
            UserId = userId,
            CreatedAtUtc = DateTime.UtcNow
        };
        return _dataContext.CreateAsync(entry);
    }
}


