using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class LittlePersonComputerController : Controller
{
    public LittlePersonComputerController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
