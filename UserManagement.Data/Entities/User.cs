// File: User.cs — EF Core entity representing a user
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

/// <summary>
/// This is the basic user entity we store in the in-memory database.
/// I added DateOfBirth so we can show it in the UI and edit it.
/// </summary>
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    /// <summary>
    /// First name of the user
    /// </summary>
    public string Forename { get; set; } = default!;

    /// <summary>
    /// Last name of the user
    /// </summary>
    public string Surname { get; set; } = default!;

    /// <summary>
    /// Email address for contacting the user
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// If true, the account is considered active
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Optional birthday so we can show more info on users
    /// </summary>
    public DateTime? DateOfBirth { get; set; }
}
