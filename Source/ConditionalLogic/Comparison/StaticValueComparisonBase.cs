using System.Linq.Expressions;

namespace ConditionalLogic.Comparison;

public abstract class StaticValueComparisonBase<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, TValue>
{
    public TValue Value { get; set; }

    public StaticValueComparisonBase()
    {

    }

    public StaticValueComparisonBase(Expression<Func<TEvaluationArgs, TValue>> property, TValue value)
    : base(property)
    {
        Property = property;
        Value = value;
    }
}