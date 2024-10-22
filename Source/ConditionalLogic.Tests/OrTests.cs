using ConditionalLogic.Comparison;
using ConditionalLogic.Gates;
using FluentAssertions;

namespace ConditionalLogic.Tests;

public class OrTests
{
    [Fact]
    public void Ensure_SingleOrCondition_AllCorrect_ReturnsTrue()
    {
        // Arrange
        var person = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var condition = new EqualsStaticValue<SamplePerson, string>(p => p.FirstName, "Max");
        var and = Or.Gate(condition);

        // Act
        var value = and.Evaluate(person);

        // Assert
        value.Should().Be(true);
    }

    [Fact]
    public void Ensure_MultipleOrCondition_AllCorrect_ReturnsTrue()
    {
        // Arrange
        var person = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var condition1 = new EqualsStaticValue<SamplePerson, string>(p => p.FirstName, "Max");
        var condition2 = new EqualsStaticValue<SamplePerson, string>(p => p.LastName, "Muster");
        var and = Or.Gate(condition1, condition2);

        // Act
        var value = and.Evaluate(person);

        // Assert
        value.Should().Be(true);
    }

    [Fact]
    public void Ensure_SingleOrCondition_AllIncorrect_ReturnsFalse()
    {
        // Arrange
        var person = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var condition = new EqualsStaticValue<SamplePerson, string>(p => p.FirstName, "John");
        var and = Or.Gate(condition);

        // Act
        var value = and.Evaluate(person);

        // Assert
        value.Should().Be(false);
    }

    [Fact]
    public void Ensure_MultipleOrCondition_OneIncorrect_ReturnsTrue()
    {
        // Arrange
        var person = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var condition1 = new EqualsStaticValue<SamplePerson, string>(p => p.FirstName, "John");
        var condition2 = new EqualsStaticValue<SamplePerson, string>(p => p.LastName, "Muster");
        var and = Or.Gate(condition1, condition2);

        // Act
        var value = and.Evaluate(person);

        // Assert
        value.Should().Be(true);
    }

    [Fact]
    public void Ensure_MultipleOrCondition_AllIncorrect_ReturnsFalse()
    {
        // Arrange
        var person = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var condition1 = new EqualsStaticValue<SamplePerson, string>(p => p.FirstName, "John");
        var condition2 = new EqualsStaticValue<SamplePerson, string>(p => p.LastName, "Doe");
        var and = Or.Gate(condition1, condition2);

        // Act
        var value = and.Evaluate(person);

        // Assert
        value.Should().Be(false);
    }

    [Fact]
    public void Ensure_WhenCreatingOrGateWithNullCollection_ThrowsException()
    {
        // Arrange

        // Act
        var action = () => Or.Gate<SamplePerson>(null); ;


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
    public void Ensure_DifferentOrImplementations_EvaluateAllRules(int arguments)
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "123"
        };
        var conditions = new List<ExpressionBase<SamplePerson>>();

        for (int i = 0; i < arguments - 1; i++)
        {
            conditions.Add(new EqualsStaticValue<SamplePerson, string>(x => x.Id, "Does Not Exist"));
        }
        // We set the last item as true, so that the evaluation has to go through all arguments to get to the right answer
        conditions.Add(new EqualsStaticValue<SamplePerson, string>(x => x.Id, "123"));

        var or = Or.Gate(conditions);

        // Act
        var result = or.Evaluate(p);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Ensure_EmptyConditionsList_ReturnsFalse()
    {
        // Arrange
        var person = new SamplePerson
        {
            Id = "1",
            FirstName = "Max",
            LastName = "Muster"
        };
        var conditions = new List<ExpressionBase<SamplePerson>>
        {

        };

        var and = Or.Gate(conditions);

        // Act
        var value = and.Evaluate(person);

        // Assert
        value.Should().Be(false);
    }
}