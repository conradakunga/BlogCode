var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/one", (HttpContext context) =>
{
    context.Response.Headers.Append("YourResponseHeaderNameHere", "YourValueHere");
    context.Response.Headers.Append("YourResponseHeaderNameHere", "YourOtherValueHere");

    return Results.Ok("Hello World!");
});

app.MapGet("/two", (HttpContext context) =>
{
    context.Response.Headers["YourResponseHeaderNameHere"] = "YourValueHere";
    context.Response.Headers["YourResponseHeaderNameHere"] = "YourOtherValueHere";

    return Results.Ok("Hello World!");
});

app.Run();