using ConditionalLogic.Gates.Implementations;

namespace ConditionalLogic.Gates;

public abstract class And
{
    public static ExpressionBase<TEvaluationArgs> Gate<TEvaluationArgs>(params ExpressionBase<TEvaluationArgs>[] rules)
    {
        return GetByList(rules);
    }

    public static ExpressionBase<TEvaluationArgs> Gate<TEvaluationArgs>(IList<ExpressionBase<TEvaluationArgs>> rules)
    {
        return GetByList(rules);
    }

    private static ExpressionBase<TEvaluationArgs> GetByList<TEvaluationArgs>(IList<ExpressionBase<TEvaluationArgs>> rules)
    {
        if (rules == null)
        {
            throw new NullReferenceException($"{nameof(rules)} must not be NULL");
        }

        switch (rules.Count)
        {
            case 0:
                return new False<TEvaluationArgs>();
            case 1:
                return GetAnd1(rules[0]);
            case 2:
                return GetAnd2(rules[0], rules[1]);
            case 3:
                return GetAnd3(rules[0], rules[1], rules[2]);
            case 4:
                return GetAnd4(rules[0], rules[1], rules[2], rules[3]);
            default:
                return GetAndList(rules);
        }
    }

    protected static ExpressionBase<TEvaluationArgs> GetAnd1<TEvaluationArgs>(
        ExpressionBase<TEvaluationArgs> rule)
    {
        return rule;
    }

    protected static ExpressionBase<TEvaluationArgs> GetAnd2<TEvaluationArgs>(
        ExpressionBase<TEvaluationArgs> rule1, 
        ExpressionBase<TEvaluationArgs> rule2)
    {
        return new And2<TEvaluationArgs>(rule1, rule2);
    }

    protected static ExpressionBase<TEvaluationArgs> GetAnd3<TEvaluationArgs>(
        ExpressionBase<TEvaluationArgs> rule1, 
        ExpressionBase<TEvaluationArgs> rule2, 
        ExpressionBase<TEvaluationArgs> rule3)
    {
        return new And3<TEvaluationArgs>(rule1, rule2, rule3);
    }

    protected static ExpressionBase<TEvaluationArgs> GetAnd4<TEvaluationArgs>(
        ExpressionBase<TEvaluationArgs> rule1,
        ExpressionBase<TEvaluationArgs> rule2,
        ExpressionBase<TEvaluationArgs> rule3,
        ExpressionBase<TEvaluationArgs> rule4)
    {
        return new And4<TEvaluationArgs>(rule1, rule2, rule3, rule4);
    }

    protected static ExpressionBase<TEvaluationArgs> GetAndList<TEvaluationArgs>(IList<ExpressionBase<TEvaluationArgs>> rules)
    {
        return new AndList<TEvaluationArgs>(rules);
    }
}