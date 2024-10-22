namespace ConditionalLogic.Gates;

public class Not<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    public ExpressionBase<TEvaluationArgs> Rule { get; set; }

    public Not()
    {

    }

    public Not(ExpressionBase<TEvaluationArgs> rule)
    {
        Rule = rule;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        // Invert the rules result
        return !Rule.Evaluate(args);
    }
}