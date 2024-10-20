using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class LowMemoryAllocation
    {
        private List<byte[]> _data = new List<byte[]>();

        [Benchmark]
        public void AllocateMemory()
        {
            for (int i = 0; i < 10_000; i++)
            {
                _data.Add(new byte[1_000]); // Allocate 1 KB arrays
            }
        }

        [Benchmark]
        public void ProcessData()
        {
            int sum = 0;
            for (int i = 0; i < _data.Count; i++)
            {
                sum += _data[i][0]; // Simulate some processing
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _data.Clear();
        }
    }
}
