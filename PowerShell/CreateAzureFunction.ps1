#New-AzureRmResource -Location "West US" -Properties @{"test"="test"} -ResourceName "TestSite06" -ResourceType "microsoft.web/functions" -ResourceGroupName "ResourceGroup11" -Force



Function DeployTimerTriggerFunction
{
    param (
        [string]$ResourceGroupName,
        [string]$SiteName,
        [string]$FunctionName, 
        [string]$CodeFile, 
        [string]$TestData
    )


    $FileContent = "$(Get-Content -Path $CodeFile -Raw)"

    $props = @{
        config = @{
            bindings = @(
                @{
                    type = "httpTrigger"
                    direction = "in"
                    webHookType = ""
                    name = "req"
                }
                @{
                    type = "http"
                    direction = "out"
                    name = "res"
                }
            )
        }
        files = @{
            "index.js" = $FileContent
        }
        test_data = $TestData
    }

    New-AzureRmResource -ResourceGroupName $ResourceGroupName -ResourceType Microsoft.Web/sites/functions -ResourceName $SiteName/$FunctionName -PropertyObject $props -ApiVersion 2015-08-01 -Force
}