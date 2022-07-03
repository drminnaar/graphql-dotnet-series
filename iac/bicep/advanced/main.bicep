// define scope
targetScope = 'subscription'


// define parameters
@description('The location of all resources')
param location string = deployment().location


// define variables
@description('The name of resource group')
var rgName = 'myview-rg'

@description('The name of resource group')
var aspName = 'myview-asp'

@description('The name of app')
var appName = 'myview-webapp-api'


// define resources
resource resourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgName
  location: location
}


// define modules
module appServiceModule 'modules/app-service.bicep' = {
  scope: resourceGroup
  name: 'myview-module'
  params: {
    appName: appName
    aspName: aspName
    location: location
  }
}


// define outputs
output defaultHostName string = appServiceModule.outputs.defaultHostName
output resourceGroupName string = rgName
