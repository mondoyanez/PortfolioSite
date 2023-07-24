using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class TeamsModel
{
    [Required(ErrorMessage = "Names field cannot be empty")]
    [RegularExpression(@"^[a-zA-Z]+[a-zA-Z\s\n,._'-]+$", ErrorMessage = "Characters entered must start with a-z and A-Z and only the following characters and special charters are allowed a-z A-Z and , . - _ '")]
    public string Names { get; set; }

    [Required(ErrorMessage = "Must be a number between 2 and 10")]
    [Range(2, 10)]
    public int? NumPerTeam { get; set; }
}