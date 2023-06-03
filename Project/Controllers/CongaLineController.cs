using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;
using Portfolio.Utilities;

namespace Portfolio.Controllers;

public class CongaLineController : Controller
{
    private readonly Converter _converter = new();

    [HttpGet]
    public IActionResult Index(CongaLineVM vm, string congaLineString)
    {
        if (string.IsNullOrEmpty(congaLineString))
        {
            vm = new CongaLineVM();
        }
        else
        {
            List<char> congaLineList = _converter.StringToListChar(congaLineString);
            CongaLine currentCongaLine = new CongaLine(congaLineList);
            vm = new CongaLineVM(currentCongaLine);
        }

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
        List<char> congaLineList = _converter.StringToListChar(congaLineString);
        CongaLine currentCongaLine = new CongaLine(congaLineList);

        string zombieValue = Request.Form["zombie"];
        string actionValue = Request.Form["action"];
        string indexValue = Request.Form["index"];

        string action = string.IsNullOrEmpty(actionValue) ? null : actionValue;
        char zombie = string.IsNullOrEmpty(zombieValue) ? '?' : Convert.ToChar(zombieValue);
        int index = string.IsNullOrEmpty(indexValue) ? -1 : Convert.ToInt32(indexValue);

        if (action != null)
        {
            switch (action)
            {
                case "engine":
                    currentCongaLine.Engine(zombie);
                    break;
                case "caboose":
                    currentCongaLine.Caboose(zombie);
                    break;
                case "jump":
                    currentCongaLine.JumpInLine(index, zombie);
                    break;
                case "out":
                    currentCongaLine.EveryOneOut(zombie);
                    break;
                case "done":
                    currentCongaLine.YourDone(zombie);
                    break;
                case "brains":
                    currentCongaLine.Brains();
                    break;
                case "rainbow":
                    currentCongaLine.RainbowBrains();
                    break;
            }
        }

        CongaLineVM updatedVm = new CongaLineVM(currentCongaLine);

        return RedirectToAction("Index", new { vm = updatedVm, congaLineString = currentCongaLine.ToString() });
    }
}
