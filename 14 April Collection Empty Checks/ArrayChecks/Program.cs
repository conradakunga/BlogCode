using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ArrayChecks
{
    public class Program
    {
        [SimpleJob(RuntimeMoniker.NetCoreApp31)]
        [RPlotExporter]
        public class CheckLenghs
        {
            int[] dataArray;
            [GlobalSetup]
            public void Setup()
            {
                dataArray = Enumerable.Range(0, 100).ToArray();
            }
            [Benchmark]
            public bool ArrayByLengthProperty() => dataArray.Length > 0;
            [Benchmark]
            public bool ArrayByCountLinq() => dataArray.Count() > 0;
            [Benchmark]
            public bool ArrayByAnyLinq() => dataArray.Any();

        }
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
