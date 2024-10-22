using System.Collections;
using System.Linq.Expressions;
using ConditionalLogic.Comparison.Implementations;

namespace ConditionalLogic.Comparison;

public static class MatchAny
{
    public static ExpressionBase<TEvaluationArgs> Values<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, TValue>> property, params TValue[] valueOptions)
        where TValue : ICollection
    {
        return new CollectionMatchAnyStaticValue<TEvaluationArgs, TValue>(property, valueOptions);
    }

    public static ExpressionBase<TEvaluationArgs> Values<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, TValue>> property, IList<TValue> valueOptions)
        where TValue : ICollection
    {
        return new CollectionMatchAnyStaticValue<TEvaluationArgs, TValue>(property, valueOptions);
    }
}