using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";
var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sqlite connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/List", (SqlConnection cn, ILogger<Program> logger) =>
{
    const string query = """
                         SELECT
                             Spies.SpyID ID,
                             Spies.Name FullNames,
                             Spies.DateOfBirth BirthDate
                         FROM
                             dbo.Spies;
                         """;
    var spies = cn.Query<V1.Spy>(query).AsList();
    return Results.Ok(spies);
});

app.MapGet("/ActiveList", (SqlConnection cn, ILogger<Program> logger) =>
{
    const string query = """
                         SELECT
                             Spies.SpyID ID,
                             Spies.Name FullNames,
                             Spies.DateOfBirth BirthDate
                         FROM
                             dbo.Spies WHERE Active = @Active;
                         """;
    var param = new DynamicParameters();
    param.Add("Active", true);
    var spies = cn.Query<V2.Spy>(query, param).AsList();
    return Results.Ok(spies);
});

app.MapGet("/ActiveByHeight/{height:decimal}", (SqlConnection cn, ILogger<Program> logger, decimal height) =>
{
    const string query = """
                         SELECT
                             Spies.SpyID,
                             Spies.Name,
                             Spies.DateOfBirth,
                             Spies.Height,
                             Spies.Active
                         FROM
                             dbo.Spies WHERE Active = @Active AND Height>=@Height;
                         """;
    var spies = cn.Query<V1.Spy>(query, new { Active = true, Height = height }).AsList();
    return Results.Ok(spies);
});

app.MapGet("/ActiveListComputed", (SqlConnection cn, ILogger<Program> logger) =>
{
    const string query = """
                         SELECT
                             Spies.SpyID ID,
                             Spies.Name FullNames,
                             Spies.DateOfBirth BirthDate
                         FROM
                             dbo.Spies WHERE Active = @Active;
                         """;
    var param = new DynamicParameters();
    param.Add("Active", true);
    var spies = cn.Query<V3.Spy>(query, param).AsList();
    return Results.Ok(spies);
});

app.MapGet("/Spy/{id:int}", (SqlConnection cn, ILogger<Program> logger, int id) =>
{
    const string query = """
                         SELECT
                             Spies.SpyID ID,
                             Spies.Name FullNames,
                             Spies.DateOfBirth BirthDate
                         FROM
                             dbo.Spies WHERE SpyID = @ID;
                         """;
    var spies = cn.QuerySingleOrDefault(query, new { ID = id });
    if (spies != null)
        return Results.Ok(spies);
    return Results.NotFound();
});

app.MapGet("/ListByStatus/{status:bool}", (SqlConnection cn, ILogger<Program> logger, bool status) =>
{
    var spies = cn.Query<V1.Spy>("[Spies.GetByStatus]", new { Status = status }).AsList();
    return Results.Ok(spies);
});

app.MapGet("/ActiveSpyCount/", (SqlConnection cn, ILogger<Program> logger) =>
{
    var spyCount = cn.QuerySingle<int>("SELECT COUNT(1) FROM Spies WHERE Active=1");
    return Results.Ok(spyCount);
});

app.Run();