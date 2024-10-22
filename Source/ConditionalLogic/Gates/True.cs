namespace ConditionalLogic.Gates;

/// <summary>
/// Expression that always returns true. Can be used as a default or for conditions that are always true
/// </summary>
public class True<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    public override bool Evaluate(TEvaluationArgs args)
    {
        return true;
    }
}