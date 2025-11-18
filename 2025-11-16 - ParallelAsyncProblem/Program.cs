using Dapper;
using Microsoft.Data.SqlClient;

string[] collection = ["One", "Two", "Three"];

await Parallel.ForEachAsync(collection, async (element, _) =>
{
    await using var cn = new SqlConnection("......");
    await cn.ExecuteAsync("Query", new { ID = element }
    );
});