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
        if (red is < 0 or > 255 || green is < 0 or > 255 || blue is < 0 or > 255)
            return "ZZZZZZ";
        
        return red?.ToString("X2") + green?.ToString("X2") + blue?.ToString("X2");
    }

    public Color HexToColor(string hex)
    {
        string RGBR, RGBG, RGBB;
        int r, g, b;

        if (hex.Substring(0,1).Equals("#"))
        {
            RGBR = hex.Substring(1, 2);
            r = Convert.ToInt32(RGBR, 16);

            RGBG = hex.Substring(3, 2);
            g = Convert.ToInt32(RGBG, 16);

            RGBB = hex.Substring(5, 2);
            b = Convert.ToInt32(RGBB, 16);
        }
        else 
        {
            RGBR = hex.Substring(0, 2);
            r = Convert.ToInt32(RGBR, 16);

            RGBG = hex.Substring(2, 2);
            g = Convert.ToInt32(RGBG, 16);

            RGBB = hex.Substring(4, 2);
            b = Convert.ToInt32(RGBB, 16);
        }

        Color color = new Color() { red = r, green = g, blue = b };

        return color;
    }

    public double GetHue()
    {
        throw new NotImplementedException();
    }
}