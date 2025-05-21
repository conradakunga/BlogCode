//

using Dapper;
using Microsoft.Data.SqlClient;

using (var cn = new SqlConnection("data source=localhost;trustservercertificate=true;uid=sa;pwd=YourStrongPassword123"))
{
    var result = cn.QuerySingle<string>("SELECT @@version");
    // Console.WriteLine(result);
}

// cn.Query("SELECT * FROM sys.dm_os_host_info");
// using (var cn = new SqlConnection("data source=localhost;trustservercertificate=true;uid=sa;pwd=YourStrongPassword123"))
// {
//     var result = cn.QuerySingle<HostInfo>("SELECT * FROM sys.dm_os_host_info");
//     Console.WriteLine($"Host platform: {result.host_platform}");
//     Console.WriteLine($"Host distribution: {result.host_distribution}");
//     Console.WriteLine($"Host release: {result.host_release}");
//     Console.WriteLine($"Host service pack level: {result.host_service_pack_level}");
//     Console.WriteLine($"Host SKU: {result.host_sku}");
//     Console.WriteLine($"Host OS Language Version: {result.os_language_version}");
//     Console.WriteLine($"Host architecture: {result.host_architecture}");
// }

using (var cn = new SqlConnection("data source=localhost;trustservercertificate=true;uid=sa;pwd=YourStrongPassword123"))
{
    var result = cn.QuerySingle("SELECT * FROM sys.dm_os_host_info");
    Console.WriteLine($"Host platform: {result.host_platform}");
    Console.WriteLine($"Host distribution: {result.host_distribution}");
    Console.WriteLine($"Host release: {result.host_release}");
    Console.WriteLine($"Host service pack level: {result.host_service_pack_level}");
    Console.WriteLine($"Host SKU: {result.host_sku}");
    Console.WriteLine($"Host OS Language Version: {result.os_language_version}");
    Console.WriteLine($"Host architecture: {result.host_architecture}");
}