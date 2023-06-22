using Portfolio.Models;

namespace Test;

public class CampMadLibModelValidator_Tests
{
    private CampMadLib MakeValidCampMadLib()
    {
        CampMadLib campMadLib = new()
        {
            Name1 = "Sandra",
            CampName1 = "Camp Lazlo",
            Adjective1 = "Tall",
            Activity1 = "Soccer",
            Activity2 = "Volleyball",
            PluralNoun1 = "Bees",
            Adjective2 = "Large",
            Noun1 = "Fire",
            NickName1 = "Shorty"
        };

        return campMadLib;
    }

    [Test]
    public void ValidCampMadLib_IsValid()
    {
        // Arrange
        CampMadLib campMadLib = MakeValidCampMadLib();

        // Act
        ModelValidator mv = new ModelValidator(campMadLib);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("Name1"), Is.False);
            Assert.That(mv.ContainsFailureFor("CampName1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Activity1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Activity2"), Is.False);
            Assert.That(mv.ContainsFailureFor("PluralNoun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("NickName1"), Is.False);
        });
    }

    [Test]
    public void InvalidCampMadLib_IsNotValid()
    {
        // Arrange
        CampMadLib campMadLib = MakeValidCampMadLib();
        campMadLib.CampName1 = null;

        // Act
        ModelValidator mv = new ModelValidator(campMadLib);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("Name1"), Is.False);
            Assert.That(mv.ContainsFailureFor("CampName1"), Is.True);
            Assert.That(mv.ContainsFailureFor("Adjective1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Activity1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Activity2"), Is.False);
            Assert.That(mv.ContainsFailureFor("PluralNoun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("Adjective2"), Is.False);
            Assert.That(mv.ContainsFailureFor("Noun1"), Is.False);
            Assert.That(mv.ContainsFailureFor("NickName1"), Is.False);
        });
    }

    [Test]
    public void CampMadLib_WithCorrectValues()
    {
        // Arrange
        CampMadLib campMadLib = MakeValidCampMadLib();

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(campMadLib.Name1, Is.EqualTo("Sandra"));
            Assert.That(campMadLib.CampName1, Is.EqualTo("Camp Lazlo"));
            Assert.That(campMadLib.Adjective1, Is.EqualTo("Tall"));
            Assert.That(campMadLib.Activity1, Is.EqualTo("Soccer"));
            Assert.That(campMadLib.Activity2, Is.EqualTo("Volleyball"));
            Assert.That(campMadLib.PluralNoun1, Is.EqualTo("Bees"));
            Assert.That(campMadLib.Adjective2, Is.EqualTo("Large"));
            Assert.That(campMadLib.Noun1, Is.EqualTo("Fire"));
            Assert.That(campMadLib.NickName1, Is.EqualTo("Shorty"));
        });
    }

    [Test]
    public void CampMadLib_WithIncorrectValues()
    {
        // Arrange
        CampMadLib campMadLib = MakeValidCampMadLib();
        campMadLib.Name1 = "Hart";

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(campMadLib.Name1, Is.Not.EqualTo("Sandra"));
            Assert.That(campMadLib.CampName1, Is.EqualTo("Camp Lazlo"));
            Assert.That(campMadLib.Adjective1, Is.EqualTo("Tall"));
            Assert.That(campMadLib.Activity1, Is.EqualTo("Soccer"));
            Assert.That(campMadLib.Activity2, Is.EqualTo("Volleyball"));
            Assert.That(campMadLib.PluralNoun1, Is.EqualTo("Bees"));
            Assert.That(campMadLib.Adjective2, Is.EqualTo("Large"));
            Assert.That(campMadLib.Noun1, Is.EqualTo("Fire"));
            Assert.That(campMadLib.NickName1, Is.EqualTo("Shorty"));
        });
    }
}