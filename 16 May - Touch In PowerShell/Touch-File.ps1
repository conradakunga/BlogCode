function Touch-File(){
    $fileName = $args[0]
    # Check of the file exists
    if(!(Test-Path $fileName))
    {
        # It does not exist. Create it
        New-Item -ItemType File -Name $fileName
    }
    else
    {
        #It exists. Update the timestamp
        (Get-ChildItem $fileName).LastWriteTime = Get-Date
    }
}

### Create an alias for touch

# Check if the alias exists
if(-not(Test-Path -Path Alias:Touch))
{
    New-Alias -Name Touch Touch-File -Force
}
