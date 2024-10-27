using ConditionalLogic.Serializer;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace ConditionalLogic.Comparison;

public abstract class PropertyComparisonBase<TEvaluationArgs, TValue> : ExpressionBase<TEvaluationArgs>
{
    private Expression<Func<TEvaluationArgs, TValue>> _property;
    protected Func<TEvaluationArgs, TValue> GetPropertyValue;
    private string _propertyExpression;

    [JsonIgnore]
    public Expression<Func<TEvaluationArgs, TValue>> Property
    {
        get => _property;
        set
        {
            _property = value;
            _propertyExpression = ExpSerializer.Serialize<TEvaluationArgs>(value);
            GetPropertyValue = value.Compile();
        }
    }

    public string PropertyExpression
    {
        get => _propertyExpression;
        set
        {
            _propertyExpression = value;
            Property = (Expression<Func<TEvaluationArgs, TValue>>)ExpSerializer.Deserialize<TEvaluationArgs>(value);
        }
    }

    public PropertyComparisonBase()
    {
        
    }

    public PropertyComparisonBase(Expression<Func<TEvaluationArgs, TValue>> property)
    {
        Property = property;
    }
}