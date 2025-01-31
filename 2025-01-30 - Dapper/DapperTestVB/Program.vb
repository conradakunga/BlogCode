Imports System
Imports Dapper
Imports Microsoft.Data.SqlClient

Module Program
    Sub Main(args As String())
        dim cn = new SqlConnection("Data Source=localhost;uid=sa;pwd=YourStrongPassword123;TrustServerCertificate=True")
        dim result = cn.QuerySingle (Of Result)("SELECT GETDATE() as Value")

        Console.WriteLine(result.Value)
    End Sub
End Module
