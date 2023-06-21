using Portfolio.Models;

namespace Test;

public class ColorInterpolationModelValidator_Tests
{
    private ColorInterpolation MakeValidColorInterpolation()
    {
        ColorInterpolation colorInterpolation = new()
        {
            FirstColor = "#FF0000",
            SecondColor = "#0000FF",
            NumColors = 10
        };

        return colorInterpolation;
    }

    [Test]
    public void ValidColorInterpolation_IsValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidFirstColorInterpolation_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.FirstColor = null;

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidFirstColorInterpolation_FailingRegExForFirstColorUppercaseWithPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.FirstColor = "#PA1253";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidFirstColorInterpolation_FailingRegExForFirstColorLowercaseWithPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.FirstColor = "#zyx10p";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidFirstColorInterpolation_FailingRegExForFirstColorUppercaseWithoutPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.FirstColor = "PA1253";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidFirstColorInterpolation_FailingRegExForFirstColorLowercaseWithoutPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.FirstColor = "zyx10p";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidSecondColorInterpolation_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.SecondColor = null;

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidSecondColorInterpolation_FailingRegExForSecondColorUppercaseWithPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.SecondColor = "#PA1253";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidSecondColorInterpolation_FailingRegExForSecondColorLowercaseWithPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.SecondColor = "#zyx10p";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidSecondColorInterpolation_FailingRegExForSecondColorUppercaseWithoutPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.SecondColor = "PA1253";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidSecondColorInterpolation_FailingRegExForSecondColorLowercaseWithoutPoundSign_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.SecondColor = "zyx10p";

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void ValidNumColorsInterpolation_IsValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.NumColors = null;

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.False);
        });
    }

    [Test]
    public void InvalidNumColorsInterpolation_WithNegativeNumColors_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.NumColors = -13;

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.True);
        });
    }

    [Test]
    public void InvalidNumColorsInterpolation_WithNumColorsExceedingRange_IsNotValid()
    {
        // Arrange
        ColorInterpolation colorInterpolation = MakeValidColorInterpolation();
        colorInterpolation.NumColors = 151;

        // Act
        ModelValidator mv = new ModelValidator(colorInterpolation);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("FirstColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("SecondColor"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumColors"), Is.True);
        });
    }

    [Test]
    public void ValidColorInterpolation_CalculateHSVForColorYellow_ShouldReturnCorrectValues()
    {
        // Arrange
        Color newColor = new()
        {
            red = 255,
            green = 255,
            blue = 0
        };
        double hue, saturation, value;

        // Act
        ColorInterpolation.ColorToHSV(newColor, out hue, out saturation, out value);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(hue, Is.EqualTo(60).Within(0.075));
            Assert.That(saturation, Is.EqualTo(100).Within(0.075));
            Assert.That(value, Is.EqualTo(100).Within(0.075));
        });
    }

    [Test]
    public void ValidColorInterpolation_CalculateHSVForColorDarkGreen_ShouldReturnCorrectValues()
    {
        // Arrange
        Color newColor = new()
        {
            red = 29,
            green = 38,
            blue = 29
        };
        double hue, saturation, value;

        // Act
        ColorInterpolation.ColorToHSV(newColor, out hue, out saturation, out value);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(hue, Is.EqualTo(120).Within(0.075));
            Assert.That(saturation, Is.EqualTo(23.69).Within(0.075));
            Assert.That(value, Is.EqualTo(14.9).Within(0.075));
        });
    }

    [Test]
    public void ValidColorInterpolation_CalculateHSVForColorWhite_ShouldReturnCorrectValues()
    {
        // Arrange
        Color newColor = new()
        {
            red = 242,
            green = 242,
            blue = 242
        };
        double hue, saturation, value;

        // Act
        ColorInterpolation.ColorToHSV(newColor, out hue, out saturation, out value);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(hue, Is.EqualTo(0).Within(0.075));
            Assert.That(saturation, Is.EqualTo(0).Within(0.075));
            Assert.That(value, Is.EqualTo(94.9).Within(0.075));
        });
    }

    [Test]
    public void ValidColorInterpolation_ColorFromHSVWithHueOf240_ShouldReturnColorBlue()
    {
        // Arrange
        double hue = 240;
        double saturation = 100;
        double value = 100;

        // Act
        Color actual = ColorInterpolation.ColorFromHSV(hue, saturation, value);
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
    public void ValidColorInterpolation_ColorFromHSVWithHueOf320_ShouldReturnColorLightPink()
    {
        // Arrange
        double hue = 320;
        double saturation = 41;
        double value = 70;

        // Act
        Color actual = ColorInterpolation.ColorFromHSV(hue, saturation, value);
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(178));
            Assert.That(actual.green, Is.EqualTo(105));
            Assert.That(actual.blue, Is.EqualTo(154));
        });
    }

    [Test]
    public void ValidColorInterpolation_ColorFromHSVWithHueOf151_ShouldReturnColorTeal()
    {
        // Arrange
        double hue = 151;
        double saturation = 45;
        double value = 65;

        // Act
        Color actual = ColorInterpolation.ColorFromHSV(hue, saturation, value);
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(91));
            Assert.That(actual.green, Is.EqualTo(166));
            Assert.That(actual.blue, Is.EqualTo(130));
        });
    }

    [Test]
    public void ValidColorInterpolation_ColorFromHSVWithHueOf119_ShouldReturnColorLime()
    {
        // Arrange
        double hue = 119;
        double saturation = 32;
        double value = 84;

        // Act
        Color actual = ColorInterpolation.ColorFromHSV(hue, saturation, value);
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(147));
            Assert.That(actual.green, Is.EqualTo(214));
            Assert.That(actual.blue, Is.EqualTo(146));
        });
    }

    [Test]
    public void ValidColorInterpolation_ColorFromHSVWithHueOf14_ShouldReturnColorBlack()
    {
        // Arrange
        double hue = 14;
        double saturation = 14;
        double value = 14;

        // Act
        Color actual = ColorInterpolation.ColorFromHSV(hue, saturation, value);
        ModelValidator mv = new ModelValidator(actual);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("red"), Is.False);
            Assert.That(mv.ContainsFailureFor("green"), Is.False);
            Assert.That(mv.ContainsFailureFor("blue"), Is.False);
            Assert.That(actual.red, Is.EqualTo(36));
            Assert.That(actual.green, Is.EqualTo(32));
            Assert.That(actual.blue, Is.EqualTo(31));
        });
    }
}