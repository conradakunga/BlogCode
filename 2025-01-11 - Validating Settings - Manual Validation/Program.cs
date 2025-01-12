using System.Text.RegularExpressions;
using OptionsVerification;

var builder = WebApplication.CreateBuilder(args);

var settings = new ApplicationOptions();
builder.Configuration.GetSection(nameof(ApplicationOptions)).Bind(settings);

// Check API Key is present
if (string.IsNullOrWhiteSpace(settings.APIKey))
    throw new ApplicationException("API key is missing.");
// Check API Key is composed of characters
var regex = new Regex("^[A-Z]{10}$");
if (!regex.IsMatch(settings.APIKey))
    throw new ApplicationException("API key is invalid.");
// Check the retry count is between 1 and 5
if (settings.RetryCount is < 0 or > 5)
    throw new ApplicationException("Retry count is invalid.");
// Check the Requests per minute are more than 3 and less than 1000
if (settings.RequestsPerMinute is < 3 or > 1000)
    throw new ApplicationException("Requests per minute is invalid.");
// Check that the requests per minute do not exceed requests per day
if (settings.RequestsPerMinute > settings.RequestsPerDay)
    throw new ApplicationException("Requests per day is invalid.");

builder.Services.AddOptions<ApplicationOptions>();

var app = builder.Build();

app.MapGet("/Hello", () => "Hello")
    .WithName("Hello");

app.Run();