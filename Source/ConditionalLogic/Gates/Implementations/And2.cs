namespace ConditionalLogic.Gates.Implementations;

internal class And2<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    public ExpressionBase<TEvaluationArgs> Value1 { get; init; }
    public ExpressionBase<TEvaluationArgs> Value2 { get; init; }

    public And2()
    {

    }

    public And2(ExpressionBase<TEvaluationArgs> value1, ExpressionBase<TEvaluationArgs> value2)
    {
        Value1 = value1;
        Value2 = value2;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        return Value1.Evaluate(args) 
               && Value2.Evaluate(args);
    }
}