using Dapper;
using Microsoft.Data.SqlClient;

const string connection = "Data Source=;database=Spies;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=True;";

await using (var cn = new SqlConnection(connection))
{
    var result = await cn.QuerySingleAsync<string>("SELECT dbo.fn_GetDayOfWeek(@Day)", new { Day = 3 });
    Console.WriteLine(result);
}

await using (var cn = new SqlConnection(connection))
{
    var result = await cn.QuerySingleAsync<string>("SELECT dbo.fn_GetDayOfWeek(DEFAULT)");
    Console.WriteLine(result);
}