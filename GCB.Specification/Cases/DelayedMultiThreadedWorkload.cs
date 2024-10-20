using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class DelayedMultiThreadedWorkload
    {
        [Benchmark]
        public void RunDelayedMultipleThreads()
        {
            Parallel.For(0, 1000, _ =>
            {
                byte[] notSoLargeArray = new byte[short.MaxValue];
                notSoLargeArray[0] = 87;
                Thread.Sleep(10);
            });
            GC.Collect();
        }
    }
}
