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
}