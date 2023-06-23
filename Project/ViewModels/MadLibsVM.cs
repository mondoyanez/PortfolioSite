using Portfolio.Models;

namespace Portfolio.ViewModels;
public class MadLibsVM
{
    public string StoryTitle { get; set; }
    public RoadTripMadLib roadTripMadLib { get; set; }
    public CampMadLib campMadLib { get; set; }
}