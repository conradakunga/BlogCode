using FluentValidation;
using OptionsVerification;

var builder = WebApplication.CreateBuilder(args);

var settings = new ApplicationOptions();
builder.Configuration.GetSection(nameof(ApplicationOptions)).Bind(settings);

// Validate the settings
var validator = new ApplicationOptionsValidator();
// Throw exception on failure
//validator.ValidateAndThrow(settings);
var result = validator.Validate(settings);
if (!result.IsValid)
{
    // Print the errors
    foreach (var failure in result.Errors)
    {
        Console.WriteLine(failure.ErrorMessage);
    }
}

var app = builder.Build();

app.Run();