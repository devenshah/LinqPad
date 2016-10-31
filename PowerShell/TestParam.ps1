Function Create-StorageAccountTable {
    param(
        [string]$subscriptionName,
        [string]$storageAccountName,
        [string]$storageAccountKey,
        [string]$tableName
    )

    #Add-AzureRmAccount

    Select-AzureSubscription -SubscriptionName $subscriptionName

    $Ctx = New-AzureStorageContext $storageAccountName -StorageAccountKey $storageAccountKey

    $table = Get-AzureStorageTable -Context $Ctx -Name $tableName -ErrorAction Stop | Out-Null
    if($table -eq $null)
    {
        Write-Output "Creating table"
        New-AzureStorageTable –Name $tableName –Context $Ctx        
    }
}

Create-StorageAccountTable (get-azuresubscription -Default).SubscriptionName -storageAccountName "contosoads99" -storageAccountKey "zq24EatMJsmsBa5+0IHAC8Ka5EbMUfZqKEG+5BXHhNyp2m2Br+5ySdRdsWJFoByDyFr4Lp9kTsz/t8TAhnGw/w==" -tableName "ThisTable"
    
    