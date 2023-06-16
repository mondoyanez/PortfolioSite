namespace Portfolio.Models;

public class ColorInterpolation: Color
{
    // From Greg's answer: https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv/1626175
    // And Wikipedia: https://en.wikipedia.org/wiki/HSL_and_HSV
        
    public string FirstColor { get; set; }

    public string SecondColor { get; set; }

    public int? NumColors { get; set; }
    
    public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
    {
        throw new NotImplementedException();
    }

    public static Color ColorFromHSV(double hue, double saturation, double value)
    {
        throw new NotImplementedException();
    }
}