![graphql-series-dotnet-header](https://user-images.githubusercontent.com/33935506/176561605-49d54095-3d4c-4734-a8fd-ca987b748cbc.png)

&nbsp;

# Graphql For .NET

&nbsp;

A collection of examples demonstrating how to build a GraphQL API using .NET

&nbsp;

---

&nbsp;

## Key Takeaways

&nbsp;

- Project Overview
- Learn how to build a .NET 6 GraphQL API from scratch
- Learn how to define GraphQL queries, and mutations
- Learn how to provide validation and error handling
- Add EntityFramework support both in-memory and SQLite database
- Add support for query projection, filtering, sorting, and paging
- Provision Azure App Service using Azure CLI, Azure, Powershell, and Azure Bicep

&nbsp;

---

&nbsp;

## Project Overview

&nbsp;

- This project explores how to build and deploy a _[GraphQL]_ API in a number of easy to follow examples.
- Each example introduces a new concept that is clear, small, and easy to understand
- All examples are built using _[.NET 6 (LTS)]_ and _[ChilliCream Hot Chocolate (Open-Source GraphQL Server for Microsoft .NET platform)]_
- The GraphQL API is deployed to _Azure App Service_
- The project demonstrates how to provision an _Azure App Service_ using _[Azure CLI]_, _[Azure Powershell]_, and _[Azure Bicep]_

&nbsp;

All examples are based on a fictitious company called _MyView_, that provides a service to view games and game ratings. It also allows reviewers to post and delete game reviews. Therefore, in the examples that follow, I demonstrate how to build a GraphQL API that provides the following capabilities:

&nbsp;

- List games
- List games with associated reviews
- Find a game by id
- Post a game review
- Delete a game review

&nbsp;

The details of the provided examples are as follows:

&nbsp;

- 📘 [Example 1]
  &nbsp;
  - Create empty API project
  - Add GraphQL Server support through the use of the [ChilliCream Hot Chocolate] nuget package
  - Create a games query
  - Create a games mutation
  - Add metadata to support schema documentation

&nbsp;
- 📘 [Example 2]
  &nbsp;
  - Add global error handling
  - Add input validation

&nbsp;
- 📘 [Example 3]
  &nbsp;
  - Add EntityFramework support with an in-memory database
  - Add support for query filtering, sorting, and paging
  - Add projection support
  - Add query type extensions to allow splitting queries into multiple classes

&nbsp;
- 📘 [Example 4]
  &nbsp;
  - Change project to use SQlite instead of an in-memory database

&nbsp;

Lastly, I provide the instructions on how to provision an Azure App Service and deploy the GraphQL API to it. The details are as follows:

&nbsp;

- Provision Azure App Service using Azure CLI
- Provision Azure App Service using Azure Powershell
- Provision Azure App Service using Azure Bicep
- Deploy GraphQL API

&nbsp;

📘 [Find all the infrastructure as code here](https://github.com/drminnaar/graphql-dotnet-series/tree/main/iac)

&nbsp;

---

&nbsp;

## Required Setup and Tools

&nbsp;

It is recommended that the following tools and frameworks are installed before trying to run the examples:

&nbsp;

- [.NET 6 SDK]

  All code in this example is developed with C# 10 using the latest cross-platform .NET 6 framework.

  See the [.NET 6 SDK] official website for details on how to download and setup for your development environment.
  &nbsp;

- [Visual Studio Code]

  Find more information on [Visual Studio Code] with [relevant C# and .NET extensions](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-pack).
  &nbsp;

- [Bicep Installation and Docs](https://docs.microsoft.com/en-us/azure/azure-resource-manager/bicep/install)

  Everything you need to install and configure your windows, linux, and macos environment
  &nbsp;

- [Official Bicep Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-bicep)

  Provides Bicep language support
  &nbsp;

- [JQ](https://stedolan.github.io/jq/)

  jq is a lightweight and flexible command-line JSON processor
  &nbsp;

- [Azure Tools](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack)

  A package of all the Visual Studio Code extensions that you will need to work with Azure
  &nbsp;

- [Azure CLI Tools](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azurecli)

  Tools for developing and running commands of the Azure CLI


&nbsp;

---

## Additional Learning Resources

&nbsp;

I have provided a number of [examples](https://github.com/drminnaar/graphql-dotnet-series) that show how to build a GraphQL Server using [ChilliCream Hot Chocolate] GraphQL Server. If you would like to learn more, please view the following learning resources:

&nbsp;

- [Official Getting Started Documentation](https://chillicream.com/docs/hotchocolate/get-started)
- [Official ChilliCream Hot Chocolate Examples](https://github.com/ChilliCream/hotchocolate-examples)
- [On.NET Show - Getting Started with HotChocolate](https://docs.microsoft.com/en-us/shows/on-net/getting-started-with-hotchocolate)
- [Modern data APIs with EF Core and GraphQL](https://youtu.be/GBvTRcV4PVA)
- [Entity Framework Community Standup - Hot Chocolate 12 and GraphQL 2021](https://youtu.be/3_4nt2QQSeE)
- [GraphQL API with .NET 5 and Hot Chocolate](https://youtu.be/HuN94qNwQmM) (Still applicable to .NET 6)
- [GraphQL in .NET with HotChocolate (Playlist)](https://www.youtube.com/playlist?list=PLA8ZIAm2I03g9z705U3KWJjTv0Nccw9pj)
- [Azure Tips & Tricks - How to use GraphQL on Azure](https://microsoft.github.io/AzureTipsAndTricks/blog/tip287.html)
- [Hot Chocolate: GraphQL Schema Stitching with ASP.Net Core - Michael Staib - NDC London 2021](https://youtu.be/_ncO6kUP-zs)

&nbsp;

### HotChocolate Templates

&nbsp;

There are also a number of Hot Chocolate templates that can be installed using the `dotnet CLI` tool.

&nbsp;

- Install HotChocolate Templates:
  &nbsp;
  ```bash
  
  # install Hot Chocolate GraphQL server templates (includes Azure function template)
  dotnet new -i HotChocolate.Templates
  
  # install template that allows you to create a GraphQL Star Wars Demo
  dotnet new -i HotChocolate.Templates.StarWars
  
  ```
&nbsp;

- List HotChocolate Templates
  &nbsp;
  ```bash

  # list HotChocolate templates
  dotnet new --list HotChocolate

  ```

  ```text

  Template Name                        Short Name   Language  Tags
  -----------------------------------  -----------  --------  ------------------------------
  HotChocolate GraphQL Function        graphql-azf  [C#]      Web/GraphQL/Azure
  HotChocolate GraphQL Server          graphql      [C#]      Web/GraphQL
  HotChocolate GraphQL Star Wars Demo  starwars     [C#]      ChilliCream/HotChocolate/Demos

  ```
&nbsp;
- Create HotChocolate project using templates
  &nbsp;
  ```bash

  # create ASP.NET GraphQL Server
  dotnet new graphql --name MyGraphQLDemo

  # create graphql server using Azure Function
  dotnet new graphql-azf --name MyGraphQLAzfDemo
  
  # create starwars GraphQL demo
  mkdir StarWars
  cd StarWars
  dotnet new starwars

  ```

&nbsp;

---

&nbsp;

## Versioning

&nbsp;

I use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/drminnaar/graphql-dotnet-series/tags).

&nbsp;

---

&nbsp;

## Authors

&nbsp;

- **Douglas Minnaar** - *Initial work* - [drminnaar](https://github.com/drminnaar)

&nbsp;

---

[Visual Studio Code]: https://code.visualstudio.com/
[.NET Extension Pack]: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-dotnet-pack

[GraphQL]: https://graphql.org
[C# .NET GraphQL Libraries]: https://graphql.org/code/#c-net

[.NET 6 SDK]: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
[.NET 6]: https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6
[.NET 6 (LTS)]: https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6
[Entity Framework Core]: https://docs.microsoft.com/en-us/ef/core/

[ChilliCream Hot Chocolate]: https://chillicream.com/docs/hotchocolate
[ChilliCream Hot Chocolate (Open-Source GraphQL Server for Microsoft .NET platform)]: https://chillicream.com/docs/hotchocolate

[Azure CLI]: https://docs.microsoft.com/en-us/cli/azure/
[Azure Powershell]: https://docs.microsoft.com/en-us/powershell/azure/?view=azps-8.0.0
[Azure Bicep]: https://docs.microsoft.com/EN-US/azure/azure-resource-manager/bicep/

[example github repository]: https://github.com/drminnaar/graphql-dotnet-series
[example-1]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-1
[Example 1]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-1
[example-2]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-2
[Example 2]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-2
[example-3]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-3
[Example 3]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-3
[example-4]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-4
[Example 4]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/example-4
[example-iac]: https://github.com/drminnaar/graphql-dotnet-series/tree/main/iac
