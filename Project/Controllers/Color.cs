using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers;

public class Color : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RGBColor(int? red = 234, int? green = 113, int? blue = 86)
    {
        return View("RGBColor", new Models.Color() { red = red, green = green, blue = blue } );
    }

    [HttpGet]
    public IActionResult ColorInterpolation()
    {
        ViewBag.IsValid = true;
        return View();
    }

    [HttpPost]
    public IActionResult ColorInterpolation([Bind("FirstColor, SecondColor, NumColors")] ColorInterpolation colorInterpolation)
    {
        ModelState.Clear();
        TryValidateModel(colorInterpolation);

        if (ModelState.IsValid)
        {
            ViewBag.IsValid = true;
            ColorInterpolationVM vm = new()
            {
                ColorInterpolation = colorInterpolation
            };
            return View(vm);
        }

        ViewBag.IsValid = false;
        return View();
    }
}
