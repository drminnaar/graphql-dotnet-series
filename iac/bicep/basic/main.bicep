// parameters
@description('The name of app service')
param appName string

@description('The name of app service plan')
param aspName string

@description('The location of all resources')
param location string = resourceGroup().location

@description('The Runtime stack of current web app')
param linuxFxVersion string = 'DOTNETCORE|6.0'

@allowed([
  'F1'
  'B1'
])
param skuName string = 'F1'

// variables

resource asp 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: aspName
  location: location
  kind: 'linux'
  sku: {
    name: skuName
  }
  properties: {
    reserved: true
  }
}

resource app 'Microsoft.Web/sites@2021-02-01' = {
  name: appName
  location: location
  properties: {
    serverFarmId: asp.id
    httpsOnly: true
    siteConfig: {
      linuxFxVersion: linuxFxVersion
    }
  }
}
