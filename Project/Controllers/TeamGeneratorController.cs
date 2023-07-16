using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class TeamGeneratorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GenerateTeams(TeamsModel teams)
    {
        ViewBag.IsValid = false;

        if (!ModelState.IsValid) return View("Index");

        ViewBag.IsValid = true;
        return View("GenerateTeams", teams);
    }
}
