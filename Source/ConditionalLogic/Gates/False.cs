namespace ConditionalLogic.Gates;

/// <summary>
/// Expression that always returns false. Can be used as a default or for conditions that are always false.
/// </summary>
public class False<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    public override bool Evaluate(TEvaluationArgs args)
    {
        return false;
    }
}