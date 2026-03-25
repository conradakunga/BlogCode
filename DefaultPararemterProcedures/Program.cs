using Dapper;
using Microsoft.Data.SqlClient;

const string connection = "Data Source=;database=Spies;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=True;";

await using (var cn = new SqlConnection(connection))
{
    var result = await cn.QuerySingleAsync<string>("GetDayOfWeek", new { Day = 3 });
    Console.WriteLine(result);
}

await using (var cn = new SqlConnection(connection))
{
    var result = await cn.QuerySingleAsync<string>("GetDayOfWeek");
    Console.WriteLine(result);
}