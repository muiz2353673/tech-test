// File: UserListViewModel.cs — view models for user listing and forms
using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users;

public class UserListViewModel
{
    // This holds all the users to display in the table
    public List<UserListItemViewModel> Items { get; set; } = new();
}

public class UserListItemViewModel
{
    // This is a slim view of a user for listing screens
    public long Id { get; set; }
    public string? Forename { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
}

public class UserCreateViewModel
{
    // This model is for the Add User screen and has validation annotations
    [Required(ErrorMessage = "Forename is required")]
    [StringLength(100, ErrorMessage = "Forename cannot exceed 100 characters")]
    public string Forename { get; set; } = string.Empty;

    [Required(ErrorMessage = "Surname is required")]
    [StringLength(100, ErrorMessage = "Surname cannot exceed 100 characters")]
    public string Surname { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }
}

public class UserEditViewModel
{
    // This model is for the Edit User screen and has validation annotations
    public long Id { get; set; }

    [Required(ErrorMessage = "Forename is required")]
    [StringLength(100, ErrorMessage = "Forename cannot exceed 100 characters")]
    public string Forename { get; set; } = string.Empty;

    [Required(ErrorMessage = "Surname is required")]
    [StringLength(100, ErrorMessage = "Surname cannot exceed 100 characters")]
    public string Surname { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }
}

public class UserDetailViewModel
{
    // Used on the View page to show all user info
    public long Id { get; set; }
    public string Forename { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
}

public class UserDeleteViewModel
{
    // This model is shown on the delete confirmation page
    public long Id { get; set; }
    public string Forename { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
