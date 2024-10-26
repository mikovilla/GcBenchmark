using BenchmarkDotNet.Attributes;
using GCB.Utility.Memory;

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
                i.PauseAfter(nthOperation: 4096, pauseTimeInMilliseconds: 1);
            }
        }

        [Benchmark]
        public void ProcessData()
        {
            int sum = 0;
            for (int i = 0; i < _data.Count; i++)
            {
                sum += _data[i][0];
                i.PauseAfter(nthOperation: 4096, pauseTimeInMilliseconds: 1);
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            Pressure.DecreaseByThreadSleep(1);
            _data.Clear();
        }
    }
}
