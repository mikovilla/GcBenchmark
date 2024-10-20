using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Running;
using GCB.Specification;
using GCB.Specification.Cases;

var config = Configuration.GetGCModeCombinationFromPlatform(Platform.X64);
var summary = BenchmarkRunner.Run<DelayedMultiThreadedWorkload>(config);