using Benchmark;
using BenchmarkDotNet.Running;

//var x = new LogicGatesBenchmark();
//x.Setup();
//x.Jurassic();
BenchmarkRunner.Run<LogicGatesBenchmark>();