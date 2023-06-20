using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class ColorInterpolation: Color
{
    // From Greg's answer: https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv/1626175
    // And Wikipedia: https://en.wikipedia.org/wiki/HSL_and_HSV

    [Required(ErrorMessage = "First color is a required field.")]
    public string FirstColor { get; set; }

    [Required(ErrorMessage = "Second color is a required field.")]
    public string SecondColor { get; set; }

    [Range(2, 50, ErrorMessage = "Number of colors field must be between {1} and {2}.")]
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
        double redPrime = 0, greenPrime = 0, bluePrime = 0;
            double saturationDecimal = saturation / 100, valueDecimal = value / 100;

            double c = valueDecimal * saturationDecimal;
            double x = c * (1 - Math.Abs((hue / 60) % 2 - 1));
            double m = valueDecimal - c;

            if (hue >= 0 && hue < 60)
            {
                redPrime = c;
                greenPrime = x;
                bluePrime = 0;
            }
            else if (hue >= 60 && hue < 120)
            {
                redPrime = x;
                greenPrime = c;
                bluePrime = 0;
            }
            else if (hue >= 120 && hue < 180)
            {
                redPrime = 0;
                greenPrime = c;
                bluePrime = x;
            }
            else if (hue >= 180 && hue < 240)
            {
                redPrime = 0;
                greenPrime = x;
                bluePrime = c;
            }
            else if (hue >= 240 && hue < 300)
            {
                redPrime = x;
                greenPrime = 0;
                bluePrime = c;
            }
            else if (hue >= 300 && hue < 360)
            {
                redPrime = c;
                greenPrime = 0;
                bluePrime = x;
            }

            Color color = new Color { red = (int)Math.Round((redPrime + m) * 255), green = (int)Math.Round((greenPrime + m) * 255), blue = (int)Math.Round((bluePrime + m) * 255) };
            return color;
    }
}