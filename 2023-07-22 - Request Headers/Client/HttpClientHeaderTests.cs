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

    [Fact]
    public void Doctored_RequestID_Header_Is_Added_Correctly()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.TryAddWithoutValidation("dummy", "dummy:dummy\r\nx-request-id: foo");
        var headers = client.DefaultRequestHeaders.ToString();
        headers.Should().StartWith("dummy", "dummy:dummy\r\nx-request-id: foo");
        // There should be 3 headers - dummy,x-request-id and the automatically added host
        headers.Split("\r\n").Length.Should().Be(3);
    }
}