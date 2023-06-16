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
}