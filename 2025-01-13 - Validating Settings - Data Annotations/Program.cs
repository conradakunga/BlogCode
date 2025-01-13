var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<ApplicationOptions>()
    .Bind(builder.Configuration.GetSection(nameof(ApplicationOptions)))
    .ValidateDataAnnotations()
    .Validate(config =>
    {
        // Assert the requests per day are greater
        return config.RequestsPerDay > config.RequestsPerMinute;
    }, "Requests per day must be greater than or equal to requests per minute.")
    .ValidateOnStart();

builder.Services.AddOptionsWithValidateOnStart<ApplicationOptions>()
    .Bind(builder.Configuration.GetSection(nameof(ApplicationOptions)))
    .ValidateDataAnnotations()
    .Validate(config =>
    {
        // Assert the requests per day are greater
        return config.RequestsPerDay > config.RequestsPerMinute;
    }, "Requests per day must be greater than or equal to requests per minute.");

var app = builder.Build();

app.MapGet("/Hello", () => Results.Ok("Hello"));
app.Run();