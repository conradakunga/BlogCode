using Dapper;
using Microsoft.Data.SqlClient;

var cn = new SqlConnection("Data Source=localhost;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=True");
var result = cn.QuerySingle<Result>("SELECT GETDATE() as Value");

Console.WriteLine(result.Value);