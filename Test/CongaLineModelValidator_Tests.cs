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
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
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
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(0));
        });
    }

    [Test]
    public void ValidCongaLine_EngineValidInputAsUppercase_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Engine('R');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(1));
            Assert.That(congaLineString, Is.EqualTo("R"));
        });
    }

    [Test]
    public void ValidCongaLine_MultipleEngineValidInputAsUppercase_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Engine('R');
        congaLine.Engine('M');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(2));
            Assert.That(congaLineString, Is.EqualTo("M, R"));
        });
    }

    [Test]
    public void ValidCongaLine_MultipleEngineValidInputAsLowercase_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Engine('r');
        congaLine.Engine('m');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(2));
            Assert.That(congaLineString, Is.EqualTo("M, R"));
        });
    }

    [Test]
    public void ValidCongaLine_EngineInvalidInputAsUppercase_ShouldNotSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Engine('Z');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(0));
            Assert.That(congaLineString, Is.EqualTo("No zombies in line"));
        });
    }

    [Test]
    public void ValidCongaLine_EngineMixOfValidAndInvalid_ShouldAddAndNotAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Engine('Z');
        congaLine.Engine('R');
        congaLine.Engine('a');
        congaLine.Engine('y');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(2));
            Assert.That(congaLineString, Is.EqualTo("Y, R"));
        });
    }

    [Test]
    public void ValidCongaLine_CabooseValidInputAsUppercase_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Caboose('R');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(1));
            Assert.That(congaLineString, Is.EqualTo("R"));
        });
    }

    [Test]
    public void ValidCongaLine_MultipleCabooseValidInputAsUppercase_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(2));
            Assert.That(congaLineString, Is.EqualTo("R, Y"));
        });
    }

    [Test]
    public void ValidCongaLine_MultipleCabooseValidInputAsLowercase_ShouldSuccessfullyAddToCongaLineAsUppercase()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Caboose('r');
        congaLine.Caboose('y');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(2));
            Assert.That(congaLineString, Is.EqualTo("R, Y"));
        });
    }

    [Test]
    public void ValidCongaLIne_CabooseInvalidInputAsUppercase_ShouldNotSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Caboose('Z');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(0));
            Assert.That(congaLineString, Is.EqualTo("No zombies in line"));
        });
    }

    [Test]
    public void ValidCongaLine_CabooseMixOfValidAndInvalidInput_ShouldAddValidInputAndViceVersa()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Caboose('Z');
        congaLine.Caboose('r');
        congaLine.Caboose('a');
        congaLine.Caboose('B');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(2));
            Assert.That(congaLineString, Is.EqualTo("R, B"));
        });
    }

    [Test]
    public void ValidCongaLine_MixOfCabooseAndEngineWithValidInput_ShouldSuccessfullyAddToCongaLineCorrectly()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        // Act
        congaLine.Caboose('R');
        congaLine.Engine('Y');
        congaLine.Caboose('B');
        congaLine.Engine('M');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(4));
            Assert.That(congaLineString, Is.EqualTo("M, Y, R, B"));
        });
    }
}