using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class PythagoreanController : Controller
{
    public PythagoreanController()
    {

    }

    [HttpGet]
    public IActionResult Index(double hypotenuse = 0)
    {
        return View(hypotenuse);
    }

    [HttpPost]
    public IActionResult Index(double sideA, double sideB)
    {
        double valueCalculated = Math.Round(Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2)), 4);
        return RedirectToAction("Index", new { hypotenuse = valueCalculated } );
    }
}
