using BenchmarkDotNet.Attributes;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class Instantiation
    {
        [Benchmark]
        public void InstantiateObject()
        {
            for (int i = 0; i < 10_000; i++)
            {
                var test = new Test();
            }
            GC.Collect();
        }
    }

    public class Test
    {

    }
}
