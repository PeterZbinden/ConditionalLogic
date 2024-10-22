namespace ConditionalLogic;

public abstract class ExpressionBase<TEvaluationArgs>
{
    public abstract bool Evaluate(TEvaluationArgs args);
}