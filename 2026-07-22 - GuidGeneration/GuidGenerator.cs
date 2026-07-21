using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace GuidGeneration;

[Config(typeof(BenchmarkConfig))]
public class GuidGenerator
{
    [Benchmark]
    public Guid Generate() => Guid.NewGuid();
}