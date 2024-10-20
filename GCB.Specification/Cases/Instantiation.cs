using BenchmarkDotNet.Attributes;
using GCB.Utility;

namespace GCB.Specification.Cases
{
    [MemoryDiagnoser]
    public class Instantiation
    {
        [Benchmark]
        public void InstantiateObject()
        {
            for (int i = 0; i < short.MaxValue; i++)
            {
                var test = new Test("hello", "world");
                var test2 = new Test("h3110", "w0r1d");
                var test3 = new Test("HELLO", "WORLD");
                var test4 = new Test("Hello", "World");
                test.ConcatArgs();
                test2.ConcatArgs();
                test3.ConcatArgs();
                test4.ConcatArgs();
            }
            GC.Collect();
        }
    }

    public class Test(string a, string b)
    {
        public string ConcatArgs() => a + b;
    }
}
