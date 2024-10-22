using System.Linq.Expressions;
using ConditionalLogic.Comparison.Implementations;
using ConditionalLogic.Gates;

namespace ConditionalLogic.Comparison;

public static class In
{
    public static ExpressionBase<TEvaluationArgs> Values<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, TValue>> property, params TValue[] values)
    {
        return GetIn(property, values);
    }

    public static ExpressionBase<TEvaluationArgs> Values<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, TValue>> property, IList<TValue> values)
    {
        return GetIn(property, values);
    }

    private static ExpressionBase<TEvaluationArgs> GetIn<TEvaluationArgs, TValue>(Expression<Func<TEvaluationArgs, TValue>> property, IList<TValue> values)
    {
        if (values == null)
        {
            throw new NullReferenceException($"{nameof(Values)} must not be NULL");
        }

        switch (values.Count)
        {
            case 0:
                return new False<TEvaluationArgs>(); // If no values are provided, then the evaluation will always be false, so we can shortcut it
            case 1:
                return new EqualsStaticValue<TEvaluationArgs, TValue>(property, values[0]);
            case 2:
                return new In2<TEvaluationArgs, TValue>(property, values[0], values[1]);
            case 3:
                return new In3<TEvaluationArgs, TValue>(property, values[0], values[1], values[2]);
            case 4:
                return new In4<TEvaluationArgs, TValue>(property, values[0], values[1], values[2], values[3]);
            default:
                return new InStaticList<TEvaluationArgs, TValue>(property, values);
        }
    }
}

