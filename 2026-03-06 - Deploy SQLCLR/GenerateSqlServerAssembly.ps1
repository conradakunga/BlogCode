# Set variables
$library = 'C:\Projects\innova-core\Innova.Database\bin\Release\Innova.Database.dll'
$dllName = 'Innova.Database'
$database = 'monkey'
$server = '10.211.55.2'
$username = 'sa'
$password = 'YourStrongPassword123'

# Get the MD5 hash of the build DLL
$hash = (Get-FileHash -Algorithm SHA512 "C:\Projects\innova-core\Innova.Database\bin\Release\Innova.Database.dll").Hash

# build the trusted assembly query
$query = "EXEC sys.sp_add_trusted_assembly
    @hash = 0x$hash,
    @description = N'$dllName'"

# Display the hash (in case you need to grab it
Write-Host "The hash is - $hash"
Invoke-Sqlcmd -ServerInstance $server -Database $database -Username $username -Password $password -Query $query -TrustServerCertificate

# Get the assembly binary
$bytes = [System.BitConverter]::ToString([System.IO.File]::ReadAllBytes($library)).Replace("-", "")

# drop assembly if exists in the datavase
# build the create assembly statement
$query = "CREATE ASSEMBLY [$dllName]
    FROM 0x$bytes"

Write-Host "The bytes are $($bytes.Substring(0, 5))"

Invoke-Sqlcmd -ServerInstance $server -Database $database -Username $username -Password $password -Query $query -TrustServerCertificate

Write-Host 'CREATION COMPLETE'
    
