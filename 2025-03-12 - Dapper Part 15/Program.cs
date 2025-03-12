using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/List", async (SqlConnection cn) =>
{
    // create query
    const string query = """
                         SELECT * FROM Spies
                         WHERE Spies.SpyID IN @Spies
                         """;
    // define a collection to store the IDs
    int[] ids = [1, 2, 3, 4, 6, 10, 13, 56];

    // Fetch the spies
    var spies = await cn.QueryAsync<Spy>(query, new { Spies = ids});
    return spies;
});

app.Run();