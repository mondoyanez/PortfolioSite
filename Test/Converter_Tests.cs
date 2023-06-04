using Portfolio.Utilities;

namespace Test;
public class Converter_Tests
{
    [Test]
    public void StringToListChar_ConvertValidStringNoRepeatingCharacters_ShouldSuccessfullyReturnCorrectListOfChar()
    {
        // Arrange
        Converter converter = new();
        string sampleString = "A, B, C, D, E, F, G, H";

        // Act
        List<char> actual = converter.StringToListChar(sampleString);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.Count, Is.EqualTo(8));
            Assert.That(actual.First(), Is.EqualTo('A'));
            Assert.That(actual.Last(), Is.EqualTo('H'));
        });
    }

    [Test]
    public void StringToListChar_ConvertValidStringRepeatingCharacters_ShouldSuccessfullyReturnCorrectListOfChar()
    {
        // Arrange
        Converter converter = new();
        string sampleString = "A, A, C, D, A, F, G, A";

        // Act
        List<char> actual = converter.StringToListChar(sampleString);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.Count, Is.EqualTo(8));
            Assert.That(actual.First(), Is.EqualTo('A'));
            Assert.That(actual.Last(), Is.EqualTo('A'));
        });
    }

    [Test]
    public void StringToListChar_ConvertValidStringWithSameRepeatingCharacter_ShouldSuccessfullyReturnCorrectListOfChar()
    {
        // Arrange
        Converter converter = new();
        string sampleString = "A, A, A, A, A, A, A, A";

        // Act
        List<char> actual = converter.StringToListChar(sampleString);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.Count, Is.EqualTo(8));
            Assert.That(actual.First(), Is.EqualTo('A'));
            Assert.That(actual.Last(), Is.EqualTo('A'));
        });
    }

    [Test]
    public void StringToListChar_ConvertValidStringWithSingleCharacter_ShouldSuccessfullyReturnCorrectListOfChar()
    {
        // Arrange
        Converter converter = new();
        string sampleString = "A";

        // Act
        List<char> actual = converter.StringToListChar(sampleString);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual.First(), Is.EqualTo('A'));
            Assert.That(actual.Last(), Is.EqualTo('A'));
        });
    }
}