using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class DijkstraController : Controller
{
    public DijkstraController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
