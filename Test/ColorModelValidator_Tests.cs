using Portfolio.Models;

namespace Test;

public class ColorModelValidator_Tests
{
    private Color MakeValidColor()
    {
        Color color = new()
        {
            red = 125,
            green = 122,
            blue = 132
        };

        return color;
    }

    [Test]
    public void ValidColor_IsValid()
    {
        // Arrange
        Color color = MakeValidColor();

        // Act
        ModelValidator mv = new ModelValidator(color);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void ValidColor_InvalidMinRangeRed_IsNotValid()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = -10;

        // Act
        ModelValidator mv = new ModelValidator(color);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidColor_InvalidMaxRangeRed_IsNotValid()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 300;

        // Act
        ModelValidator mv = new ModelValidator(color);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidColor_InvalidMinRangeGreen_IsNotValid()
    {
        // Arrange
        Color color = MakeValidColor();
        color.green = -10;

        // Act
        ModelValidator mv = new ModelValidator(color);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidColor_InvalidMaxRangeGreen_IsNotValid()
    {
        // Arrange
        Color color = MakeValidColor();
        color.green = 300;

        // Act
        ModelValidator mv = new ModelValidator(color);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidColor_InvalidMinRangeBlue_IsNotValid()
    {
        // Arrange
        Color color = MakeValidColor();
        color.blue = -10;

        // Act
        ModelValidator mv = new ModelValidator(color);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidColor_InvalidMaxRangeBlue_IsNotValid()
    {
        // Arrange
        Color color = MakeValidColor();
        color.blue = 300;

        // Act
        ModelValidator mv = new ModelValidator(color);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidColor_RGBToHex_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo("7D7A84"));
        });
    }

    [Test]
    public void ValidColor_RGBToHexValueChanged_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 255;
        color.green = 40;
        color.blue = 20;

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo("FF2814"));
        });
    }

    [Test]
    public void ValidColor_RGBToHexInvalidColorRedMax_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 300;

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("red"), Is.True);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo("ZZZZZZ"));
        });
    }

    [Test]
    public void ValidColor_RGBToHexInvalidColorRedMin_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = -10;

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("red"), Is.True);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo("ZZZZZZ"));
        });
    }

    [Test]
    public void ValidColor_RGBToHexInvalidColorGreenMax_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.green = 300;

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.True);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo("ZZZZZZ"));
        });
    }

    [Test]
    public void ValidColor_RGBToHexInvalidColorGreenMin_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.green = -10;

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.True);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo("ZZZZZZ"));
        });
    }

    [Test]
    public void ValidColor_RGBToHexInvalidColorBlueMax_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.blue = 300;

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.True);
            Assert.That(actual, Is.EqualTo("ZZZZZZ"));
        });
    }

    [Test]
    public void ValidColor_RGBToHexInvalidColorBlueMin_ShouldReturnProperHexValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.blue = -10;

        // Act
        ModelValidator mv = new ModelValidator(color);
        string actual = color.RGBToHex();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.True);
            Assert.That(actual, Is.EqualTo("ZZZZZZ"));
        });
    }

    [Test]
    public void ValidColor_HexToColorBlueWithPoundSign_ShouldReturnProperColor()
    {
        // Arrange
        Color color = new Color();

        // Act
        Color actual = color.HexToColor("#0000FF");
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(0));
            Assert.That(actual.green, Is.EqualTo(0));
            Assert.That(actual.blue, Is.EqualTo(255));
        });
    }

    [Test]
    public void ValidColor_HexToColorRedWithoutPoundSign_ShouldReturnProperColor()
    {
        // Arrange
        Color color = new Color();

        // Act
        Color actual = color.HexToColor("FF0000");
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(255));
            Assert.That(actual.green, Is.EqualTo(0));
            Assert.That(actual.blue, Is.EqualTo(0));
        });
    }

    [Test]
    public void ValidColor_HexToColorGreenWithPoundSign_ShouldReturnProperColor()
    {
        // Arrange
        Color color = new Color();

        // Act
        Color actual = color.HexToColor("#00FF00");
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(0));
            Assert.That(actual.green, Is.EqualTo(255));
            Assert.That(actual.blue, Is.EqualTo(0));
        });
    }

    [Test]
    public void ValidColor_HexToColorDeepBushWithPoundSign_ShouldReturnProperColor()
    {
        // Arrange
        Color color = new Color();

        // Act
        Color actual = color.HexToColor("#E46493");
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(228));
            Assert.That(actual.green, Is.EqualTo(100));
            Assert.That(actual.blue, Is.EqualTo(147));
        });
    }

    [Test]
    public void ValidColor_HexToColorLightGreenWithoutPoundSign_ShouldReturnProperColor()
    {
        // Arrange
        Color color = new Color();

        // Act
        Color actual = color.HexToColor("93E464");
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(147));
            Assert.That(actual.green, Is.EqualTo(228));
            Assert.That(actual.blue, Is.EqualTo(100));
        });
    }

    [Test]
    public void ValidColor_GetHueColorBlue_ShouldReturnProperHueValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 0;
        color.green = 0;
        color.blue = 255;

        // Act
        double actual = color.GetHue();
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo(240));
            Assert.That(color.red, Is.EqualTo(0));
            Assert.That(color.green, Is.EqualTo(0));
            Assert.That(color.blue, Is.EqualTo(255));
        });
    }

    [Test]
    public void ValidColor_GetHueColorRed_ShouldReturnProperHueValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 255;
        color.green = 0;
        color.blue = 0;

        // Act
        double actual = color.GetHue();
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo(0));
            Assert.That(color.red, Is.EqualTo(255));
            Assert.That(color.green, Is.EqualTo(0));
            Assert.That(color.blue, Is.EqualTo(0));
        });
    }

    [Test]
    public void ValidColor_GetHueColorGreen_ShouldReturnProperHueValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 0;
        color.green = 255;
        color.blue = 0;

        // Act
        double actual = color.GetHue();
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo(120));
            Assert.That(color.red, Is.EqualTo(0));
            Assert.That(color.green, Is.EqualTo(255));
            Assert.That(color.blue, Is.EqualTo(0));
        });
    }

    [Test]
    public void ValidColor_GetHueColorViolet_ShouldReturnProperHueValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 140;
        color.green = 110;
        color.blue = 178;

        // Act
        double actual = color.GetHue();
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo(266));
            Assert.That(color.red, Is.EqualTo(140));
            Assert.That(color.green, Is.EqualTo(110));
            Assert.That(color.blue, Is.EqualTo(178));
        });
    }

    [Test]
    public void ValidColor_GetHueColorLightGreen_ShouldReturnProperHueValue()
    {
        // Arrange
        Color color = MakeValidColor();
        color.red = 126;
        color.green = 130;
        color.blue = 33;

        // Act
        double actual = color.GetHue();
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual, Is.EqualTo(62));
            Assert.That(color.red, Is.EqualTo(126));
            Assert.That(color.green, Is.EqualTo(130));
            Assert.That(color.blue, Is.EqualTo(33));
        });
    }
}