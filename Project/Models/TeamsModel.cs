using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class TeamsModel
{
    public string[]? ColorsAvailable { get; set; } = new string[]
    {
        "#ff80ed", "#8a2be2", "#f6546a", "#ffc0cb", "#ffe4e1", "#008080", "#ffff66", "#e6e6fa", "#ffd700", "#ffa500",
        "#00ffff", "#ff7373", "#00ff00", "#d3ffce", "#c6e2ff", "#b0e0e6", "#666666", "#faebd7", "#bada55", "#fa8072"
    };

    [Required(ErrorMessage = "Names field cannot be empty")]
    [RegularExpression(@"^[a-zA-Z]+[a-zA-Z\s\n,._'-]+$", ErrorMessage = "Characters entered must start with a-z and A-Z and only the following characters and special charters are allowed a-z A-Z and , . - _ '")]
    public string? Names { get; set; }

    [Required(ErrorMessage = "Must be a number between 2 and 10")]
    [Range(2, 10)]
    public int? NumTeams { get; set; }

    public string[] Shuffle(string[] arr)
    {
        // https://csharpforums.net/threads/how-to-shuffle-an-array.7102/#:~:text=If%20you%20want%20to%20shuffle%20the%20existing%20array,var%20keys%20%3D%20originalArray.Select%28e%20%3D%3E%20rng.NextDouble%28%29%29.ToArray%28%29%3B%20Array.Sort%28keys%2C%20originalArray%29%3B

        try
        {
            var rng = new Random();
            return arr.OrderBy(e => rng.NextDouble()).ToArray();
        }
        catch
        {
            throw new ArgumentNullException();
        }
        
    }
}