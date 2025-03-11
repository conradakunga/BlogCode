using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapPost("/Update/v1", async (SqlConnection cn) =>
{
    // setup our update queries
    const string firstUpdate = "UPDATE Spies SET Name = 'James Perceval Bond' WHERE SpyID = 1";
    const string secondUpdate = "UPDATE Spies SET Name = 'Eve Janet MoneyPenny' WHERE SpyID = 2";
    const string thirdUpdate = "UPDATE Spies SET Name = 'Vesper Leonora Lynd' WHERE SpyID = 3";

    // Execute our queries
    var firstQuery = cn.ExecuteAsync(firstUpdate);
    var secondQuery = cn.ExecuteAsync(secondUpdate);
    var thirdQuery = cn.ExecuteAsync(thirdUpdate);

    await Task.WhenAll(firstQuery, secondQuery, thirdQuery);

    // Return ok
    return Results.Ok();
});

app.MapPost("/Update/v2", async () =>
{
    // setup our update queries
    const string firstUpdate = "UPDATE Spies SET Name = 'James Perceval Bond' WHERE SpyID = 1";
    const string secondUpdate = "UPDATE Spies SET Name = 'Eve Janet MoneyPenny' WHERE SpyID = 2";
    const string thirdUpdate = "UPDATE Spies SET Name = 'Vesper Leonora Lynd' WHERE SpyID = 3";

    // Execute our queries, with a new connection for each
    var firstQuery = new SqlConnection(connectionString).ExecuteAsync(firstUpdate);
    var secondQuery = new SqlConnection(connectionString).ExecuteAsync(secondUpdate);
    var thirdQuery = new SqlConnection(connectionString).ExecuteAsync(thirdUpdate);

    await Task.WhenAll(firstQuery, secondQuery, thirdQuery);

    // Return ok
    return Results.Ok();
});


app.Run();