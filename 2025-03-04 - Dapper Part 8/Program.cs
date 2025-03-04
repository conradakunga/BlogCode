using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

const string connectionString = "data source=.;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

// Set the default timeout to 2 minutes
SqlMapper.Settings.CommandTimeout = TimeSpan.FromMinutes(2).Seconds;

var app = builder.Build();

app.MapGet("/Info/v1", async (SqlConnection cn) =>
{
    const string query = "SELECT TOP 10 * FROM Spies";
    var result = await cn.QueryAsync<Spy>(query);

    return result;
});

app.MapGet("/Info/v2", async (SqlConnection cn) =>
{
    const string query = "[Spies.GetAllWithDelay]";
    var result = await cn.QueryAsync<Spy>(query);

    return result;
});

app.MapGet("/Info/v3", async (SqlConnection cn) =>
{
    const string query = "[Spies.GetAllWithDelay]";
    var result = await cn.QueryAsync<Spy>(query, commandTimeout: 50);

    return result;
});

app.Run();