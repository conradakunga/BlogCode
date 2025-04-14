using Elastic.Channels;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using FluentAssertions;
using Serilog;
using Xunit.Abstractions;

namespace Calculator.Tests;

public class CalculatorTests
{
    public CalculatorTests(ITestOutputHelper testOutputHelper)
    {
        Log.Logger = new LoggerConfiguration()
            // Add the machine name to the logged properties
            .Enrich.WithMachineName()
            // Add the logged-in username to the logged properties
            .Enrich.WithEnvironmentUserName()
            // Add a custom property
            .Enrich.WithProperty("Codename", "Bond")
            // Wire in the test output helper
            .WriteTo.TestOutput(testOutputHelper)
            // Wire in seq
            .WriteTo.Seq("http://localhost:5341")
            // Wire in ElasticSearch
            .WriteTo.Elasticsearch([new Uri("http://localhost:9200")], opts =>
            {
                opts.DataStream = new DataStreamName("logs", "Test", "Calculator");
                opts.BootstrapMethod = BootstrapMethod.Silent;
                opts.ConfigureChannel = channelOpts => { channelOpts.BufferOptions = new BufferOptions(); };
            }, transport =>
            {
                // transport.Authentication(new BasicAuthentication(username, password)); // Basic Auth
                // transport.Authentication(new ApiKey(base64EncodedApiKey)); // ApiKey
            })
            .CreateLogger();
    }

    [Theory]
    [ClassData(typeof(AdditionTestData))]
    public void Integer_Addition_Is_Correct(int first, int second, int result)
    {
        var calc = new Calculator<int>();
        Log.Information("Adding {First} + {Second} for integer", first, second);
        calc.Add(first, second).Should().Be(result);
    }

    [Theory]
    [ClassData(typeof(AdditionTestData))]
    public void Decimal_Addition_Is_Correct(decimal first, decimal second, decimal result)
    {
        var calc = new Calculator<decimal>();
        Log.Information("Adding {First} + {Second} for decimal", first, second);
        calc.Add(first, second).Should().Be(result);
    }
}