using System.Linq.Expressions;

namespace ConditionalLogic.Comparison;

public class ContainsStaticValue<TEvaluationArgs> : StaticValueComparisonBase<TEvaluationArgs, string>
{
    public ContainsStaticValue()
    {

    }

    public ContainsStaticValue(Expression<Func<TEvaluationArgs, string>> property, string value)
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

        return value.Contains(Value);
    }
}