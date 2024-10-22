namespace ConditionalLogic.Gates.Implementations;

internal class And2<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    private readonly ExpressionBase<TEvaluationArgs> _value1;
    private readonly ExpressionBase<TEvaluationArgs> _value2;

    public And2()
    {

    }

    public And2(ExpressionBase<TEvaluationArgs> value1, ExpressionBase<TEvaluationArgs> value2)
    {
        _value1 = value1;
        _value2 = value2;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        return _value1.Evaluate(args) 
               && _value2.Evaluate(args);
    }
}