## Asping
Project description goes here
## Migrations
Migrations can be dealt in two ways
### Visual Studio
Add or Remove code with migrations to be used by update-database command:
```
Add-Migration [migration_name]  
Remove-Migration [migration_name]  
```
Create/Update or Delete the database with the new created migrations
```
Update-Database
Drop-Database
```
### .NET Core CLI Tools
```
dotnet tool install --global dotnet-ef --version 5.0.8  
dotnet tool update --global dotnet-ef --version 5.0.8
```
Latest versions can be checked here: https://www.nuget.org/packages/dotnet-ef/
Check the same version of Entity Framework used in this project
```
dotnet-ef migrations list  
dotnet-ef migrations add MigrationName  
dotnet-ef database update
```
