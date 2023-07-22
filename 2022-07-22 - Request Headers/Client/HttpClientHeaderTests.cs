using FluentAssertions;

namespace Headers;

public class HttpClientHeaderTests
{
    [Fact]
    public void Header_Is_Added_Correctly()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("test-header", "foo");
        client.DefaultRequestHeaders.ToString().Should().StartWith("test-header: foo");
    }

    [Fact]
    public void RequestID_Header_Is_Added_Correctly()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("x-request-id", "foo");
        client.DefaultRequestHeaders.ToString().Should().StartWith("x-request-id: foo");
    }
}