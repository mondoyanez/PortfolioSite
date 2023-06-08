using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class ColorInterpolator : Controller
{
    public ColorInterpolator()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
