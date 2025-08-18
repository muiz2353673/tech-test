// File: LogListViewModel.cs — view models for logs listing
using System;

namespace UserManagement.Web.Models.Logs;

public class LogListViewModel
{
    // List of logs to render on the screen
    public List<LogListItemViewModel> Items { get; set; } = new();
    // Current page for simple pagination
    public int Page { get; set; } = 1;
    // How many items to show per page
    public int PageSize { get; set; } = 25;
    // Optional: show only logs for a user
    public long? UserId { get; set; }
}

public class LogListItemViewModel
{
    // Minimal info for listing log entries
    public long Id { get; set; }
    public long? UserId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}


