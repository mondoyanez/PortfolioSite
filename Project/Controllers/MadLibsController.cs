using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.ViewModels;

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
        RoadTripMadLib roadTripMadLib = new();
        CampMadLib campMadLib = new();

        if (story == "Road Trip")
        {
            RoadTripMadLib temp = new()
            {
                Noun1 = words[0],
                Adjective1 = words[1],
                Noun2 = words[2],
                Adjective2 = words[3],
                Adjective3 = words[4],
                Verb1 = words[5],
                Verb2 = words[6],
                Number1 = Convert.ToInt32(words[7]),
                Verb3 = words[8],
                Adverb1 = words[9],
                Noun3 = words[10],
                Color1 = words[11],
                Verb4 = words[12],
                Noun4 = words[13],
                Exclamation1 = words[14],
                Verb5 = words[15],
                Adverb2 = words[16],
                Noun5 = words[17],
                Verb6 = words[18],
                Verb7 = words[19],
                Noun6 = words[20],
                PluralNoun1 = words[21],
                Verb8 = words[22],
                Name1 = words[23],
                Verb9 = words[24],
                Noun7 = words[25],
                Verb10 = words[26],
                Adjective4 = words[27],
                Adverb3 = words[28],
                Adverb4 = words[29],
                Noun8 = words[30],
                Verb11 = words[31],
                Noun9 = words[32],
                Adjective5 = words[33]
            };
            roadTripMadLib = temp;
        }

        if (story == "Camping")
        {
            CampMadLib temp = new()
            {
                Name1 = words[0],
                CampName1 = words[1],
                Adjective1 = words[2],
                Activity1 = words[3],
                Activity2 = words[4],
                PluralNoun1 = words[5],
                Adjective2 = words[6],
                Noun1 = words[7],
                NickName1 = words[8]
            };
            campMadLib = temp;
        }

        MadLibsVM vm = new()
        {
            StoryTitle = story,
            roadTripMadLib = roadTripMadLib,
            campMadLib = campMadLib
        };

        return View(vm);
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
