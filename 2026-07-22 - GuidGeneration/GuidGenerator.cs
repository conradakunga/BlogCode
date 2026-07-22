using BenchmarkDotNet.Attributes;

namespace GuidGeneration;

[Config(typeof(BenchmarkConfig))]
public class GuidGenerator
{
    [Benchmark]
    public Guid Generate() => Guid.NewGuid();
}