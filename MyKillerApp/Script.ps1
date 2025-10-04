# Get the path to the exe
$path = (Join-Path  (Split-Path -Parent $MyInvocation.MyCommand.Path) 'MyKillerApp.dll')

# Print path
Write-Host $path

# Load the type
Add-Type -Path $path

# Fetch the constant value
$ApplicationName = ([MyKillerApp.AppInfo]::ApplicationName)

# Print the value
Write-Host $ApplicationName