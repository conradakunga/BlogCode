using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

// Configure Dapper to support DateOnly
SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
// Configure Dapper to support TimeOnly
SqlMapper.AddTypeHandler(new SqlTimeOnlyTypeHandler());

var app = builder.Build();

app.MapGet("/Info/v1", async (SqlConnection cn) =>
{
    const string query = """
                         SELECT
                         'CurrentDate' Name,
                         GETDATE()     DateAndTime;
                         """;
    var result = await cn.QuerySingleAsync<V1.DateInfo>(query);

    return result;
});

app.MapGet("/Info/v2", async (SqlConnection cn) =>
{
    const string query = """
                         SELECT
                         'CurrentDate' Name,
                         GETDATE()     Date;
                         """;
    var result = await cn.QuerySingleAsync<V2.DateInfo>(query);

    return result;
});

app.MapGet("/Info/v3", async (SqlConnection cn) =>
{
    const string query = """
                         SELECT
                         'CurrentDate' Name,
                         GETDATE()     DateAndTime;
                         """;
    var result = await cn.QuerySingleAsync<V3.DateInfo>(query);

    return result;
});

app.MapGet("/Info/v4", async (SqlConnection cn) =>
{
    const string query = """
                         SELECT
                         'CurrentTime' Name,
                         GETDATE()     Time;
                         """;
    var result = await cn.QuerySingleAsync<V4.DateInfo>(query);

    return result;
});
app.Run();