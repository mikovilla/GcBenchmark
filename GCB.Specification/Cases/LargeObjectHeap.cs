using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class LargeObjectHeap
    {
        private List<byte[]>? largeObjects;
        int largeObjectSize = 88_000;

        [GlobalSetup]
        public void Setup()
        {
            largeObjects = new List<byte[]>();
        }

        [Benchmark]
        public void AllocateLargeObjects()
        {
            byte[] largeArray = new byte[largeObjectSize];
            largeObjects!.Add(largeArray);
            GC.Collect();
        }
    }
}
