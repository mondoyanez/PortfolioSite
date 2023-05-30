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

    [Test]
    public void ValidPythagorean_CalculateContainingDecimal_IsValidAndCorrect()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();
        pythagorean.SideA = 5.1;

        // Act
        pythagorean.Calculate();
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(pythagorean.SideA, Is.EqualTo(5.1));
            Assert.That(pythagorean.SideB, Is.EqualTo(8));
            Assert.That(pythagorean.Hypotenuse, Is.EqualTo(9.4874));
        });
    }

    [Test]
    public void ValidPythagorean_CalculateBothDecimals_IsValidAndCorrect()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();
        pythagorean.SideA = 5.1;
        pythagorean.SideB = 7.3;

        // Act
        pythagorean.Calculate();
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(pythagorean.SideA, Is.EqualTo(5.1));
            Assert.That(pythagorean.SideB, Is.EqualTo(7.3));
            Assert.That(pythagorean.Hypotenuse, Is.EqualTo(8.9051));
        });
    }

    [Test]
    public void ValidPythagorean_SideAIsZero_Invalid()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();
        pythagorean.SideA = 0;

        // Act
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidPythagorean_SideAIsZeroDecimal_IsValid()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();
        pythagorean.SideA = 0.00001;

        // Act
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void ValidPythagorean_SideAExceedsMinRange_IsInvalid()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();
        pythagorean.SideA = 0.000001;

        // Act
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }

    [Test]
    public void ValidPythagorean_SideAIsMaxRange_IsValid()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();
        pythagorean.SideA = Double.MaxValue;

        // Act
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(pythagorean.SideA, Is.EqualTo(Double.MaxValue));
        });
    }

    [Test]
    public void ValidPythagorean_SideAIsNegative_IsInvalid()
    {
        // Arrange
        Pythagorean pythagorean = MakeValidPythagorean();
        pythagorean.SideA = -1;

        // Act
        ModelValidator mv = new ModelValidator(pythagorean);

        // Assert
        Assert.That(mv.Valid, Is.False);
    }
}