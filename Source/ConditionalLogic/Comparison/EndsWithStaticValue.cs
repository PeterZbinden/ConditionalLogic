using System.Linq.Expressions;

namespace ConditionalLogic.Comparison;

public class EndsWithStaticValue<TEvaluationArgs> : StaticValueComparisonBase<TEvaluationArgs, string>
{
    public EndsWithStaticValue()
    {

    }

    public EndsWithStaticValue(Expression<Func<TEvaluationArgs, string>> property, string value)
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

        return value.EndsWith(Value);
    }
}