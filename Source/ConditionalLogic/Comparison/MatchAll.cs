using System.Collections;
using System.Linq.Expressions;
using ConditionalLogic.Comparison.Implementations;

namespace ConditionalLogic.Comparison;

public static class MatchAll
{
    public static ExpressionBase<TEvaluationArgs> Values<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, TValue>> property, params TValue[] valueRequirements)
        where TValue : ICollection
    {
        return new CollectionMatchAllStaticValues<TEvaluationArgs, TValue>(property, valueRequirements);
    }

    public static ExpressionBase<TEvaluationArgs> Values<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, TValue>> property, IList<TValue> valueRequirements)
        where TValue : ICollection
    {
        return new CollectionMatchAllStaticValues<TEvaluationArgs, TValue>(property, valueRequirements);
    }

    public static ExpressionBase<TEvaluationArgs> ExactValues<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, ICollection<TValue>>> property, bool checkOrder, params TValue[] valueRequirements)
    {
        return new MatchAllExact<TEvaluationArgs, TValue>(property, checkOrder, valueRequirements);
    }

    public static ExpressionBase<TEvaluationArgs> ExactValues<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, ICollection<TValue>>> property, bool checkOrder, IList<TValue> valueRequirements)
    {
        return new MatchAllExact<TEvaluationArgs, TValue>(property, checkOrder, valueRequirements);
    }
}