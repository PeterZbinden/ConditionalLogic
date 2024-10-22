using System.Collections;
using System.Linq.Expressions;

namespace ConditionalLogic.Comparison.Implementations;

internal class CollectionMatchAnyStaticValue<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, TValue>
    where TValue : ICollection
{
    public IList<TValue> ValueOptions { get; set; }

    public CollectionMatchAnyStaticValue()
    {

    }

    public CollectionMatchAnyStaticValue(Expression<Func<TEvaluationArgs, TValue>> property, params TValue[] valueOptions)
        : base(property)
    {
        ValueOptions = valueOptions;
    }

    public CollectionMatchAnyStaticValue(Expression<Func<TEvaluationArgs, TValue>> property, IList<TValue> valueOptions)
        : base(property)
    {
        ValueOptions = valueOptions;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        var propertyValue = GetPropertyValue(args);

        if (propertyValue is not ICollection<TValue> collection)
        {
            return false;
        }

        foreach (var option in ValueOptions)
        {
            if (collection.Contains(option))
            {
                return true;
            }
        }

        return false;
    }
}