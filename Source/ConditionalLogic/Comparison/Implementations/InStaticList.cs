using System.Linq.Expressions;

namespace ConditionalLogic.Comparison.Implementations;

internal class InStaticList<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, TValue>
{
    public IList<TValue> Values { get; set; }

    public InStaticList()
    {

    }

    public InStaticList(Expression<Func<TEvaluationArgs, TValue>> property, params TValue[] values)
        : base(property)
    {
        Values = values;
    }

    public InStaticList(Expression<Func<TEvaluationArgs, TValue>> property, IList<TValue> values)
        : base(property)
    {
        Values = values;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        var value = GetPropertyValue(args);

        return Values.Contains(value);
    }
}