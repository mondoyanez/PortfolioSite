﻿using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;
public class Pythagorean
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Side A is a required field")]
    [Range(0.00001, Double.MaxValue, ErrorMessage = "Side A must be greater than 0")]
    public double SideA { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Side B is a required field")]
    [Range(0.00001, Double.MaxValue, ErrorMessage = "Side B must be greater than 0")]
    public double SideB { get; set; }

    public double Hypotenuse { get; set; } = 0;

    public void Calculate()
    {
        Hypotenuse = Math.Round(Math.Sqrt(Math.Pow(SideA, 2) + Math.Pow(SideB, 2)), 4);
    }
}