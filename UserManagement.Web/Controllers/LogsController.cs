// File: LogsController.cs — handles log listing and details
using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Logs;

namespace UserManagement.WebMS.Controllers;

/// <summary>
/// Displays application log entries and individual log details.
/// </summary>
[Route("logs")]
public class LogsController : Controller
{
    private readonly ILogService _logService;
    public LogsController(ILogService logService)
    {
        // Keep a reference to the log service so we can fetch logs
        _logService = logService;
    }

    [HttpGet]
    // This lists logs with simple paging (page, pageSize)
    public ViewResult Index(int page = 1, int pageSize = 25)
    {
        var skip = (page - 1) * pageSize;
        var logs = _logService.GetAll(skip, pageSize)
            .Select(l => new LogListItemViewModel
            {
                Id = l.Id,
                UserId = l.UserId,
                Action = l.Action,
                Description = l.Description,
                CreatedAtUtc = l.CreatedAtUtc
            }).ToList();

        var model = new LogListViewModel
        {
            Items = logs,
            Page = page,
            PageSize = pageSize
        };

        return View(model);
    }

    [HttpGet]
    [Route("{id}")]
    // This shows one log entry by id
    public IActionResult Details(long id)
    {
        var entry = _logService.GetById(id);
        if (entry == null)
        {
            return NotFound();
        }

        var model = new LogListItemViewModel
        {
            Id = entry.Id,
            UserId = entry.UserId,
            Action = entry.Action,
            Description = entry.Description,
            CreatedAtUtc = entry.CreatedAtUtc
        };

        return View(model);
    }

    [HttpGet]
    [Route("user/{userId}")]
    // This lists logs only for a specific user
    public ViewResult ForUser(long userId, int page = 1, int pageSize = 25)
    {
        var skip = (page - 1) * pageSize;
        var logs = _logService.GetByUser(userId, skip, pageSize)
            .Select(l => new LogListItemViewModel
            {
                Id = l.Id,
                UserId = l.UserId,
                Action = l.Action,
                Description = l.Description,
                CreatedAtUtc = l.CreatedAtUtc
            }).ToList();

        var model = new LogListViewModel
        {
            Items = logs,
            Page = page,
            PageSize = pageSize,
            UserId = userId
        };

        return View("Index", model);
    }
}


