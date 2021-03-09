using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ListChecks
{
    public class Program
    {
        [SimpleJob(RuntimeMoniker.NetCoreApp31)]
        [RPlotExporter]
        public class CheckLenghs
        {
            List<int> dataList;
            [GlobalSetup]
            public void Setup()
            {
                dataList = Enumerable.Range(0, 100).ToList();
            }
            [Benchmark]
            public bool ListByCountProperty() => dataList.Count > 0;
            [Benchmark]
            public bool ListByCountLinq() => dataList.Count() > 0;
            [Benchmark]
            public bool ListByAnyLinq() => dataList.Any();
        }
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}

