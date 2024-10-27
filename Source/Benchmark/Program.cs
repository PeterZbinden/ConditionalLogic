using Benchmark;
using BenchmarkDotNet.Running;

var x = new LogicGatesBenchmark();
x.Setup();
x.MoonSharp2();
BenchmarkRunner.Run<LogicGatesBenchmark>();