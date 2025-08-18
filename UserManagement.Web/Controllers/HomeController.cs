// File: HomeController.cs — MVC home page controller
namespace UserManagement.WebMS.Controllers;

/// <summary>
/// Minimal home page controller.
/// </summary>
public class HomeController : Controller
{
    [HttpGet]
    public ViewResult Index() => View();
}
