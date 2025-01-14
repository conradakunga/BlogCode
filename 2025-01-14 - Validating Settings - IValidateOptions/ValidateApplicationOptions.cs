using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;

namespace OptionsVerification;

public sealed class ValidateApplicationOptions : IValidateOptions<ApplicationOptions>
{
    public ValidateOptionsResult Validate(string? name, ApplicationOptions options)
    {
        // String builder to store errors
        var errors = new StringBuilder();

        // Regex to validate API Key
        var reg = new Regex("^[A-Z]{10}$");
        if (!reg.IsMatch(options.APIKey))
        {
            errors.AppendLine($"{options.APIKey} doesn't match RegEx requirement");
        }

        if (options.RetryCount is < 1 or > 5)
        {
            errors.AppendLine($"{options.RetryCount} must be between 1 and 5");
        }

        if (options.RequestsPerMinute > 1_000)
        {
            errors.AppendLine($"{options.RequestsPerMinute} must be less than 1000");
        }

        if (options.RequestsPerMinute > options.RequestsPerDay)
        {
            errors.AppendLine($"{options.RequestsPerMinute} cannot be greater than {options.RequestsPerDay}");
        }

        return errors.Length > 0 ? ValidateOptionsResult.Fail(errors.ToString()) : ValidateOptionsResult.Success;
    }
}