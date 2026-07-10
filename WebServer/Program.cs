var builder = WebApplication.CreateBuilder(args);
// Register the response compression services
builder.Services.AddResponseCompression();
var app = builder.Build();
// Turn on the middleware
app.UseResponseCompression();
// Register a route
app.MapGet("/Hello", () => "The quick brown fox jumped over the lazy dog");
// Start the application
app.Run();