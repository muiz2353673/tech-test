// File: LogEntry.cs — EF Core entity representing a log entry
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

/// <summary>
/// This stores basic log info for actions in the app.
/// It's kept simple on purpose so it's easy to read and extend later.
/// </summary>
public class LogEntry
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    /// <summary>
    /// Optional reference to a user affected by the action
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// Short action name e.g. Created, Viewed, Updated, Deleted
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Action { get; set; } = string.Empty;

    /// <summary>
    /// Optional human-friendly description of the action
    /// </summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// When the action happened (UTC)
    /// </summary>
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}


