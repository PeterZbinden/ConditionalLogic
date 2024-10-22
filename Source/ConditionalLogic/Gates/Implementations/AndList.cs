namespace ConditionalLogic.Gates.Implementations;

internal class AndList<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    public IList<ExpressionBase<TEvaluationArgs>> Rules { get; set; }

    public AndList()
    {

    }

    public AndList(IList<ExpressionBase<TEvaluationArgs>> rules)
    {
        Rules = rules;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        foreach (var rule in Rules)
        {
            if (!rule.Evaluate(args))
            {
                // Only one rule that evalues to 'false' is enough to return 'fals'
                return false;
            }
        }

        // None of the rules evaluated to 'false'
        return true;
    }
}