using AwesomeAssertions;
using Logic;

namespace Tests;

public class ApplicationLogicTestsSophisticated
{
    private readonly ITestContextAccessor _accessor;

    public ApplicationLogicTestsSophisticated(ITestContextAccessor accessor)
    {
        _accessor = accessor;
    }

    [Fact]
    public async Task ApplicationLogic_Returns_Expected_Result_With_Static_Cancel_Support()
    {
        var sut = new ApplicationLogic();
        var result = await sut.LongRunningOperation(_accessor.Current.CancellationToken);

        result.Should().Be("Success");
    }
}