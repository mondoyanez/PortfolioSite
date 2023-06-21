using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class MadLibsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
