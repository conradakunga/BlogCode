using Carter;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();

var app = builder.Build();
app.MapCarter();

await app.RunAsync();