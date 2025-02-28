using System.Data;
using Dapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Data.SqlClient;

const string connectionString = "data source=10.211.55.2;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";
var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapGet("/GetSpyDetails/{id:int}", async (SqlConnection cn, ILogger<Program> logger, int id) =>
{
    var param = new DynamicParameters();
    // Add the input parameter - the ID
    param.Add("SpyID", id);
    // Add the output parameters
    param.Add("Name", dbType: DbType.String, size: 100, direction: ParameterDirection.Output);
    param.Add("DateOfBirth", dbType: DbType.DateTime, direction: ParameterDirection.Output);
    param.Add("Active", dbType: DbType.Boolean, direction: ParameterDirection.Output);
    // Execute the query
    await cn.ExecuteAsync("[Spies.GetInfo]", param);

    // Fetch the populated values
    var name = param.Get<string>("Name");
    var dateOfBirth = param.Get<DateTime>("DateOfBirth");
    var active = param.Get<bool>("Active");

    // Output as an anonymous type
    return new { Name = name, DateOfBirth = dateOfBirth, Active = active };
});

app.MapGet("/ServerDate", async (SqlConnection cn, ILogger<Program> logger) =>
{
    // Execute the function
    var result = await cn.QuerySingleAsync<DateTime>("SELECT GETDATE()");

    return result;
});

app.MapGet("/GetActiveSpyCountByStatus/{status:bool}", async (SqlConnection cn, ILogger<Program> logger, bool status) =>
{
    // Set up the parameters
    var param = new DynamicParameters();
    param.Add("Status", status);

    // Execute the function
    var result = await cn.QuerySingleAsync<int>("SELECT dbo.[Spies.GetActiveCountByStatus](@Status)", param);

    return result;
});

app.Run();