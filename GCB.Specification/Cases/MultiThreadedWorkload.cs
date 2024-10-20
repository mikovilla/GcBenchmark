using BenchmarkDotNet.Attributes;
using GCB.Utility;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class MultiThreadedWorkload
    {
        [Benchmark]
        public void AllocateObjectsInParallel()
        {
            Parallel.For(0, 1000, _ =>
            {
                byte[] largeArray = new byte[short.MaxValue];
                largeArray[0] = 42;
            });
        }
    }
}
