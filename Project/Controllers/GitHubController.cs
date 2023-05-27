using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class GitHubController : Controller
{
    public GitHubController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
