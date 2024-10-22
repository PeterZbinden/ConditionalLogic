namespace ConditionalLogic.Gates.Implementations;

internal class Or4<TEvaluationArgs> : ExpressionBase<TEvaluationArgs>
{
    private readonly ExpressionBase<TEvaluationArgs> _value1;
    private readonly ExpressionBase<TEvaluationArgs> _value2;
    private readonly ExpressionBase<TEvaluationArgs> _value3;
    private readonly ExpressionBase<TEvaluationArgs> _value4;

    public Or4()
    {

    }

    public Or4(ExpressionBase<TEvaluationArgs> value1, ExpressionBase<TEvaluationArgs> value2, ExpressionBase<TEvaluationArgs> value3, ExpressionBase<TEvaluationArgs> value4)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        return _value1.Evaluate(args)
               || _value2.Evaluate(args)
               || _value3.Evaluate(args)
               || _value4.Evaluate(args);
    }
}