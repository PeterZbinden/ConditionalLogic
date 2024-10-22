using ConditionalLogic.Comparison;
using FluentAssertions;

namespace ConditionalLogic.Tests;

public class ContainsStaticValueTests
{
    [Fact]
    public void Ensure_MatchingProperty_ReturnsTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "1"
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p=> p.Id, "1");

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(true);
    }

    [Fact]
    public void Ensure_NotMatchingProperty_ReturnsFalse()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "1"
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p => p.Id, "2");

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void Ensure_PartiallyMatchingProperty_FromStart_ReturnsTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "12"
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p => p.Id, "1");

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(true);
    }

    [Fact]
    public void Ensure_PartiallyMatchingProperty_FromEnd_ReturnsTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "21"
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p => p.Id, "1");

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(true);
    }

    [Fact]
    public void Ensure_PartiallyMatchingProperty_InTheMiddle_ReturnsTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "212"
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p => p.Id, "1");

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(true);
    }

    [Fact]
    public void Ensure_NullValue_AndNonNullProperty_ReturnsFalse()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "212"
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p => p.Id, null);

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void Ensure_NonNullValue_AndNullProperty_ReturnsFalse()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = null
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p => p.Id, "1");

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void Ensure_NullValue_AndNullProperty_ReturnsTrue()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = null
        };
        var comparison = new ContainsStaticValue<SamplePerson>(p => p.Id, null);

        // Act
        var isEqual = comparison.Evaluate(p);

        // Assert
        isEqual.Should().Be(true);
    }
}