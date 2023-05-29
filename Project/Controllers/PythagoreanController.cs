using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class PythagoreanController : Controller
{
    public PythagoreanController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
