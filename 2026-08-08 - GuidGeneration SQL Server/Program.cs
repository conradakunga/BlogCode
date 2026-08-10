using Dapper;
using Npgsql;

const string connectionString = "host=localhost;username=myuser;password=mypassword;database=things";
var things = new List<Thing>();
for (var i = 0; i < 10; i++)
{
    things.Add(new Thing(Guid.CreateVersion7(), $"{i}"));
}

foreach (var thing in things)
{
    Console.WriteLine($"ID: {thing.ID}; {thing.Caption}");

    using (var cn = new NpgsqlConnection(connectionString))
    {
        cn.Execute("insert into things(id,caption) values (@ID,@Caption)", thing);
    }
}