using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class Color : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
