using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers;

public class CongaLineController : Controller
{
    [HttpGet]
    public IActionResult Index(CongaLineVM vm)
    {
        if (vm.CongaLine.CongaLineLength() > 0)
            return View(vm);

        vm.CongaLine.RainbowBrains();
        vm.CongaLine.Brains();

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(string congaLineString)
    {
        List<char> congaLineList = congaLineString.Split(',').ToList().SelectMany(s => s).ToList();
        CongaLine currentCongaLine = new CongaLine(congaLineList);

        char zombie = Convert.ToChar(Request.Form["zombie"]);
        
        CongaLineVM updatedVm = new()
        {
            CongaLine = currentCongaLine
        };

        return RedirectToAction("Index", new { vm = updatedVm });
    }
}
