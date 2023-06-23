using Portfolio.Models;

namespace Test;

public class RoadTripMadLibModelValidator_Tests
{
    private RoadTripMadLib MakeValidRoadTripMadLib()
    {
        RoadTripMadLib roadTripMadLib = new()
        {
            Noun1 = "Car",
            Adjective1 = "Tiny",
            Noun2 = "Tower",
            Adjective2 = "Skinny",
            Adjective3 = "Large",
            Verb1 = "Run",
            Verb2 = "Swim",
            Number1 = 15,
            Verb3 = "Walk",
            Adverb1 = "Gently",
            Noun3 = "Stone",
            Color1 = "Green",
            Verb4 = "Climb",
            Noun4 = "Cat",
            Exclamation1 = "War!!!",
            Verb5 = "Dance",
            Adverb2 = "Daily",
            Noun5 = "Cake",
            Verb6 = "Stand",
            Verb7 = "Slide",
            Noun6 = "School Bus",
            PluralNoun1 = "Rats",
            Verb8 = "Jump",
            Name1 = "Carlos",
            Verb9 = "Think",
            Noun7 = "Pirate",
            Verb10 = "Go",
            Adjective4 = "Silly",
            Adverb3 = "Joyfully",
            Adverb4 = "Strangely",
            Noun8 = "City",
            Verb11 = "Survive",
            Noun9 = "President",
            Adjective5 = "Fast"
        };

        return roadTripMadLib;
    }

    [Test]
    public void ValidRoadTripMadLib_IsValid()
    {
        // Arrange
        RoadTripMadLib roadTripMadLib = MakeValidRoadTripMadLib();

        // Act
        ModelValidator mv = new ModelValidator(roadTripMadLib);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Noun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective3"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Number1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb3"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun3"), Is.False);
            Assert.That(mv.ContainsFailureFor("Color1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Exclamation1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb5"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun5"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb6"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb7"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun6"), Is.False);
            Assert.That(mv.ContainsFailureFor("PluralNoun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb8"), Is.False);
            Assert.That(mv.ContainsFailureFor("Name1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb9"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun7"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb10"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb3"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun8"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb11"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun9"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective5"), Is.False);
        });
    }

    [Test]
    public void InvalidRoadTripMadLib_IsNotValid()
    {
        // Arrange
        RoadTripMadLib roadTripMadLib = MakeValidRoadTripMadLib();
        roadTripMadLib.Noun3 = null;

        // Act
        ModelValidator mv = new ModelValidator(roadTripMadLib);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("Noun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective3"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Number1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb3"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun3"), Is.True);
            Assert.That(mv.ContainsFailureFor("Color1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Exclamation1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb5"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun5"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb6"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb7"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun6"), Is.False);
            Assert.That(mv.ContainsFailureFor("PluralNoun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb8"), Is.False);
            Assert.That(mv.ContainsFailureFor("Name1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb9"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun7"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb10"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb3"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adverb4"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun8"), Is.False);
            Assert.That(mv.ContainsFailureFor("Verb11"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun9"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective5"), Is.False);
        });
    }

    [Test]
    public void RoadTripMadLib_ReturnsCorrectValues()
    {
        // Arrange
        RoadTripMadLib roadTripMadLib = MakeValidRoadTripMadLib();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(roadTripMadLib.Noun1, Is.EqualTo("Car"));
            Assert.That(roadTripMadLib.Adjective1, Is.EqualTo("Tiny"));
            Assert.That(roadTripMadLib.Noun2, Is.EqualTo("Tower"));
            Assert.That(roadTripMadLib.Adjective2, Is.EqualTo("Skinny"));
            Assert.That(roadTripMadLib.Adjective3, Is.EqualTo("Large"));
            Assert.That(roadTripMadLib.Verb1, Is.EqualTo("Run"));
            Assert.That(roadTripMadLib.Verb2, Is.EqualTo("Swim"));
            Assert.That(roadTripMadLib.Number1, Is.EqualTo(15));
            Assert.That(roadTripMadLib.Verb3, Is.EqualTo("Walk"));
            Assert.That(roadTripMadLib.Adverb1, Is.EqualTo("Gently"));
            Assert.That(roadTripMadLib.Noun3, Is.EqualTo("Stone"));
            Assert.That(roadTripMadLib.Color1, Is.EqualTo("Green"));
            Assert.That(roadTripMadLib.Verb4, Is.EqualTo("Climb"));
            Assert.That(roadTripMadLib.Noun4, Is.EqualTo("Cat"));
            Assert.That(roadTripMadLib.Exclamation1, Is.EqualTo("War!!!"));
            Assert.That(roadTripMadLib.Verb5, Is.EqualTo("Dance"));
            Assert.That(roadTripMadLib.Adverb2, Is.EqualTo("Daily"));
            Assert.That(roadTripMadLib.Noun5, Is.EqualTo("Cake"));
            Assert.That(roadTripMadLib.Verb6, Is.EqualTo("Stand"));
            Assert.That(roadTripMadLib.Verb7, Is.EqualTo("Slide"));
            Assert.That(roadTripMadLib.Noun6, Is.EqualTo("School Bus"));
            Assert.That(roadTripMadLib.PluralNoun1, Is.EqualTo("Rats"));
            Assert.That(roadTripMadLib.Verb8, Is.EqualTo("Jump"));
            Assert.That(roadTripMadLib.Name1, Is.EqualTo("Carlos"));
            Assert.That(roadTripMadLib.Verb9, Is.EqualTo("Think"));
            Assert.That(roadTripMadLib.Noun7, Is.EqualTo("Pirate"));
            Assert.That(roadTripMadLib.Verb10, Is.EqualTo("Go"));
            Assert.That(roadTripMadLib.Adjective4, Is.EqualTo("Silly"));
            Assert.That(roadTripMadLib.Adverb3, Is.EqualTo("Joyfully"));
            Assert.That(roadTripMadLib.Adverb4, Is.EqualTo("Strangely"));
            Assert.That(roadTripMadLib.Noun8, Is.EqualTo("City"));
            Assert.That(roadTripMadLib.Verb11, Is.EqualTo("Survive"));
            Assert.That(roadTripMadLib.Noun9, Is.EqualTo("President"));
            Assert.That(roadTripMadLib.Adjective5, Is.EqualTo("Fast"));
        });
    }

    [Test]
    public void RoadTripMadLib_ReturnsIncorrectValues()
    {
        // Arrange
        RoadTripMadLib roadTripMadLib = MakeValidRoadTripMadLib();
        roadTripMadLib.Color1 = "Yellow";

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(roadTripMadLib.Noun1, Is.EqualTo("Car"));
            Assert.That(roadTripMadLib.Adjective1, Is.EqualTo("Tiny"));
            Assert.That(roadTripMadLib.Noun2, Is.EqualTo("Tower"));
            Assert.That(roadTripMadLib.Adjective2, Is.EqualTo("Skinny"));
            Assert.That(roadTripMadLib.Adjective3, Is.EqualTo("Large"));
            Assert.That(roadTripMadLib.Verb1, Is.EqualTo("Run"));
            Assert.That(roadTripMadLib.Verb2, Is.EqualTo("Swim"));
            Assert.That(roadTripMadLib.Number1, Is.EqualTo(15));
            Assert.That(roadTripMadLib.Verb3, Is.EqualTo("Walk"));
            Assert.That(roadTripMadLib.Adverb1, Is.EqualTo("Gently"));
            Assert.That(roadTripMadLib.Noun3, Is.EqualTo("Stone"));
            Assert.That(roadTripMadLib.Color1, Is.Not.EqualTo("Green"));
            Assert.That(roadTripMadLib.Verb4, Is.EqualTo("Climb"));
            Assert.That(roadTripMadLib.Noun4, Is.EqualTo("Cat"));
            Assert.That(roadTripMadLib.Exclamation1, Is.EqualTo("War!!!"));
            Assert.That(roadTripMadLib.Verb5, Is.EqualTo("Dance"));
            Assert.That(roadTripMadLib.Adverb2, Is.EqualTo("Daily"));
            Assert.That(roadTripMadLib.Noun5, Is.EqualTo("Cake"));
            Assert.That(roadTripMadLib.Verb6, Is.EqualTo("Stand"));
            Assert.That(roadTripMadLib.Verb7, Is.EqualTo("Slide"));
            Assert.That(roadTripMadLib.Noun6, Is.EqualTo("School Bus"));
            Assert.That(roadTripMadLib.PluralNoun1, Is.EqualTo("Rats"));
            Assert.That(roadTripMadLib.Verb8, Is.EqualTo("Jump"));
            Assert.That(roadTripMadLib.Name1, Is.EqualTo("Carlos"));
            Assert.That(roadTripMadLib.Verb9, Is.EqualTo("Think"));
            Assert.That(roadTripMadLib.Noun7, Is.EqualTo("Pirate"));
            Assert.That(roadTripMadLib.Verb10, Is.EqualTo("Go"));
            Assert.That(roadTripMadLib.Adjective4, Is.EqualTo("Silly"));
            Assert.That(roadTripMadLib.Adverb3, Is.EqualTo("Joyfully"));
            Assert.That(roadTripMadLib.Adverb4, Is.EqualTo("Strangely"));
            Assert.That(roadTripMadLib.Noun8, Is.EqualTo("City"));
            Assert.That(roadTripMadLib.Verb11, Is.EqualTo("Survive"));
            Assert.That(roadTripMadLib.Noun9, Is.EqualTo("President"));
            Assert.That(roadTripMadLib.Adjective5, Is.EqualTo("Fast"));
        });
    }
}