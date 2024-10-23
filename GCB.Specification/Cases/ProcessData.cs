using BenchmarkDotNet.Attributes;
using GCB.Utility.Extensions;
using GCB.Utility.Memory;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class ProcessData
    {
        private List<byte[]> _data = new List<byte[]>();

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < short.MaxValue; i++)
            {
                _data.Add(new byte[1_024]);
                i.PauseAfter(nthOperation: 8192, pauseTimeInMilliseconds: ((long)1_000).NsToMs());
            }
        }
        

        [Benchmark]
        public void ProcessDataInSingleThread()
        {
            int sum = 0;
            for (int i = 0; i < _data.Count; i++)
            {
                sum += _data[i][0];
            }
        }

        [Benchmark]
        public void ProcessDataInParallel()
        {
            int sum = 0;
            Parallel.For(0, _data.Count, i =>
            {
                sum += _data[i][0];
            });
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _data.Clear();
        }
    }
}
