using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString =
    "data source=localhost;uid=sa;password=YourStrongPassword123;database=things;trustservercertificate=true";
var thingCaptions = new List<string>();
for (var i = 0; i < 10; i++)
{
    thingCaptions.Add($"{i}");
}

foreach (var thing in thingCaptions)
{
    Console.WriteLine($"Caption: {thing}");

    using (var cn = new SqlConnection(connectionString))
    {
        cn.Execute("insert into things(caption) values (@Caption)", new { Caption = thing });
    }
}