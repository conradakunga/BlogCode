using Microsoft.Extensions.Options;
using OptionsVerification;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApplicationOptions>(
    builder.Configuration.GetSection(nameof(ApplicationOptions)));

builder.Services.AddSingleton<IValidateOptions<ApplicationOptions>, ValidateApplicationOptions>();

var app = builder.Build();

app.MapGet("/Hello", (IOptions<ApplicationOptions> options) =>
{
    var applicationOptions = options.Value;
    // Return result
    return Results.Ok("Hello!");
});

app.Run();