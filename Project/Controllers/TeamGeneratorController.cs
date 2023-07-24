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
            NumPerTeam = Convert.ToInt32(teams.NumPerTeam),
            Names = teams.Names.Split('\n').ToList()
        };

        vm.NumTeams = Convert.ToInt32(Math.Ceiling(vm.Names.Count / Convert.ToDouble(vm.NumPerTeam)));
        vm.Shuffle();

        return View("GenerateTeams", vm);
    }
}
