using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a SQL Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/Purge", async (SqlConnection cn) =>
{
    const string query = """
                         DELETE FROM
                                dbo.Spies
                         WHERE
                             Spies.Active = 0;;
                         """;
    await cn.ExecuteAsync(query);
});

app.MapGet("/PurgeByStatus/{status:bool}", async (SqlConnection cn, bool status) =>
{
    const string query = """
                         DELETE FROM
                                dbo.Spies
                         WHERE
                             Spies.Active = @Status
                         """;

    var param = new DynamicParameters();
    param.Add("Status", status);

    await cn.ExecuteAsync(query, param);
});

app.MapGet("/PurgeByStatusProcedure/{status:bool}", async (SqlConnection cn, bool status) =>
{
    var param = new DynamicParameters();
    param.Add("Status", status);

    await cn.ExecuteAsync("[Spies.PurgeByStatus]", param);
});

app.MapGet("/Admin", async (SqlConnection cn) =>
{
    const string query = """
                         CREATE TABLE Temp
                         (
                             ID   TINYINT       PRIMARY KEY,
                             Name NVARCHAR(100) NOT NULL
                                 UNIQUE
                         );
                         """;
    await cn.ExecuteAsync(query);
});

app.Run();