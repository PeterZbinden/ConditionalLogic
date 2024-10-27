using System.Linq.Expressions;
using ConditionalLogic.Comparison;
using ConditionalLogic.Gates;
using FluentAssertions;

namespace ConditionalLogic.Tests;

public class GetPropValue<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, TValue>
{
    public GetPropValue()
    {
        
    }

    public GetPropValue(Expression<Func<TEvaluationArgs, TValue>> property)
    : base(property)
    {
        
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        throw new NotImplementedException();
    }

    public TValue GetValue(TEvaluationArgs args)
    {
        return GetPropertyValue(args);
    }
}

public class SerializerTests
{
    [Fact]
    public void Ensure_Expression_CanBeSerializedAndDeserialized()
    {

        // Arrange
        var p = new SamplePerson
        {
            Id = "123"
        };

        var prop = new GetPropValue<SamplePerson, string>(p => p.Id);

        // Act
        var exp = prop.PropertyExpression;
        var newProp = new GetPropValue<SamplePerson, string>
        {
            PropertyExpression = exp
        };

        var value = newProp.GetValue(p);

        // Assert
        value.Should().Be(p.Id);
    }

    [Fact]
    public void Ensure_ConditionalLogic_CanBeSerializedAndDeserialized()
    {
        // Arrange
        var p = new SamplePerson
        {
            Id = "123",
            FirstName = "Max"
        };

        var and = And.Gate(new EqualsStaticValue<SamplePerson, string>(p => p.Id, "123"),
            new EqualsStaticValue<SamplePerson,string>(p => p.FirstName, "Max"));

        // Act
        var json = System.Text.Json.JsonSerializer.Serialize(and);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<ExpressionBase<SamplePerson>>(json);

        // Assert
        deserialized.Evaluate(p).Should().Be(true);
    }
}