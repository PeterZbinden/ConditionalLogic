using ConditionalLogic.Comparison;
using FluentAssertions;

namespace ConditionalLogic.Tests;

public class MatchAllExactTests
{
    [Fact]
    public void Ensure_UnorderedCheckOf_TwoEmptyLists_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson()
        {
            Values = new List<int>
            {

            }
        };
        var a = new List<int>();
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, false, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_UnorderedCheckOf_NullLists_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson()
        {
            Values = null
        };
        List<int> a = null;
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, false, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_OrderedCheckOf_TwoEmptyLists_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson()
        {
            Values = new List<int>
            {

            }
        };
        var a = new List<int>();
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, true, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_OrderedCheckOf_NullLists_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson()
        {
            Values = null
        };
        List<int> a = null;
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, true, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_UnorderedCheckOf_TwoListsWithSameItemsAndSameOrder_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson()
        {
            Values = new List<int>
            {
                1, 2, 3
            }
        };
        var a = new List<int>
        {
            1, 2, 3
        };
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, false, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_UnorderedCheckOf_TwoListsWithSameItemsButDifferentOrder_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson()
        {
            Values = new List<int>
            {
                3, 1, 2
            }
        };
        var a = new List<int>
        {
            1, 2, 3
        };
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, false, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_OrderedCheckOf_TwoListsWithSameItemsAndSameOrder_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Values = new List<int>
            {
                1, 2, 3
            }
        };
        var a = new List<int>
        {
            1, 2, 3
        };
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, true, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_OrderedCheckOf_TwoListsWithSameItemsButDifferentOrder_ReturnTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Values = new List<int>
            {
                3, 1, 2
            }
        };
        var a = new List<int>
        {
            1, 2, 3
        };
        var match = MatchAll.ExactValues<SamplePerson, int>(e => e.Values, true, a);

        // Act
        var result = match.Evaluate(p);

        // Assert
        result.Should().Be(false);
    }
}