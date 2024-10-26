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
            }
            _data.Clear();
        }

        [Benchmark]
        public void AllocateObjectsInParallel()
        {
            Parallel.For(0, short.MaxValue, i =>
            {
                lock (_data)
                {
                    _data.Add(new byte[1_024]);
                }
            });
            _data.Clear();
        }
    }
}
