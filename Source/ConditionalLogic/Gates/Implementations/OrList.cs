namespace ConditionalLogic.Gates.Implementations;

internal class OrList<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    public IList<ExpressionBase<TEvaluationArgs>> Rules { get; set; }

    public OrList()
    {

    }

    public OrList(IList<ExpressionBase<TEvaluationArgs>> rules)
    {
        Rules = rules;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        foreach (var rule in Rules)
        {
            if (rule.Evaluate(args))
            {
                // In a OR-Condition, if any of the provided rules evaluate to 'true' the result is also true
                return true;
            }
        }
        // None of the rules evaluated to 'true'
        return false;
    }
}