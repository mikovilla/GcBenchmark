using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;

namespace GCB.Specification
{
    public class Configuration
    {
        public static ManualConfig GetGCModeCombinationFromPlatform(Platform platform)
        {
            var anyCpu = Job.Default
            .WithRuntime(CoreRuntime.Core80)
            .WithToolchain(CsProjCoreToolchain.NetCoreApp80)
            .WithStrategy(RunStrategy.Throughput);

            var x64 = anyCpu.WithPlatform(Platform.X64);
            var x86 = anyCpu.WithPlatform(Platform.X86);

            Job[] x64Jobs = new[]
            {
                x64.WithGcMode(new GcMode { Concurrent = true, Server = true }),
                x64.WithGcMode(new GcMode { Concurrent = true, Server = false }),
                x64.WithGcMode(new GcMode { Concurrent = false, Server = true }),
                x64.WithGcMode(new GcMode { Concurrent = false, Server = false })
            };

            Job[] x86Jobs = new[]
            {
                x86.WithGcMode(new GcMode { Concurrent = true, Server = true }),
                x86.WithGcMode(new GcMode { Concurrent = true, Server = false }),
                x86.WithGcMode(new GcMode { Concurrent = false, Server = true }),
                x86.WithGcMode(new GcMode { Concurrent = false, Server = false })
            };

            Job[] anyCpuJobs = x64Jobs.Concat(x86Jobs).ToArray();

            Job[] jobs = platform switch
            {
                Platform.X86 => x86Jobs,
                Platform.X64 => x64Jobs,
                Platform.AnyCpu => anyCpuJobs,
                _ => throw new UnsupportedPlatformException("Unsupported Platform: use X86, X64, or AnyCpu")
            };

            return ManualConfig
            .Create(DefaultConfig.Instance)
            .AddJob(jobs)
            .AddColumn(StatisticColumn.OperationsPerSecond);
        }
    }
}
