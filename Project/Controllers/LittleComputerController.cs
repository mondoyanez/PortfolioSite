using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class LittleComputerController : Controller
{
    public LittleComputerController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
