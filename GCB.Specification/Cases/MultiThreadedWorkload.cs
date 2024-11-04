using BenchmarkDotNet.Attributes;
using GCB.Utility.Constants;
using GCB.Utility.Memory;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class MultiThreadedWorkload
    {
        private List<byte[]> _data = new List<byte[]>();

        [Benchmark]
        public void AllocateObjects()
        {
            Parallel.For(0, ConstantConfig.NumberOfLoops, i =>
            {
                lock (_data)
                {
                    _data.Add(new byte[1_024]);
                    i.PauseAfter(nthOperation: ConstantConfig.PauseAfterNthOperation, pauseTimeInMilliseconds: ConstantConfig.PauseTime);
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
                    i.PauseAfter(nthOperation: ConstantConfig.PauseAfterNthOperation, pauseTimeInMilliseconds: ConstantConfig.PauseTime);
                }
            });
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            Pressure.DecreaseByThreadSleep(1);
            _data.Clear();
        }
    }
}
