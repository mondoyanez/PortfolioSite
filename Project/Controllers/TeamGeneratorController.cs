using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class TeamGeneratorController : Controller
{
    public TeamGeneratorController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
