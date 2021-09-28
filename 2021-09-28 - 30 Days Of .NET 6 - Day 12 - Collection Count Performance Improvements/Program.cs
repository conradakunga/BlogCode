using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;

BenchmarkRunner.Run<Test>();
 
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class Test
{
    IEnumerable<int> enumerable;
    List<int> list;
    int[] array;

    public Test()
    {
        enumerable = Enumerable.Range(0, 25);
        list = enumerable.ToList();
        array = enumerable.ToArray();
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Enumerable")]
    public int GetEnumerableCountOld()
    {
        var count = enumerable.Count();
        return count;
    }

    [Benchmark]
    [BenchmarkCategory("Enumerable")]
    public int GetEnumerableCountNew()
    {
        enumerable.TryGetNonEnumeratedCount(out var count);
        return count;
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("List")]
    public int GetListCountOld()
    {
        var count = list.Count();
        return count;
    }

    [Benchmark]
    [BenchmarkCategory("List")]
    public int GetListCountNew()
    {
        list.TryGetNonEnumeratedCount(out var count);
        return count;
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Array")]
    public int GetArrayCountOld()
    {
        var count = array.Count();
        return count;
    }
    [Benchmark]
    [BenchmarkCategory("Array")]
    public int GetArrayCountNew()
    {
        array.TryGetNonEnumeratedCount(out var count);
        return count;
    }
}
