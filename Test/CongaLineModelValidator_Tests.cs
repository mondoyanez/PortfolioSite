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

    [Test]
    public void ValidCongaLine_JumpInLineWithValidInput_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(2, 'B');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(6));
            Assert.That(congaLineString, Is.EqualTo("R, B, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithValidInputAtMax_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(6, 'B');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(6));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M, B"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithValidInputAtMin_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(1, 'B');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(6));
            Assert.That(congaLineString, Is.EqualTo("B, R, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithValidInputAsLowercase_ShouldSuccessfullyAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(2, 'b');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(6));
            Assert.That(congaLineString, Is.EqualTo("R, B, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithIndexMaxOutOfRange_ShouldNotAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(7, 'B');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(5));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithIndexMinOutOfRange_ShouldNotAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(0, 'B');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(5));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithInvalidInputAsUppercaseButValidRange_ShouldNotAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(3, 'Z');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(5));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithInvalidInputAsLowercaseButValidRange_ShouldNotAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(4, 'z');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(5));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithInvalidInputAsUppercaseAndInvalidRange_ShouldNotAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(7, 'Z');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(5));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_JumpInLineWithInvalidInputAsLowercaseAndInvalidRange_ShouldNotAddToCongaLine()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();
        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        // Act
        congaLine.JumpInLine(0, 'z');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(5));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M"));
        });
    }

    [Test]
    public void ValidCongaLine_EveryoneOutWithValidInputRedZombieUppercase_ShouldRemoveAllInstancesOfRedZombies()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.EveryOneOut('R');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(16));
            Assert.That(congaLineString, Is.EqualTo("Y, B, G, M, M, G, B, Y, Y, B, G, M, M, G, B, Y"));
        });
    }

    [Test]
    public void ValidCongaLine_EveryoneOutWithValidInputBlueZombieLowercase_ShouldRemoveAllInstancesOfBlueZombies()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.EveryOneOut('b');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(16));
            Assert.That(congaLineString, Is.EqualTo("R, Y, G, M, M, G, Y, R, R, Y, G, M, M, G, Y, R"));
        });
    }

    [Test]
    public void ValidCongaLine_EveryoneOutWithInvalidInputAsUppercase_ShouldNotRemoveAnyInstance()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.EveryOneOut('Z');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(20));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M, M, G, B, Y, R, R, Y, B, G, M, M, G, B, Y, R"));
        });
    }

    [Test]
    public void ValidCongaLine_EveryoneOutWithInvalidInputAsLowercase_ShouldNotRemoveAnyInstance()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.EveryOneOut('a');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(20));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M, M, G, B, Y, R, R, Y, B, G, M, M, G, B, Y, R"));
        });
    }

    [Test]
    public void ValidCongaLine_YourDoneWithValidInputForYellowZombieAsUppercase_ShouldRemoveFirstInstanceOfYellowZombie()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.YourDone('Y');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(19));
            Assert.That(congaLineString, Is.EqualTo("R, B, G, M, M, G, B, Y, R, R, Y, B, G, M, M, G, B, Y, R"));
        });
    }

    [Test]
    public void ValidCongaLine_YourDoneWithValidInputForGreenZombieAsLowercase_ShouldRemoveFirstInstanceOfGreenZombie()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.YourDone('g');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(19));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, M, M, G, B, Y, R, R, Y, B, G, M, M, G, B, Y, R"));
        });
    }

    [Test]
    public void ValidCongaLine_YourDoneWithInValidInputAsUppercase_ShouldNotRemoveAnyInstances()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.YourDone('U');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(20));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M, M, G, B, Y, R, R, Y, B, G, M, M, G, B, Y, R"));
        });
    }

    [Test]
    public void ValidCongaLine_YourDoneWithInValidInputAsLowercase_ShouldNotRemoveAnyInstances()
    {
        // Arrange
        CongaLine congaLine = MakeValidCongaLine();

        congaLine.Caboose('R');
        congaLine.Caboose('Y');
        congaLine.Caboose('B');
        congaLine.Caboose('G');
        congaLine.Caboose('M');

        congaLine.Caboose('M');
        congaLine.Caboose('G');
        congaLine.Caboose('B');
        congaLine.Caboose('Y');
        congaLine.Caboose('R');

        congaLine.Engine('R');
        congaLine.Engine('Y');
        congaLine.Engine('B');
        congaLine.Engine('G');
        congaLine.Engine('M');

        congaLine.Engine('M');
        congaLine.Engine('G');
        congaLine.Engine('B');
        congaLine.Engine('Y');
        congaLine.Engine('R');

        // Act
        congaLine.YourDone('t');
        int count = congaLine.CongaLineLength();
        string congaLineString = congaLine.ToString();
        ModelValidator mv = new ModelValidator(congaLine);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("_line"), Is.False);
            Assert.That(count, Is.EqualTo(20));
            Assert.That(congaLineString, Is.EqualTo("R, Y, B, G, M, M, G, B, Y, R, R, Y, B, G, M, M, G, B, Y, R"));
        });
    }
}