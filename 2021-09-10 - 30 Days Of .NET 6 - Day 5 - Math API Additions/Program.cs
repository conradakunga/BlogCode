using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SineCosine
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
        }
    }
    public class Test
    {
        const double angle = 35;
        [Benchmark]
        public (double, double) GetIndividually()
        {
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);
            return (sin, cos);
        }
         [Benchmark]
        public (double, double) GetSimultaneously()
        {
            var result = Math.SinCos(angle);
            return (result.Sin, result.Cos);
        }
    }
}
