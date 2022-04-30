
# Description
Project description goes here

#### Migrations

### Visual Studio
# add or remove code with migrations that will be used by update-databse
Add-Migration [migration_name]
Remove-Migration [migration_name]

# Create/Update or Delete(drop) the database with the new created migrations
Update-Database
Drop-Database
###

### .NET Core CLI Tools
dotnet tool install --global dotnet-ef --version 5.0.8
dotnet tool update --global dotnet-ef --version 5.0.8

dotnet-ef migrations list
dotnet-ef migrations add MigrationName
dotnet-ef database update
###

####
