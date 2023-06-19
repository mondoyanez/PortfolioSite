using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class Color : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RGBColor(int? red, int? green, int? blue)
    {
        return View("RGBColor", new Models.Color() { red = red, green = green, blue = blue } );
    }

    public IActionResult ColorInterpolation()
    {
        return View();
    }
}
