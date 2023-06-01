using Portfolio.Models;

namespace Test;
public class CongaLineModelValidator_Tests
{
    private CongaLine MakeValidCongaLine()
    {
        CongaLine line = new();
        return line;
    }

    [Test]
    public void ValidCongaLine_IsValid()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.That(mv.Valid, Is.True);
    }

    [Test]
    public void ValidCongaLine_AsStringAsNull()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        String? congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Line"), Is.False);
            Assert.That(congaLineString, Is.EqualTo("No zombies in line"));
        });
    }

    [Test]
    public void ValidCongaLine_CongaLineLength_ShouldReturnZeroLength()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        int count = congaLine.CongaLineLength();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Line"), Is.False);
            Assert.That(count, Is.EqualTo(0));
        });
    }
}