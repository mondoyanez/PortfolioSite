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
}