using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);
// Configure global json handling
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.NumberHandling = JsonNumberHandling.WriteAsString;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
var app = builder.Build();

app.MapGet("/", () =>
    {
        var spy = new Spy("James Bond", "MI-6", 40, true);
        return Results.Ok(spy);
    }
);

app.MapGet("/Formatted", () =>
    {
        var spy = new Spy("James Bond", "MI-6", 40, true);
        // Override the global handling
        var options = new JsonSerializerOptions
        {
            // Output numbers as strings
            NumberHandling = JsonNumberHandling.Strict,
            // Use lower case, kebab case
            PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper,
        };
        return Results.Json(spy, options);
    }
);

app.Run();