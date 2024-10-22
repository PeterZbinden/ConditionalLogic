using ConditionalLogic.Gates.Implementations;

namespace ConditionalLogic.Gates;

public static class Or
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
                return rules[0];
            case 2:
                return new Or2<TEvaluationArgs>(rules[0], rules[1]);
            case 3:
                return new Or3<TEvaluationArgs>(rules[0], rules[1], rules[2]);
            case 4:
                return new Or4<TEvaluationArgs>(rules[0], rules[1], rules[2], rules[3]);
            default:
                return new OrList<TEvaluationArgs>(rules);
        }
    }
}