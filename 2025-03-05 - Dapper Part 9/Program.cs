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

app.MapGet("/Info/{spyID:int}", async (SqlConnection cn, int spyID) =>
{
    const string query = "SELECT * FROM Spies WHERE SpyID = @SpyID";
    var result = await cn.QuerySingleAsync<Spy>(query, new { SpyID = spyID });

    return result;
});

app.MapGet("/Info/", async (SqlConnection cn) =>
{
    const string query = "SELECT TOP 5 *  FROM Spies";
    var result = await cn.QueryAsync(query);

    return result;
});



app.MapGet("/Info/Dynamic/{spyID:int}", async (SqlConnection cn, int spyID) =>
{
    const string query = "SELECT * FROM Spies WHERE SpyID = @SpyID";
    var result = await cn.QuerySingleAsync(query, new { SpyID = spyID });

    return result;
});

app.MapGet("/Info/Interact/{spyID:int}", async (SqlConnection cn, int spyID) =>
{
    const string query = "SELECT * FROM Spies WHERE SpyID = @SpyID";
    var result = await cn.QuerySingleAsync(query, new { SpyID = spyID });

    // Create an anonymous object
    var spy = new
    {
        result.SpyID,
        result.Name,
        result.DateOfBirth,
        // This property does not exist
        result.ThisDoesNotExist
    };
    
    return spy;
});


app.Run();