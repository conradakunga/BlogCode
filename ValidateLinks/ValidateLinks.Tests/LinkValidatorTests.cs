using ValidateLinks.Core;
using FluentAssertions;

namespace ValidateLinks.Tests;

public class LinkValidatorTests
{
    [Theory]
    [InlineData("https://www.cnn.com", true)]
    [InlineData("https://www.bbc.com", true)]
    [InlineData("https://www.microsoft.com", true)]
    [InlineData("https://www.aws.amazon.com", true)]
    [InlineData("https://www.facebook.com", true)]
    [InlineData("https://www.oracle.com", true)]
    [InlineData("https://www.fake.co.ke", false)]
    [InlineData("https://www.apple.com", true)]
    [InlineData("https://www.ibm.com", true)]
    public async Task Link_Validation_Code_Functions(string url, bool expected)
    {
        var validator = new LinkValidator();
        var result = await validator.ValidateAsync([url]);
        result.All(x => x.Success).Should().Be(expected);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public async Task Invalid_Urls_Are_Rejected(string? url)
    {
        var validator = new LinkValidator();
        var result = await Record.ExceptionAsync(() => validator.ValidateAsync([url]));
        result.Should().BeOfType<ArgumentException>();
    }
}