# Copies ssh key to another machine over ssh, defaulting to port 22
function ssh-copy-id([string]$userAtMachine, [string]$port = 22) {   
    # Get the generated public key
    $key = "$ENV:USERPROFILE" + "/.ssh/id_rsa.pub"
    # Verify that it exists
    if (!(Test-Path "$key")) {
        # Alert user
        Write-Error "ERROR: '$key' does not exist!"            
    }
    else {	
        # Copy the public key across
        & cat "$key" | ssh $userAtMachtoine -p $port "umask 077; test -d .ssh || mkdir .ssh ; cat >> .ssh/authorized_keys || exit 1"      
    }
}
function Touch-File() {
    $fileName = $args[0]
    # Check of the file exists
    if (-not(Test-Path $fileName)) {
        # It does not exist. Create it
        New-Item -ItemType File -Name $fileName
    }
    else {
        #It exists. Update the timestamp
        (Get-ChildItem $fileName).LastWriteTime = Get-Date
    }
}

### Create an alias for touch

# Check if the alias exists
if (-not(Test-Path -Path Alias:Touch)) {
    New-Alias -Name Touch Touch-File -Force
}

### Remove the curl alias

Remove-Item Alias:\Curl


Import-Module 'C:\tools\poshgit\dahlbyk-posh-git-9bda399\src\posh-git.psd1'

cd /Projects
