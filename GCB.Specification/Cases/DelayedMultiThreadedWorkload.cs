using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class DelayedMultiThreadedWorkload
    {
        private List<object> _temporaryObjects = new List<object>();

        [Benchmark]
        public void AllocateObjects()
        {
            for (int i = 0; i < 20_000; i++)
            {
                _temporaryObjects.Add(new byte[short.MaxValue]);
            }

            Thread.Sleep(2000);
            _temporaryObjects.Clear();
        }
    }
}
