using BenchmarkDotNet.Attributes;
using ConditionalLogic;
using ConditionalLogic.Comparison;
using ConditionalLogic.Gates;

namespace Benchmark;

/// <summary>
/// Way to access internal Implementations without advertising them to Users of the Library if it were part of the public API-Surface
/// </summary>
public class AndAccessor : And
{
    public static ExpressionBase<TEvaluationArgs> And2<TEvaluationArgs>(
        ExpressionBase<TEvaluationArgs> rule1,
        ExpressionBase<TEvaluationArgs> rule2)
    {
        return GetAnd2(rule1, rule2);
    }

    public static ExpressionBase<TEvaluationArgs> AndList<TEvaluationArgs>(
        IList<ExpressionBase<TEvaluationArgs>> rules)
    {
        return GetAndList(rules);
    }
}

public class LogicGatesBenchmark
{
    public int Count { get; set; } = 1000;
    private const int A = 5;
    private const int B = 8;
    private const int C = 999;

    private readonly ExpressionBase<int> _andGate = AndAccessor.AndList(
        new List<ExpressionBase<int>>
        {
            new EqualsStaticValue<int,int>(x => x, A), 
            new EqualsStaticValue<int,int>(x=>x, B)
        });
    private readonly ExpressionBase<int> _and2Gate = AndAccessor.And2(new EqualsStaticValue<int,int>(x => x, A), new EqualsStaticValue<int,int>(x=>x, B));
    
    private EqualsStaticValue<int, int> a = new EqualsStaticValue<int, int>(x => x, A);
    private EqualsStaticValue<int, int> b = new EqualsStaticValue<int, int>(x => x, B);

    [Benchmark]
    public bool SimpleEquals()
    {
        var result = true;
        for (int i = 0; i < Count; i++)
        {
            result &= a.Evaluate(C) && b.Evaluate(C);
        }

        return result;
    }

    [Benchmark]
    public bool AndListGate()
    {
        var result = true;
        for (int i = 0; i < Count; i++)
        {
            result &= _andGate.Evaluate(C);
        }

        return result;
    }

    [Benchmark]
    public bool And2Gate()
    {
        var result = true;
        for (int i = 0; i < Count; i++)
        {
            result &= _and2Gate.Evaluate(C);
        }

        return result;
    }

    //[Benchmark]
    public void OrGate()
    {

    }

    [Benchmark]
    public bool NativeAnd()
    {
        var result = true;
        for (int i = 0; i < Count; i++)
        {
            result &= (A == C && B == C);
        }

        return result;
    }

    //[Benchmark]
    public void NativeOr()
    {

    }
}