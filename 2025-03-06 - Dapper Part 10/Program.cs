using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=.;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/Delay/v1", async (SqlConnection cn) =>
{
    var result = await cn.QueryAsync<Spy>("[Spies.GetAllWithDelay]");

    return result;
});

app.MapGet("/Delay/v2", async (SqlConnection cn, CancellationToken token) =>
{
    // Create a command definition object, passing our cancellation token
    var command = new CommandDefinition("[Spies.GetAllWithDelay]", cancellationToken: token);
    // Execute the command
    var result = await cn.QueryAsync<Spy>(command);

    return result;
});

app.Run();