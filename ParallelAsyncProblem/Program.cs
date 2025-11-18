using Dapper;
using Microsoft.Data.SqlClient;

string[] collection = ["One", "Two", "Three"];

Parallel.ForEach(collection, async (element) =>
{
    // Create database connection
    await using (var cn = new SqlConnection("......"))
    {
        // Execute query asynchronously
        await cn.ExecuteAsync("Query", new { ID = element });
    }
});

