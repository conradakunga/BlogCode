using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace GuidGeneration;

[SimpleJob(RuntimeMoniker.Net10_0)]
[SimpleJob(RuntimeMoniker.Net90, baseline: true)]
public class GuidGenerator
{
    [Benchmark]
    public Guid Generate() => Guid.NewGuid();
}