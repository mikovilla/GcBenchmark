using BenchmarkDotNet.Attributes;
using GCB.Utility.Extensions;
using GCB.Utility.Memory;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class ObjectAllocation
    {
        private List<byte[]> _data = new List<byte[]>();

        [Benchmark]
        public void AllocateObjects()
        {
            for (int i = 0; i < short.MaxValue; i++)
            {
                _data.Add(new byte[1_024]);
                i.PauseAfter(nthOperation: 16384, pauseTimeInMilliseconds: ((long)1).NsToMs());
            }
        }

        //[Benchmark]
        public void AllocateObjectsInParallel()
        {
            Parallel.For(0, short.MaxValue, i =>
            {
                _data.Add(new byte[1_024]);
            });
        }
    }
}
