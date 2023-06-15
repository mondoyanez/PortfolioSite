using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Color
{
    [Range(0, 255, ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public int? red { get; set; } = 0;
    [Range(0, 255, ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public int? green { get; set; } = 0;
    [Range(0, 255, ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public int? blue { get; set; } = 0;

    public string RGBToHex()
    {
        throw new NotImplementedException();
    }

    public Color HexToColor(string hex)
    {
        throw new NotImplementedException();
    }

    public double GetHue()
    {
        throw new NotImplementedException();
    }
}