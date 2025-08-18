// File: UsersController.cs — handles user CRUD UI actions
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

/// <summary>
/// Handles user CRUD pages and filter listings. Uses services for data and logging.
/// </summary>
[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogService _logService;
    public UsersController(IUserService userService, ILogService logService)
    {
        // Save services into fields so we can use them in actions
        _userService = userService;
        _logService = logService;
    }

    [HttpGet]
    // Shows all users (now using async service call)
    public async Task<ViewResult> List()
    {
        var users = await _userService.GetAllAsync();
        var items = users.Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(model);
    }

    [HttpGet]
    [Route("active")]
    // Shows only active users (kept sync because it's a simple filter on memory)
    public ViewResult ListActive()
    {
        var items = _userService.FilterByActive(true).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View("List", model);
    }

    [HttpGet]
    [Route("inactive")]
    // Shows only inactive users
    public ViewResult ListInactive()
    {
        var items = _userService.FilterByActive(false).Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive,
            DateOfBirth = p.DateOfBirth
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View("List", model);
    }

    [HttpGet]
    [Route("add")]
    // Renders the form to add a new user
    public ViewResult Add()
    {
        var model = new UserCreateViewModel();
        return View(model);
    }

    [HttpPost]
    [Route("add")]
    // Handles the posted form for creating a user
    public async Task<IActionResult> Add(UserCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new User
        {
            Forename = model.Forename,
            Surname = model.Surname,
            Email = model.Email,
            IsActive = model.IsActive,
            DateOfBirth = model.DateOfBirth
        };

        await _userService.AddAsync(user);
        await _logService.LogAsync("Created", $"User created: {user.Forename} {user.Surname}", user.Id);
        
        TempData["SuccessMessage"] = "User created successfully.";
        return RedirectToAction("List");
    }

    [HttpGet]
    [Route("{id}/view")]
    // Shows the details for one user
    public async Task<IActionResult> View(long id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        await _logService.LogAsync("Viewed", $"Viewed user {user.Forename} {user.Surname}", user.Id);

        var model = new UserDetailViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname,
            Email = user.Email,
            IsActive = user.IsActive,
            DateOfBirth = user.DateOfBirth
        };

        return View(model);
    }

    [HttpGet]
    [Route("{id}/edit")]
    // Renders the edit form
    public async Task<IActionResult> Edit(long id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var model = new UserEditViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname,
            Email = user.Email,
            IsActive = user.IsActive,
            DateOfBirth = user.DateOfBirth
        };

        return View(model);
    }

    [HttpPost]
    [Route("{id}/edit")]
    // Handles the posted form to update the user
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userService.GetByIdAsync(model.Id);
        if (user == null)
        {
            return NotFound();
        }

        user.Forename = model.Forename;
        user.Surname = model.Surname;
        user.Email = model.Email;
        user.IsActive = model.IsActive;
        user.DateOfBirth = model.DateOfBirth;

        await _userService.UpdateAsync(user);
        await _logService.LogAsync("Updated", $"User updated: {user.Forename} {user.Surname}", user.Id);
        
        TempData["SuccessMessage"] = "User updated successfully.";
        return RedirectToAction("List");
    }

    [HttpGet]
    [Route("{id}/delete")]
    // Shows a confirmation screen for delete
    public async Task<IActionResult> Delete(long id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var model = new UserDeleteViewModel
        {
            Id = user.Id,
            Forename = user.Forename,
            Surname = user.Surname,
            Email = user.Email,
            IsActive = user.IsActive,
            DateOfBirth = user.DateOfBirth
        };

        return View(model);
    }

    [HttpPost]
    [Route("{id}/delete")]
    // Deletes the user after confirmation
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        await _userService.DeleteAsync(id);
        await _logService.LogAsync("Deleted", $"User deleted: {user.Forename} {user.Surname}", user.Id);
        
        TempData["SuccessMessage"] = "User deleted successfully.";
        return RedirectToAction("List");
    }
}
