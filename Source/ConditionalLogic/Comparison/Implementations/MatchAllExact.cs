using System.Linq.Expressions;

namespace ConditionalLogic.Comparison.Implementations;

internal class MatchAllExact<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, ICollection<TValue>>
{
    public IList<TValue> ValueRequirements { get; set; }
    public bool CheckOrder { get; set; }

    public MatchAllExact()
    {

    }

    public MatchAllExact(Expression<Func<TEvaluationArgs, ICollection<TValue>>> property, bool checkOrder, params TValue[] valueRequirements)
        : base(property)
    {
        CheckOrder = checkOrder;
        ValueRequirements = valueRequirements;
    }

    public MatchAllExact(Expression<Func<TEvaluationArgs, ICollection<TValue>>> property, bool checkOrder, IList<TValue> valueRequirements)
        : base(property)
    {
        CheckOrder = checkOrder;
        ValueRequirements = valueRequirements;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        var propertyValue = GetPropertyValue(args);

        if (propertyValue == null)
        {
            if (ValueRequirements == null)
            {
                return true;
            }

            return false;
        }

        if (propertyValue.Count != ValueRequirements.Count)
        {
            // Exact match does not allow for differences
            return false;
        }

        return CheckOrder ? CheckExactOrderedMatch(propertyValue) 
            : CheckExactUnorderedMatch(propertyValue);
    }

    private bool CheckExactUnorderedMatch(ICollection<TValue> collection)
    {
        foreach (var option in ValueRequirements)
        {
            if (!collection.Contains(option))
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckExactOrderedMatch(ICollection<TValue> collection)
    {
        var i = 0;
        foreach (var item in collection)
        {
            var other = ValueRequirements[i];

            if (item == null)
            {
                if (other != null)
                {
                    return false;
                }

                continue;
            }

            if (!item.Equals(other))
            {
                return false;
            }

            i++;
        }

        return true;
    }
}