using BenchmarkDotNet.Attributes;
using GCB.Utility;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class MultiThreadedWorkload
    {
        [Benchmark]
        public void RunMultipleThreads()
        {
            Parallel.For(0, 1000, _ =>
            {
                byte[] largeArray = new byte[88_000];
                largeArray[0] = 42;
            });
            GC.Collect();
        }
    }
}
