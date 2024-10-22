using System.Linq.Expressions;

namespace ConditionalLogic.Comparison;

public class EqualsStaticValue<TEvaluationArgs, TValue> : StaticValueComparisonBase<TEvaluationArgs, TValue>
{
    public EqualsStaticValue()
    {

    }

    public EqualsStaticValue(Expression<Func<TEvaluationArgs, TValue>> property, TValue value)
        : base(property, value)
    {
        Property = property;
        Value = value;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        var value = GetPropertyValue(args);

        if (value == null || Value == null)
        {
            if (value == null && Value != null)
            {
                return false;
            }

            if (value != null && Value == null)
            {
                return false;
            }

            return true;
        }

        return value.Equals(Value);
    }
}