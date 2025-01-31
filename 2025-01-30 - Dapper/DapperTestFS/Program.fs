type Result = { Value: System.DateTime }

open Microsoft.Data.SqlClient
open Dapper

let connectionString =
    "Data Source=localhost;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=True"

let cn = new SqlConnection(connectionString)
let result = cn.QuerySingle<Result>("SELECT GETDATE() as Value")

printfn $"%A{result.Value}"
