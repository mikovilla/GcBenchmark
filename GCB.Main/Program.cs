using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Running;
using GCB.Specification;
using GCB.Specification.Cases;
using GCB.Specification.Domain;
using GCB.Utility.Instrumentations;


var config = Configuration.GetGCModeCombinationFromPlatform(new ConfigurationItem { 
    Platform = Platform.X64,
    Affinity = 1, 
    WarmUpCount = 2, 
    IterationCount = 10 
});

TimedAction.DisplayActionExecuteTime(() => BenchmarkRunner.Run<SingleThreadedWorkload>(config));