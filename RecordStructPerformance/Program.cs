using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;

BenchmarkRunner.Run<Test>();

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class Test
{
    [Benchmark]
    public void TestRecordStruct()
    {
        var test = new AnimalRecordStruct("Cat", 4);
        Console.WriteLine(test.Name);
    }
    [Benchmark]
    public void TestReadonlyRecordStruct()
    {
        var test = new AnimalRecordReadOnlyStruct("Cat", 4);
        Console.WriteLine(test.Name);
    }
    [Benchmark]
    public void TestRecord()
    {
        var test = new AnimalRecordClass("Cat", 4);
        Console.WriteLine(test.Name);
    }


}
public record struct AnimalRecordStruct(string Name, int Legs);
public readonly record struct AnimalRecordReadOnlyStruct(string Name, int Legs);
public record class AnimalRecordClass(string Name, int Legs);