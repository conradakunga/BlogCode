using Dapper;
using Npgsql;

using (var cn = new NpgsqlConnection(
           "host=localhost;username=myuser;password=mypassword;database=postgres;Timezone=America/Lima"))
{
    // Get the timezone for Lima, Peru	
    var limaTimeZome = TimeZoneInfo.FindSystemTimeZoneById("America/Lima");
    // Fetch date and time from server
    var dateTime = cn.QuerySingle<TimeOnly>("SELECT now()::time");
    // Print what we get from the server
    Console.WriteLine($"Time on database server: {dateTime}");
    // Print the actual time in Lima
    Console.WriteLine(
        $"Time in Lima: {TimeOnly.FromDateTime(TimeZoneInfo.ConvertTime(DateTime.UtcNow, limaTimeZome))}");
}


using (var cn = new NpgsqlConnection(
           "host=localhost;username=myuser;password=mypassword;database=postgres;Timezone=America/Lima"))
{
    // Get the timezone for Lima, Peru	
    var limaTimeZome = TimeZoneInfo.FindSystemTimeZoneById("America/Lima");
    // Fetch date and time from server
    var dateTime = cn.QuerySingle<DateTime>("SELECT now()");
    // Print what we get from the server
    Console.WriteLine(
        $"Time on database server: {TimeOnly.FromDateTime(TimeZoneInfo.ConvertTime(dateTime, limaTimeZome))}");
    // Print the actual time in Lima
    Console.WriteLine(
        $"Time in Lima: {TimeOnly.FromDateTime(TimeZoneInfo.ConvertTime(DateTime.UtcNow, limaTimeZome))}");
}