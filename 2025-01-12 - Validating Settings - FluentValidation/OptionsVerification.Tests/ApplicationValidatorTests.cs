using FluentAssertions;

namespace OptionsVerification.Tests;

public class ApplicationValidatorTests
{
    [Fact]
    public void Valid_Settings_Are_Validated()
    {
        var settings = new ApplicationOptions
        {
            APIKey = "ABCDEFGHIJ",
            RetryCount = 3,
            RequestsPerMinute = 3,
            RequestsPerDay = 500
        };

        var validator = new ApplicationOptionsValidator();
        var result = validator.Validate(settings);
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Invalid_RetryCount_Is_Validated()
    {
        var settings = new ApplicationOptions
        {
            APIKey = "ABCDEFGHIJ",
            RetryCount = 5,
            RequestsPerMinute = 5,
            RequestsPerDay = 500
        };

        var validator = new ApplicationOptionsValidator();
        var result = validator.Validate(settings);
        // It should not be valid
        result.IsValid.Should().BeFalse();
        // Should have only one error
        result.Errors.Should().HaveCount(1);
        // Error message should be as follows
        result.Errors[0].ErrorMessage.Should().Be("'Requests Per Minute' must be less than or equal to '3'.");
    }
}