using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString =
    "data source=localhost;uid=sa;password=YourStrongPassword123;database=things;trustservercertificate=true";
var things = new List<Thing>();
for (var i = 0; i < 10; i++)
{
    things.Add(new Thing(Guid.CreateVersion7(), $"{i}"));
    Thread.Sleep(TimeSpan.FromMilliseconds(1));
}

foreach (var thing in things)
{
    Console.WriteLine($"ID: {thing.ID}; {thing.Caption}");

    using (var cn = new SqlConnection(connectionString))
    {
        cn.Execute("insert into things(id,caption) values (@ID,@Caption)", thing);
    }
}