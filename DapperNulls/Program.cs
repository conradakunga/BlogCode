using Dapper;
using Microsoft.Data.SqlClient;

using (var cn = new SqlConnection("data source=;;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true"))
{
    var date = cn.QuerySingle<DateTime>("SELECT GetDate()");
    Console.WriteLine(date);
}

using (var cn = new SqlConnection("data source=;;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true"))
{
    var date = cn.QuerySingle<DateTime>("SELECT NULL");
    Console.WriteLine(date);
}

using (var cn = new SqlConnection("data source=;;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true"))
{
    var date = cn.QuerySingleOrDefault<DateTime>("SELECT NULL");
    Console.WriteLine(date);
}

using (var cn = new SqlConnection("data source=;;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=true"))
{
    var date = cn.QuerySingle<DateTime?>("SELECT NULL");
    if (date.HasValue)
        Console.WriteLine(date);
    else
        Console.WriteLine("A NULL was returned");
}