using BenchmarkDotNet.Environments;

namespace GCB.Specification.Domain
{
    public class ConfigurationItem
    {
        public Platform Platform { get; set; }
        public int Affinity { get; set; }
        public int WarmUpCount {  get; set; }
        public int IterationCount { get; set; }
    }
}
