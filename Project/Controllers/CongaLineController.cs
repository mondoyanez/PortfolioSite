using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class CongaLineController : Controller
{
    public CongaLineController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }
}
