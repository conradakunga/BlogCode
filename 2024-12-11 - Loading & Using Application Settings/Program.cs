using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

// Create a constant for the HttpClient name
const string httpClientName = "GitHubClient";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Register the binding of the APISettings object to the relevant section in appSettings.json
builder.Services.Configure<APISettings>(builder.Configuration.GetSection(nameof(APISettings)));

// Register the HttpClient
builder.Services.AddHttpClient(httpClientName, (provider, client) =>
{
    // Get a logger from the DI contaoner
    var logger = provider.GetRequiredService<ILogger<APISettings>>();
    // Log some infromation
    logger.LogInformation("Call to retrieve HttpClient");
    // Get the settings from the DI container
    var settings = provider.GetRequiredService<IOptions<APISettings>>().Value;
    logger.LogInformation("The configured URL is {URL}", settings.GitHubAPI);
    logger.LogInformation("The configured user agent is {UserAgent}", settings.UserAgent);
    // Set the base address with the configured settings
    client.BaseAddress = new Uri(settings.GitHubAPI);
    // Set the user agent to be added by default to all requests
    client.DefaultRequestHeaders.Add("User-Agent", settings.UserAgent);
});

//Fetch the API settings and bind them to a custom object
var apiSettings = new APISettings();
builder.Configuration.GetSection(nameof(APISettings)).Bind(apiSettings);

// Build the web application
var app = builder.Build();

// Use the app's logger to print information
app.Logger.LogInformation("The configured API URL is {URL}", apiSettings.GitHubAPI);
app.Logger.LogInformation("The configured User Agent is {UserAgent}", apiSettings.UserAgent);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/Info/{username}", async (string username, IHttpClientFactory factory) =>
    {
        // Retrieve our client from the DI container
        var client = factory.CreateClient(httpClientName);
        // Deserialize the returned user
        var gitHubUser = await client.GetFromJsonAsync<GitHubUser>($"/users/{username}");
        return Results.Ok(gitHubUser);
    })
    .WithName("GetUserInfo");

app.Run();

public sealed record GitHubUser
{
    [JsonPropertyName("avatar_url")] public required string Avatar { get; init; }
    [JsonPropertyName("name")] public required string Name { get; init; }
    [JsonPropertyName("company")] public required string Company { get; init; }
    [JsonPropertyName("blog")] public required string Blog { get; init; }
    [JsonPropertyName("location")] public required string Location { get; init; }
    [JsonPropertyName("bio")] public required string Bio { get; init; }
    [JsonPropertyName("created_at")] public required string DateCreated { get; init; }
}

public sealed record APISettings
{
    public string GitHubAPI { get; set; } = "";
    public string UserAgent { get; set; } = "";
}