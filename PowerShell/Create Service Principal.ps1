 
 # https://azure.microsoft.com/en-gb/documentation/articles/resource-group-authenticate-service-principal/

 Function Create-ServiceAccessToken
 Add-AzureRmAccount
 $app = New-AzureRmADApplication -DisplayName "FunctionsPocADApp" -HomePage "https://functionpocapp.scm.azurewebsites.net/" -IdentifierUris "https://functionpocapp.scm.azurewebsites.net/" -Password "P@55W0rd"
 New-AzureRmADServicePrincipal -ApplicationId $app.ApplicationId
 New-AzureRmRoleAssignment -RoleDefinitionName Reader -ServicePrincipalName $app.ApplicationId.Guid

<#
$app = 
    DisplayName             : FunctionsPocADApp
    ObjectId                : 86e77fb9-e0ad-48d7-8875-ab6873a9f353
    IdentifierUris          : {https://functionpocapp.scm.azurewebsites.net/}
    HomePage                : https://functionpocapp.scm.azurewebsites.net/
    Type                    : Application
    ApplicationId           : fc18e6e2-779b-4f5c-b030-e226449829cf
    AvailableToOtherTenants : False
    AppPermissions          : 
    ReplyUrls               : {}
#>

$creds = Get-Credential #user name ApplicationId and password used when creating the application
<#
$creds = 
    UserName                                                 Password
    --------                                                 --------
    fc18e6e2-779b-4f5c-b030-e226449829cf System.Security.SecureString
#>

$tenant = (Get-AzureRmSubscription -SubscriptionName "Visual Studio Enterprise").TenantId
<# $tenant = 6e8d4b37-b421-42d4-8893-db6bad863df9 #>


#Save access token and use it
Save-AzureRmProfile -Path $PSScriptRoot\profile\exampleSP.json

Select-AzureRmProfile -Path $PSScriptRoot\profile\exampleSP.json


Function Create-ServicePrincipal()
{
    $cert = New-SelfSignedCertificate -CertStoreLocation "cert:\CurrentUser\My" -Subject "CN=FunctionsPocApp" -KeySpec KeyExchange
    <# $cert =  

        Directory: Microsoft.PowerShell.Security\Certificate::CurrentUser\My


    Thumbprint                                Subject                                                                     
    ----------                                -------                                                                     
    03D3E3E8F24D93FB2437D10B5EB6679ED151D7CD  CN=FunctionsPocApp                                                          

    #>

    $keyValue = [System.Convert]::ToBase64String($cert.GetRawCertData())

    Add-AzureRmAccount

    $app = New-AzureRmADApplication -DisplayName "FunctionsPocApp" -HomePage "https://functionpocapp.scm.azurewebsites.net/" -IdentifierUris "https://functionpocapp.scm.azurewebsites.net/" -CertValue $keyValue -EndDate $cert.NotAfter -StartDate $cert.NotBefore
    <#
    DisplayName             : FunctionsPocApp
    ObjectId                : b24da774-0943-45eb-9a02-ecca4082e026
    IdentifierUris          : {https://functionpocapp.scm.azurewebsites.net/}
    HomePage                : https://functionpocapp.scm.azurewebsites.net/
    Type                    : Application
    ApplicationId           : 1c621069-a8a4-4279-a8ff-e0546b38500f
    AvailableToOtherTenants : False
    AppPermissions          : 
    ReplyUrls               : {}
    #>
    New-AzureRmADServicePrincipal -ApplicationId $app.ApplicationId
    <#
    DisplayName                    Type                           ObjectId                                                
    -----------                    ----                           --------                                                
    FunctionsPocApp                ServicePrincipal               12dbd58d-64ba-41c0-ab8f-575a9c3aad45  
    #>
    New-AzureRmRoleAssignment -RoleDefinitionName Reader -ServicePrincipalName $app.ApplicationId.Guid
    <#
    RoleAssignmentId   : /subscriptions/2a827f8d-c704-458c-9133-5020b3a10558/providers/Microsoft.Authorization/roleAssignm
                         ents/e9c449ed-3da0-4032-8fb4-9cb030378a06
    Scope              : /subscriptions/2a827f8d-c704-458c-9133-5020b3a10558
    DisplayName        : FunctionsPocApp
    SignInName         : 
    RoleDefinitionName : Reader
    RoleDefinitionId   : acdd72a7-3385-48ef-bd42-f606fba81ae7
    ObjectId           : 12dbd58d-64ba-41c0-ab8f-575a9c3aad45
    ObjectType         : ServicePrincipal
    #>


    $tenant = (Get-AzureRmSubscription -SubscriptionName "Visual Studio Enterprise").TenantId
    <# $tenant = 6e8d4b37-b421-42d4-8893-db6bad863df9 #>


    Add-AzureRmAccount -ServicePrincipal -CertificateThumbprint $cert.Thumbprint -ApplicationId $app.ApplicationId -TenantId $tenant
}

Function Export-SelfSignedCertificate() {

    $cert = (Get-ChildItem -Path Cert:\CurrentUser\My\03D3E3E8F24D93FB2437D10B5EB6679ED151D7CD)


}

