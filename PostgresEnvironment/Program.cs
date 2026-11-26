using Dapper;
using Npgsql;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();
    var app = builder.Build();

    app.MapGet("/", () =>
    {
        using (var cn = new NpgsqlConnection("host=localhost;username=myuser;password=mypassword;database=postgres"))
        {
            var serverTime = cn.QuerySingle<TimeOnly>("SELECT now()::time");
            var clientTime = TimeOnly.FromDateTime(DateTime.Now);
            Log.Information("Time on database server: {ServerTime}", serverTime);
            Log.Information("Time locally: {ClientTime}", clientTime);
            return Results.Ok(new { ServerTime = serverTime, ClientTime = clientTime });
        }
    });

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}