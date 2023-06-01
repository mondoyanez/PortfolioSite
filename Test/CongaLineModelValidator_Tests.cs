﻿using Portfolio.Models;

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
}