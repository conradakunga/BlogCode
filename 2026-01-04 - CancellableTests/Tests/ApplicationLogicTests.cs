using AwesomeAssertions;
using Logic;

namespace Tests;

public class ApplicationLogicTests
{
    [Fact]
    public async Task ApplicationLogic_Returns_Expected_Result()
    {
        var sut = new ApplicationLogic();
        var result = await sut.LongRunningOperation(CancellationToken.None);
        result.Should().Be("Success");
    }

    [Fact]
    public async Task ApplicationLogic_Returns_Expected_Result_With_Static_Cancel_Support()
    {
        var sut = new ApplicationLogic();
        var result = await sut.LongRunningOperation(TestContext.Current.CancellationToken);
        result.Should().Be("Success");
    }
}