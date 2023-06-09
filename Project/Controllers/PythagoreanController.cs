using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class PythagoreanController : Controller
{
    [HttpGet]
    public IActionResult Index(double sideA = 0, double sideB = 0)
    {
        Pythagorean pythagorean = new()
        {
            SideA = sideA,
            SideB = sideB
        };
        pythagorean.Calculate();
        ViewBag.IsValid = true;

        return View(pythagorean);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index([Bind("SideA, SideB")] Pythagorean pythagorean)
    {
        ModelState.Clear();
        TryValidateModel(pythagorean);

        if (!ModelState.IsValid)
        {
            ViewBag.IsValid = false;
            return View(pythagorean);
        }

        return RedirectToAction("Index", new { sideA = pythagorean.SideA, sideB = pythagorean.SideB } );
    }
}
