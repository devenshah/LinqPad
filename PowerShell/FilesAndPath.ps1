Function Get-ModulePath() {
    Write-Host $PSScriptRoot\Message.txt
    Write-Host (Get-Content -Path $PSScriptRoot\Message.txt)
    Write-Host (Get-Content -Path $PSScriptRoot\Data\config.json)
}