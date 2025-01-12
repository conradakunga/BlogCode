using FluentValidation;

namespace OptionsVerification;

public class ApplicationOptionsValidator : AbstractValidator<ApplicationOptions>
{
    public ApplicationOptionsValidator()
    {
        RuleFor(x => x.APIKey)
            .NotNull().NotEmpty() // Required, and not default
            .Matches("^[A-Z]{10}$");

        RuleFor(x => x.RetryCount)
            .NotNull().NotEmpty() // Required, and not default
            .InclusiveBetween(1, 5);

        RuleFor(x => x.RequestsPerMinute)
            .NotNull().NotEmpty() // Required, and not default
            .LessThanOrEqualTo(3)
            .LessThanOrEqualTo(x => x.RequestsPerDay);

        RuleFor(x => x.RequestsPerDay)
            .NotNull().NotEmpty() // Required, and not default
            .LessThan(1_000);
    }
}