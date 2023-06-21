using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Controllers;

public class Color : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RGBColor(int? red = 234, int? green = 113, int? blue = 86)
    {
        return View("RGBColor", new Models.Color() { red = red, green = green, blue = blue } );
    }

    [HttpGet]
    public IActionResult ColorInterpolation(List<string> hexValues)
    {
        ColorInterpolationVM vm = new()
        {
            ColorInterpolation = new(),
            ListColors = hexValues
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ColorInterpolation([Bind("FirstColor, SecondColor, NumColors")] ColorInterpolation colorInterpolation)
    {
        ModelState.Clear();
        TryValidateModel(colorInterpolation);

        if (ModelState.IsValid)
        {
            ColorInterpolationVM vm = new()
            {
                ColorInterpolation = colorInterpolation
            };

            if (colorInterpolation.NumColors == 2)
            {
                if (colorInterpolation.FirstColor.Substring(0, 1).Equals("#"))
                {
                    vm.ListColors.Add(colorInterpolation.FirstColor.Substring(1).ToUpper());
                }
                else
                {
                    vm.ListColors.Add(colorInterpolation.FirstColor.ToUpper());
                }

                if (colorInterpolation.SecondColor.Substring(0, 1).Equals("#"))
                {
                    vm.ListColors.Add(colorInterpolation.SecondColor.Substring(1).ToUpper());
                }
                else
                {
                    vm.ListColors.Add(colorInterpolation.SecondColor.ToUpper());
                }

                return RedirectToAction("ColorInterpolation", new { hexValues = vm.ListColors });
            }

            if (colorInterpolation.FirstColor.Substring(0, 1).Equals("#"))
            {
                vm.ListColors.Add(colorInterpolation.FirstColor.Substring(1).ToUpper());
            }
            else
            {
                vm.ListColors.Add(colorInterpolation.FirstColor.ToUpper());
            }

            Models.Color colorStart = new();
            Models.Color colorEnd = new();

            colorStart = colorStart.HexToColor(vm.ColorInterpolation.FirstColor);
            colorEnd = colorEnd.HexToColor(vm.ColorInterpolation.SecondColor);

            Models.ColorInterpolation.ColorToHSV(colorStart, out double hueStart, out double saturationStart, out double valueStart);
            Models.ColorInterpolation.ColorToHSV(colorEnd, out double hueEnd, out double saturationEnd, out double valueEnd);

            double hueIncrement = Convert.ToDouble((hueEnd - hueStart) / vm.ColorInterpolation.NumColors);
            double satIncrement = Convert.ToDouble((saturationEnd - saturationStart) / vm.ColorInterpolation.NumColors);
            double valueIncrement = Convert.ToDouble((valueEnd - valueStart) / vm.ColorInterpolation.NumColors);

            for (int i = 1; i < vm.ColorInterpolation.NumColors - 1; i++)
            {
                double newHue = Convert.ToDouble(hueStart + hueIncrement * i);
                double newSat = Convert.ToDouble(saturationStart + satIncrement * i);
                double newValue = Convert.ToDouble(valueStart + valueIncrement * i);

                Models.Color newColor = Models.ColorInterpolation.ColorFromHSV(newHue, newSat, newValue);
                vm.ListColors.Add(newColor.RGBToHex());
            }

            if (colorInterpolation.SecondColor.Substring(0, 1).Equals("#"))
            {
                vm.ListColors.Add(colorInterpolation.SecondColor.Substring(1).ToUpper());
            }
            else
            {
                vm.ListColors.Add(colorInterpolation.SecondColor.ToUpper());
            }

            return RedirectToAction("ColorInterpolation", new { hexValues = vm.ListColors });
        }

        return View();
    }
}
