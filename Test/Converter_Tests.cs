using Portfolio.Utilities;

namespace Test;
public class Converter_Tests
{
    [Test]
    public void StringToListChar_ConvertValidString_ShouldSuccessfullyReturnCorrectListOfChar()
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
}