using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class MadLibsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult DisplayStory(List<string> words, string story)
    {
        return View();
    }

    [HttpGet]
    public IActionResult RoadTrip()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult RoadTrip([Bind("Noun1, Adjective1, Noun2, Adjective2, Adjective3, Verb1, Verb2, Number1, Verb3, Adverb1, Noun3, Color1, Verb4, Noun4, Exclamation1, Verb5, Adverb2, Noun5, Verb6, Verb7, Noun6, PluralNoun1, Verb8, Name1, Verb9, Noun7, Verb10, Adjective4, Adverb3, Adverb4, Noun8, Verb11, Noun9, Adjective5")] RoadTripMadLib madLib)
    {
        ModelState.Clear();
        TryValidateModel(madLib);

        if (ModelState.IsValid)
        {
            List<string> selectedWords = new List<string>()
            {
                madLib.Noun1, madLib.Adjective1, madLib.Noun2, madLib.Adjective2, madLib.Adjective3,
                madLib.Verb1, madLib.Verb2, Convert.ToString(madLib.Number1), madLib.Verb3, madLib.Adverb1, 
                madLib.Noun3, madLib.Color1, madLib.Verb4, madLib.Noun4, madLib.Exclamation1, 
                madLib.Verb5, madLib.Adverb2, madLib.Noun5, madLib.Verb6, madLib.Verb7, 
                madLib.Noun6, madLib.PluralNoun1, madLib.Verb8, madLib.Name1, madLib.Verb9, 
                madLib.Noun7, madLib.Verb10, madLib.Adjective4, madLib.Adverb3, madLib.Adverb4, 
                madLib.Noun8, madLib.Verb11, madLib.Noun9, madLib.Adjective5
            };
            string selectedStory = "Road Trip";

            return RedirectToAction("DisplayStory", new { words = selectedWords, story = selectedStory });
        }

        return View();
    }

    public IActionResult Camping()
    {
        return View();
    }
}
