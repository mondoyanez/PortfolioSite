using Portfolio.ViewModels;

namespace Test;

public class TeamsGeneratorValidator_Tests
{
    private TeamsGeneratorVM MakeValidTeamsGeneratorVM()
    {
        TeamsGeneratorVM viewModel = new()
        {
            ColorsAvailable = new string[]
            {
                "#ff80ed", "#8a2be2", "#f6546a", "#ffc0cb", "#ffe4e1", "#008080", "#ffff66", "#e6e6fa", "#ffd700", "#ffa500",
                "#00ffff", "#ff7373", "#00ff00", "#d3ffce", "#c6e2ff", "#b0e0e6", "#666666", "#faebd7", "#bada55", "#fa8072"
            },
            Names = new List<string>()
            {
                "Art Robles",
                "Juliette Austin",
                "Milo Wall",
                "Ariel Wallace",
                "Vern Garrett"
            },
            NumPerTeam = 5,
            NumTeams = 1
        };
        return viewModel;
    }

    [Test]
    public void ValidTeamsGenerator_IsValid()
    {
        // Arrange
        TeamsGeneratorVM vm = MakeValidTeamsGeneratorVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumPerTeam"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
        });
    }

    [Test]
    public void ValidTeamsGenerator_ColorsAvailableProperty_IsCorrect()
    {
        // Arrange
        TeamsGeneratorVM vm = MakeValidTeamsGeneratorVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumPerTeam"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(vm.ColorsAvailable[0], Is.EqualTo("#ff80ed"));
            Assert.That(vm.ColorsAvailable[1], Is.EqualTo("#8a2be2"));
            Assert.That(vm.ColorsAvailable[2], Is.EqualTo("#f6546a"));
            Assert.That(vm.ColorsAvailable[3], Is.EqualTo("#ffc0cb"));
            Assert.That(vm.ColorsAvailable[4], Is.EqualTo("#ffe4e1"));
            Assert.That(vm.ColorsAvailable[5], Is.EqualTo("#008080"));
            Assert.That(vm.ColorsAvailable[6], Is.EqualTo("#ffff66"));
            Assert.That(vm.ColorsAvailable[7], Is.EqualTo("#e6e6fa"));
            Assert.That(vm.ColorsAvailable[8], Is.EqualTo("#ffd700"));
            Assert.That(vm.ColorsAvailable[9], Is.EqualTo("#ffa500"));
            Assert.That(vm.ColorsAvailable[10], Is.EqualTo("#00ffff"));
            Assert.That(vm.ColorsAvailable[11], Is.EqualTo("#ff7373"));
            Assert.That(vm.ColorsAvailable[12], Is.EqualTo("#00ff00"));
            Assert.That(vm.ColorsAvailable[13], Is.EqualTo("#d3ffce"));
            Assert.That(vm.ColorsAvailable[14], Is.EqualTo("#c6e2ff"));
            Assert.That(vm.ColorsAvailable[15], Is.EqualTo("#b0e0e6"));
            Assert.That(vm.ColorsAvailable[16], Is.EqualTo("#666666"));
            Assert.That(vm.ColorsAvailable[17], Is.EqualTo("#faebd7"));
            Assert.That(vm.ColorsAvailable[18], Is.EqualTo("#bada55"));
            Assert.That(vm.ColorsAvailable[19], Is.EqualTo("#fa8072"));
        });
    }

    [Test]
    public void ValidTeamsGenerator_NamesProperty_IsCorrect()
    {
        // Arrange
        TeamsGeneratorVM vm = MakeValidTeamsGeneratorVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumPerTeam"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(vm.Names[0], Is.EqualTo("Art Robles"));
            Assert.That(vm.Names[1], Is.EqualTo("Juliette Austin"));
            Assert.That(vm.Names[2], Is.EqualTo("Milo Wall"));
            Assert.That(vm.Names[3], Is.EqualTo("Ariel Wallace"));
            Assert.That(vm.Names[4], Is.EqualTo("Vern Garrett"));
        });
    }

    [Test]
    public void ValidTeamsGenerator_NumPerTeamProperty_IsCorrect()
    {
        // Arrange
        TeamsGeneratorVM vm = MakeValidTeamsGeneratorVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert
        Assert.Multiple(() => 
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumPerTeam"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(vm.NumPerTeam, Is.EqualTo(5));
        });
    }

    [Test]
    public void ValidTeamsGenerator_NumTeamsProperty_IsCorrect()
    {
        // Arrange
        TeamsGeneratorVM vm = MakeValidTeamsGeneratorVM();

        // Act
        ModelValidator mv = new ModelValidator(vm);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumPerTeam"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(vm.NumTeams, Is.EqualTo(1));
        });
    }

    [Test]
    public void ValidTeamsGenerator_ShuffleMethod_IsCorrectAndValid()
    {
        // Arrange
        TeamsGeneratorVM vm = MakeValidTeamsGeneratorVM();

        // Act
        vm.Shuffle();
        ModelValidator mv = new ModelValidator(vm);
        List<string> correctOrder = vm.Names;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(mv.Valid, Is.True);
            Assert.That(mv.ContainsFailureFor("ColorsAvailable"), Is.False);
            Assert.That(mv.ContainsFailureFor("Names"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumPerTeam"), Is.False);
            Assert.That(mv.ContainsFailureFor("NumTeams"), Is.False);
            Assert.That(vm.Names[0], Is.EqualTo(correctOrder[0]));
            Assert.That(vm.Names[1], Is.EqualTo(correctOrder[1]));
            Assert.That(vm.Names[2], Is.EqualTo(correctOrder[2]));
            Assert.That(vm.Names[3], Is.EqualTo(correctOrder[3]));
            Assert.That(vm.Names[4], Is.EqualTo(correctOrder[4]));
        });
    }

    [Test]
    public void ValidTeamsGenerator_ShuffleMethodWithNullPropertyNames_ShouldDoSomething()
    {
        // Arrange
        TeamsGeneratorVM vm = MakeValidTeamsGeneratorVM();
        vm.Names = null;

        // Act/Assert
        Assert.Throws<ArgumentNullException>(() => vm.Shuffle());
    }
}