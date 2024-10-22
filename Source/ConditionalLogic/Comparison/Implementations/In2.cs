using System.Linq.Expressions;

namespace ConditionalLogic.Comparison.Implementations;

internal class In2<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, TValue>
{
    private readonly TValue _value1;
    private readonly TValue _value2;

    public In2()
    {

    }

    public In2(Expression<Func<TEvaluationArgs, TValue>> property, TValue value1, TValue value2)
        : base(property)
    {
        _value1 = value1;
        _value2 = value2;
    }

    public override bool Evaluate(TEvaluationArgs args)
    {
        var property = GetPropertyValue(args);
        if (_value1 == null && property == null)
        {
            return true;
        }

        if (_value2 == null && property == null)
        {
            return true;
        }

        return (_value1?.Equals(property) ?? false)
               || (_value2?.Equals(property) ?? false);
    }
}