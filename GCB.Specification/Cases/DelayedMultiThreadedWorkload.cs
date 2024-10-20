using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class DelayedMultiThreadedWorkload
    {
        private List<object> _temporaryObjects = new List<object>();
        private object lockObject = new object();

        [Benchmark]
        public void AllocateObjectsInParallel()
        {
            Parallel.For(0, 1000, i =>
            {
                var obj = new object();
                lock (lockObject)
                {
                    _temporaryObjects.Add(obj);
                }

                if (i % 100 == 0)
                {
                    System.Threading.Thread.Sleep(10);
                }
            });
            _temporaryObjects.Clear();
            GC.Collect();
        }
    }
}
