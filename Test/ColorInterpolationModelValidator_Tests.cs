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
        Assert.That(mv.Valid, Is.True);
    }    
}