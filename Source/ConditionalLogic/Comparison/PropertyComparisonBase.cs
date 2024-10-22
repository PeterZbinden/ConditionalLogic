using System.Linq.Expressions;

namespace ConditionalLogic.Comparison;

public abstract class PropertyComparisonBase<TEvaluationArgs, TValue> : ExpressionBase<TEvaluationArgs>
{
    private Expression<Func<TEvaluationArgs, TValue>> _property;
    protected Func<TEvaluationArgs, TValue> GetPropertyValue;
    public Expression<Func<TEvaluationArgs, TValue>> Property
    {
        get => _property;
        set
        {
            _property = value;
            GetPropertyValue = value.Compile();
            // TODO: Serialize Expression on set
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