using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Running;
using GCB.Specification;
using GCB.Specification.Cases;
using GCB.Utility.Instrumentations;

var config = Configuration.GetGCModeCombinationFromPlatform(Platform.X64, lowIteration: true);
TimedAction.DisplayActionExecuteTime(() => BenchmarkRunner.Run<SingleThreadedWorkload>(config));