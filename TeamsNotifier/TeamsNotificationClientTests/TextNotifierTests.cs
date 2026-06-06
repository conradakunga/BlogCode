using AwesomeAssertions;
using TeamsNotificationClient;

namespace TeamsNotificationClientTests;

public class TextNotifierTests
{
    [Fact]
    public async Task Teams_Client_Should_Post_With_Valid_WebHook()
    {
        var client = new TextNotifier(Constants.ValidTeamsWebHook);
        var result = await client.Post("WANTAM");
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Teams_Client_Should_Fail_With_InValid_WebHook()
    {
        var client = new TextNotifier(Constants.InValidTeamsWebHook);
        var result = await client.Post("WANTAM");
        result.Should().BeFalse();
    }
}