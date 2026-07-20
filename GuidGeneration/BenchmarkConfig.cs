using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using BenchmarkDotNet.Toolchains.DotNetCli;

namespace GuidGeneration;

public sealed class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddJob(
            Job.Default
                .WithToolchain(
                    CsProjCoreToolchain.From(NetCoreAppSettings.NetCoreApp10_0))
                .WithId("net10")
                .AsBaseline());

        AddJob(
            Job.Default
                .WithToolchain(
                    CsProjCoreToolchain.From(
                        new NetCoreAppSettings(
                            targetFrameworkMoniker: "net11.0",
                            runtimeFrameworkVersion: null,
                            name: ".NET 11")))
                .WithId("net11"));
    }
}