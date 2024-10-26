using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class MultiThreadedWorkload
    {
        private List<byte[]> _data = new List<byte[]>();

        [Benchmark]
        public void AllocateObjects()
        {
            Parallel.For(0, short.MaxValue, i =>
            {
                lock (_data)
                {
                    _data.Add(new byte[1_024]);
                }
            });
        }

        [Benchmark]
        public void ProcessData()
        {
            int sum = 0;
            Parallel.For(0, _data.Count, i =>
            {
                lock (_data)
                {
                    sum += _data[i][0];
                }
            });
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _data.Clear();
        }
    }
}
