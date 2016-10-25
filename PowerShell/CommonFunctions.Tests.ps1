. $PSScriptRoot\CommonFunctions.ps1


For([int]$i = 1; $i -le 16; $i++)
{
    Write-ToHost "Hello world" $i
}

#Write-ToHost "ERROR out of bounds " 20

Write-ToHost "Specified Color Magenta!" 14

Write-ToHost "Print in dark cyan" -foregroundColor DarkCyan
