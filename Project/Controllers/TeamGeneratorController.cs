using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

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

        TeamsGeneratorVM vm = new TeamsGeneratorVM()
        {
            NumTeams = Convert.ToInt32(teams.NumTeams),
            Names = teams.Names.Split('\n').ToList()
        };

        return View("GenerateTeams", vm);
    }
}
