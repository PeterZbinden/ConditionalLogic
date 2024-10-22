using ConditionalLogic.Comparison;
using ConditionalLogic.Comparison.Implementations;
using ConditionalLogic.Gates;
using FluentAssertions;

namespace ConditionalLogic.Tests;

public class InStaticListTests
{
    [Fact]
    public void Ensure_WhenPropertyIsInList_ReturnsTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "1"
        };
        var condition = In.Values<SamplePerson, string>(p => p.Id, "1");

        // Act
        var value = condition.Evaluate(p);

        // Assert
        value.Should().Be(true);
    }

    [Fact]
    public void Ensure_WhenPropertyIsNotInList_ReturnsFalse()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "1"
        };
        var condition = In.Values<SamplePerson, string>(p => p.Id, "2");

        // Act
        var value = condition.Evaluate(p);

        // Assert
        value.Should().Be(false);
    }

    [Fact]
    public void Ensure_WhenPropertyIsCheckedAgainstEmptyList_ReturnsFalse()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "1"
        };
        var condition = In.Values<SamplePerson, string>(p => p.Id);

        // Act
        var value = condition.Evaluate(p);

        // Assert
        value.Should().Be(false);
    }

    [Fact]
    public void Ensure_WhenCreatingInWithNullCollection_ThrowsException()
    {
        // Arrange

        // Act
        var action = () => In.Values<SamplePerson, string>(p => p.Id, null); ;


        // Assert
        action.Should().Throw<NullReferenceException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(1024)]
    public void Ensure_DifferentInImplementations_EvaluateAllValues(int itemsCount)
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "123"
        };
        var values = new List<string>();

        for (int i = 0; i < itemsCount - 1; i++)
        {
            values.Add("Does Not Exist");
        }
        // We set the last item as false, so that the evaluation has to go through all arguments to get to the right answer
        values.Add("123");

        var inComparison = In.Values<SamplePerson, string>(p => p.Id, values);

        // Act
        var result = inComparison.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_EmptyValuesList_EvaluateToFalse()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "123"
        };
        var values = new List<string>();
        
        var inComparison = In.Values<SamplePerson, string>(p => p.Id, values);

        // Act
        var result = inComparison.Evaluate(p);

        // Assert
        result.Should().Be(false);
    }
}