using System.Collections;
using System.Linq.Expressions;

namespace ConditionalLogic.Comparison.Implementations;

internal class CollectionMatchAllStaticValues<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, TValue>
    where TValue : ICollection
{
    public IList<TValue> ValueRequirements { get; set; }

    public CollectionMatchAllStaticValues()
    {

    }

    public CollectionMatchAllStaticValues(Expression<Func<TEvaluationArgs, TValue>> property, params TValue[] valueRequirements)
        : base(property)
    {
        ValueRequirements = valueRequirements;
    }

    public CollectionMatchAllStaticValues(Expression<Func<TEvaluationArgs, TValue>> property, IList<TValue> valueRequirements)
        : base(property)
    {
        ValueRequirements = valueRequirements;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        var propertyValue = GetPropertyValue(args);

        if (propertyValue is not ICollection<TValue> collection)
        {
            return false;
        }

        foreach (var option in ValueRequirements)
        {
            if (!collection.Contains(option))
            {
                return false;
            }
        }

        return true;
    }
}