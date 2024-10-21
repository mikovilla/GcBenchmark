using BenchmarkDotNet.Attributes;
using GCB.Utility.Memory;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class LowMemoryAllocation
    {
        private List<byte[]> _data = new List<byte[]>();

        [Benchmark]
        public void AllocateMemory()
        {
            for (int i = 0; i < Int16.MaxValue; i++)
            {
                _data.Add(new byte[2]);
                i.PauseAfter(nthOperation: 16384, pauseTimeInMilliseconds: 1);
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
