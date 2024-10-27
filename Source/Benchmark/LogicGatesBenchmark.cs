using BenchmarkDotNet.Attributes;
using ConditionalLogic;
using ConditionalLogic.Comparison;
using ConditionalLogic.Gates;
using DynamicExpresso;
using Jurassic;
using MoonSharp.Interpreter;

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
[MemoryDiagnoser]
public class LogicGatesBenchmark
{
    private const int A = 5;
    private const int B = 8;
    private const int C = 999;

    private readonly ExpressionBase<int> _andGate = AndAccessor.AndList(
        new List<ExpressionBase<int>>
        {
            new EqualsStaticValue<int,int>(x => x, A),
            new EqualsStaticValue<int,int>(x=>x, B)
        });
    private readonly ExpressionBase<int> _and2Gate = AndAccessor.And2(new EqualsStaticValue<int, int>(x => x, A), new EqualsStaticValue<int, int>(x => x, B));

    private EqualsStaticValue<int, int> a = new EqualsStaticValue<int, int>(x => x, A);
    private EqualsStaticValue<int, int> b = new EqualsStaticValue<int, int>(x => x, B);

    // Moonscript
    private string _luaScript1 = "return A==B and B==C";
    private string _luaScript2 = @"function Eval(a,b,c)
    return a==b and b==c
end";
    private Script _luaScript;

    // Dynamic Espresso
    private static Interpreter _espressoInterpreter = new Interpreter();
    private Parameter _paramA;
    private Parameter _paramB;
    private Parameter _paramC;
    private static string _expression = "A == B && B == C";
    private Lambda _parsedExpression;
    
    // Jurassic
    private ScriptEngine _jsScriptEngine;

    [GlobalSetup]
    public void Setup()
    {
        _luaScript = new Script();
        _luaScript.DoString(_luaScript2);

        _paramA = new Parameter("A", A);
        _paramB = new Parameter("B", B);
        _paramC = new Parameter("C", C);
        _parsedExpression = _espressoInterpreter.Parse(_expression, _paramA, _paramB, _paramC);

        _jsScriptEngine = new ScriptEngine();
        _jsScriptEngine.Evaluate(@"function Eval(a,b,c){
    return a == b && b == c;
}");
    }

    [Benchmark]
    public bool SimpleEquals()
    {
        return a.Evaluate(C) && b.Evaluate(C);
    }

    [Benchmark]
    public bool AndListGate()
    {
        return _andGate.Evaluate(C);
    }

    [Benchmark]
    public bool And2Gate()
    {
        return _and2Gate.Evaluate(C);
    }

    [Benchmark]
    public bool NativeAnd()
    {
        return (A == C && B == C);
    }

    [Benchmark]
    public bool MoonSharp()
    {
        var scriptResult = _luaScript.Call(_luaScript.Globals["Eval"], A, B, C);
        return scriptResult.Boolean;
    }
    
    [Benchmark]
    public bool DynamicEspressoParsed()
    {
        return (bool)_parsedExpression.Invoke(_paramA, _paramB, _paramC);
    }

    [Benchmark]
    public bool Jurassic()
    {
        return _jsScriptEngine.CallGlobalFunction<bool>("Eval", A, B, C);
    }
}