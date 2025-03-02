using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/Info/v1", async (SqlConnection cn) =>
{
    const string spyCount = "SELECT Count(1) FROM Spies";
    const string allAgencies = "SELECT * FROM Agencies";
    const string allSpies = "SELECT TOP 5 * FROM Spies";

    var spies = await cn.QueryAsync<Spy>(allSpies);
    var agencies = await cn.QueryAsync<Agency>(allAgencies);
    var count = await cn.QuerySingleAsync<int>(spyCount);

    return Results.Ok(new { count, agencies, spies });
});

app.MapGet("/Info/v2", async (SqlConnection cn) =>
{
    const string query = """
                         SELECT Count(1) FROM Spies
                         SELECT * FROM Agencies
                         SELECT TOP 5 * FROM Spies
                         """;
    List<Spy> spies;
    List<Agency> agencies;
    int count;
    await using (var results = await cn.QueryMultipleAsync(query))
    {
        // Capture the count
        count = await results.ReadSingleAsync<int>();
        // Capture the agencies
        agencies = (await results.ReadAsync<Agency>()).ToList();
        // Capture the spies
        spies = (await results.ReadAsync<Spy>()).ToList();
    }

    return Results.Ok(new { count, agencies, spies });
});

app.Run();