using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class SingleThreadedWorkload
    {
        private List<byte[]> _data = new List<byte[]>();

        [Benchmark]
        public void AllocateObjects()
        {
            for (int i = 0; i < short.MaxValue; i++)
            {
                _data.Add(new byte[1_024]);
            }
        }

        [Benchmark]
        public void ProcessData()
        {
            int sum = 0;
            for (int i = 0; i < _data.Count; i++)
            {
                sum += _data[i][0];
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _data.Clear();
        }
    }
}
