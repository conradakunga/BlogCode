using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
// Authentication - the exact scheme does not matter for this example!
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://fake-provider.com";
        options.Audience = "api";
    });
builder.Services.AddAuthorization();
builder.Services.AddCarter();

var app = builder.Build();
// Create a default group and require authentication on it
app.MapGroup("")
    .RequireAuthorization()
    .MapCarter();

app.UseAuthentication();
app.UseAuthorization();

app.Run();