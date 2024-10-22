using System.Linq.Expressions;

namespace ConditionalLogic.Comparison;

public class StartsWithStaticValue<TEvaluationArgs> : StaticValueComparisonBase<TEvaluationArgs, string>
{
    public StartsWithStaticValue()
    {
        
    }

    public StartsWithStaticValue(Expression<Func<TEvaluationArgs, string>> property, string value)
        : base(property, value)
    {
        
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        var value = GetPropertyValue(args);

        if (value == null || Value == null)
        {
            return value == Value;
        }

        return value.StartsWith(Value);
    }
}