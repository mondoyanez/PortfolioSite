using Portfolio.Models;

namespace Test;

public class TeamsModelValidator_Tests
{
    private TeamsModel MakeValidTeamsModel()
    {
        TeamsModel teamsModel = new()
        {
            Names = "Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett",
            NumTeams = 5
        };
        return teamsModel;
    }

    [Test]
    public void ValidTeamsModel_IsValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(teamsModel.Names, Is.EqualTo("Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett"));
            Assert.That(teamsModel.NumTeams, Is.EqualTo(5));
        });
    }

    [Test]
    public void InvalidTeamsModel_NamesPropertyIsNull_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.Names = null;

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(teamsModel.Names, Is.Null);
        });
    }

    [Test]
    public void InvalidTeamsModel_NamesPropertyIsEmptyString_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.Names = "";

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(teamsModel.Names, Is.EqualTo(string.Empty));
        });
    }

    [Test]
    public void InvalidTeamsModel_NamesPropertyLeadingEmptyString_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.Names = " Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett";

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(teamsModel.Names, Is.EqualTo(" Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett"));
        });
    }

    [Test]
    public void InvalidTeamsModel_NamesPropertyLeadingSpecialCharacter_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.Names = "@Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett";

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(teamsModel.Names, Is.EqualTo("@Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett"));
        });
    }

    [Test]
    public void InvalidTeamsModel_NamesPropertyLeadingDigit_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.Names = "6Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett";

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.True);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(teamsModel.Names, Is.EqualTo("6Art Robles\n Juliette Austin\n Milo Wall\n Ariel Wallace\n Vern Garrett"));
        });
    }

    [Test]
    public void InvalidTeamsModel_NumTeamsPropertyIsNull_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.NumTeams = null;

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.True);
            Assert.That(teamsModel.NumTeams, Is.Null);
        });
    }

    [Test]
    public void InvalidTeamsModel_NumTeamsPropertyIsZero_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.NumTeams = 0;

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.True);
            Assert.That(teamsModel.NumTeams, Is.EqualTo(0));
        });
    }

    [Test]
    public void InvalidTeamsModel_NumTeamsPropertyIsNineThousandOne_IsNotValid()
    {
        // Arrange
        TeamsModel teamsModel = MakeValidTeamsModel();
        teamsModel.NumTeams = 9001;

        // Act
        ModelValidator mv = new ModelValidator(teamsModel);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.False);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.True);
            Assert.That(teamsModel.NumTeams, Is.EqualTo(9001));
        });
    }
}