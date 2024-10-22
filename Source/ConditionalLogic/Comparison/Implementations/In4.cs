using System.Linq.Expressions;

namespace ConditionalLogic.Comparison.Implementations;

internal class In4<TEvaluationArgs, TValue> : PropertyComparisonBase<TEvaluationArgs, TValue>
{
    private readonly TValue _value1;
    private readonly TValue _value2;
    private readonly TValue _value3;
    private readonly TValue _value4;

    public In4()
    {

    }

    public In4(Expression<Func<TEvaluationArgs, TValue>> property, TValue value1, TValue value2, TValue value3, TValue value4)
        : base(property)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
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

        if (_value3 == null && property == null)
        {
            return true;
        }

        if (_value4 == null && property == null)
        {
            return true;
        }

        return (_value1?.Equals(property) ?? false)
               || (_value2?.Equals(property) ?? false)
               || (_value3?.Equals(property) ?? false)
               || (_value4?.Equals(property) ?? false);
    }
}