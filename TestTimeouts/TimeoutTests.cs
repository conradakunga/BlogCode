namespace TestTimeouts;

public class TimeoutTests
{
    [Fact(Timeout = 10_000)]
    public async Task SampleTest()
    {
        await Task.Delay(TimeSpan.FromSeconds(15));
        Assert.True(true);
    }
}