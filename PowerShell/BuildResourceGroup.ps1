#Build Resource Group From Scratch

Login-AzureRmAccount

$resourceGroup = "MyResourceGroup"

Get-AzureRmResourceGroup -Name $resourceGroup -ev notPresent -ea 0

if ($notPresent)
{
    New-AzureRmResourceGroup -Name $resourceGroup -Location "UK SOUTH"
}
else
{
    write-output "ResourceGroup exist"
}

