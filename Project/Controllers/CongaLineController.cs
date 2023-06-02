using Microsoft.AspNetCore.Mvc;
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
}
