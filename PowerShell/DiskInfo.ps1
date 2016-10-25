<#
.Synopsis
.Description
.Parameter
.Example
#>
function Get-DiskInfo {
    [CmdletBinding()]
    param(
        [string]$computerName='localhost',
        [Parameter(Mandatory=$True)]
        $drive='c:'
    )

    Get-WmiObject -ComputerName $computerName -class win32_logicaldisk -Filter "DeviceID='$drive'"
}
