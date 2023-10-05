$myPath = Split-Path $MyInvocation.MyCommand.Path -Parent

function Get-ConnectionString {
    $sqlUsername = ((Get-SECSecretValue -SecretId "SQLServerRDSSecret").SecretString | ConvertFrom-Json).username
    $sqlPassword = ((Get-SECSecretValue -SecretId "SQLServerRDSSecret").SecretString | ConvertFrom-Json).password
    [string] $SQLDatabaseEndpoint = [System.Environment]::GetEnvironmentVariable("SQLDatabaseEndpoint")

    [string] $SQLDatabaseEndpointTrimmed = $SQLDatabaseEndpoint.Replace(':1433','')
    [string] $retConnectionString = "Server=$SQLDatabaseEndpointTrimmed;Database=GadgetsOnlineDB;User Id=$sqlUsername;Password=$sqlPassword;"
    return $retConnectionString
}

function Update-ConnectionString-WebConfig {
    param (
        [string] $connectionStringParam,
        [string] $webConfigPathParam
    )
    
    $webConfigPathParam = Join-Path $myPath $webConfigPathParam
    $webConfigXml = [xml](Get-Content -Path $webConfigPathParam)
    $webConfigXml.configuration.connectionStrings.add.connectionString = $connectionStringParam
    $webConfigXml.Save($webConfigPathParam)
}

function Update-ConnectionString-AppSettings {
    param (
        [string] $connectionStringParam,
        [string] $appSettingsPathParam
    )
    
    $appSettingsPathParam = Join-Path $myPath $appSettingsPathParam
    $appSettingsString = Get-Content $appSettingsPathParam
    $connectionStringJson =  '"GadgetsOnlineEntities": "' + $connectionStringParam +'"'
    $regex = '"GadgetsOnlineEntities"\s*:\s*"(.*?)"'
    $appSettingsString = $appSettingsString -replace $regex, $connectionStringJson
    $appSettingsString | Set-Content $appSettingsPathParam
}


$connectionString = Get-ConnectionString
$webConfig1 = "..\GadgetsOnline\GadgetsOnline\Web.config"
$webConfig2 = "..\extracted-services\InventoryService\GadgetsOnline\Web.config"
$webConfig3 = "..\modified-application-code\GadgetsOnline\GadgetsOnline\Web.config"
$appSettings1 = "..\GadgetsOnline\GadgetsOnline\appsettings.json"
$appSettings2 = "..\extracted-services\InventoryService\GadgetsOnline\appsettings.json"
$appSettings3 = "..\modified-application-code\GadgetsOnline\GadgetsOnline\appsettings.json"

Update-ConnectionString-WebConfig -connectionStringParam $connectionString -webConfigPathParam $webConfig1
Update-ConnectionString-WebConfig -connectionStringParam $connectionString -webConfigPathParam $webConfig2
Update-ConnectionString-WebConfig -connectionStringParam $connectionString -webConfigPathParam $webConfig3

Update-ConnectionString-AppSettings -connectionStringParam $connectionString -appSettingsPathParam $appSettings1
Update-ConnectionString-AppSettings -connectionStringParam $connectionString -appSettingsPathParam $appSettings2
Update-ConnectionString-AppSettings -connectionStringParam $connectionString -appSettingsPathParam $appSettings3
