using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class ColorInterpolation: Color
{
    // From Greg's answer: https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv/1626175
    // And Wikipedia: https://en.wikipedia.org/wiki/HSL_and_HSV

    [Required]
    public string FirstColor { get; set; }

    [Required]
    public string SecondColor { get; set; }

    [Range(2, 50)]
    public int? NumColors { get; set; }
    
    public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
    {
        int max = Math.Max((byte)color.red, Math.Max((byte)color.green, (byte)color.blue));
        int min = Math.Min((byte)color.red, Math.Min((byte)color.green, (byte)color.blue));

        hue = color.GetHue();
        saturation = Math.Round(((max == 0) ? 0 : ((max / 255d) - (min / 255d)) / (max / 255d)) * 100, 1);
        value = Math.Round((max / 255d) * 100, 1);
    }

    public static Color ColorFromHSV(double hue, double saturation, double value)
    {
        throw new NotImplementedException();
    }
}