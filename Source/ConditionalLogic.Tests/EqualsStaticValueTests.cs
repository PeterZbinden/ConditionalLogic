using ConditionalLogic.Comparison;
using FluentAssertions;

namespace ConditionalLogic.Tests;

public class EqualsStaticValueTests
{
    [Fact]
    public void Ensure_CorrectValue_ReturnsTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var equals = new EqualsStaticValue<SamplePerson, string>(p => p.FirstName, "Max");

        // Act
        var result = equals.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_IncorrectValue_ReturnsFalse()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var equals = new EqualsStaticValue<SamplePerson, string>(p => p.FirstName, "John");

        // Act
        var result = equals.Evaluate(p);

        // Assert
        result.Should().Be(false);
    }
}