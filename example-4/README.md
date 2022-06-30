# Example 4

## Setup Instructions

Because this example uses SQLite, you will need to run the following EntityFramework instructions to setup the SQLite database.

```pwsh
# navigate to API project folder
cd ./MyView.Api

# create the database migrations
dotnet ef migrations add "CreateInitialDatabaseSchema"

# run the migrations to create database
dotnet ef database update
```
