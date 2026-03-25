using Dapper;
using Npgsql;

const string connection = "host=localhost;username=myuser;password=mypassword;database=spies";

await using (var cn = new NpgsqlConnection(connection))
{
    var result = await cn.QuerySingleAsync<string>("SELECT get_day_of_week(@Day)", new { Day = 3 });
    Console.WriteLine(result);
}

await using (var cn = new NpgsqlConnection(connection))
{
    var result = await cn.QuerySingleAsync<string>("SELECT get_day_of_week()");
    Console.WriteLine(result);
}