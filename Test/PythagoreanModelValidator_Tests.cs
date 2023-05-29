using Portfolio.Models;

namespace Test;

public class PythagoreanModelValidator_Tests
{
    private Pythagorean MakeValidPythagorean()
    {
        Pythagorean pythagorean = new()
        {
            SideA = 6,
            SideB = 8
        };

        return pythagorean;
    }

    [Test]
    public void ValidPythagorean_IsValid()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();

        // Act
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void ValidPythagorean_Calculate_IsValidAndCorrect()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();

        // Act
        pythagorean.Calculate();
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(pythagorean.SideA, Is.EqualTo(6));
            Assert.That(pythagorean.SideB, Is.EqualTo(8));
            Assert.That(pythagorean.Hypotenuse, Is.EqualTo(10));
        });
    }
}