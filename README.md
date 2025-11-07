## Asping
This project aims to be a repository with .NET Core content and practices.  

.NET Core key concepts:
- **Routing**: Route a request to whenever you desire. 
- **Middleware** - Useful to change HTTP requests and responses. It allows developers to add custom logic to the request pipeline.
- Action Filters
- [Entity Framework](#migrations-with-entity-framework)
- Razor Pages
- Blazer
- Package Management
- Deployment
- **CLI**: Command Line Interface is a  Cross platform toolchain for developing, building, running and publishing .NET apps.
- Dependency Injection
- Authentication and Authorization
- Logging
- Background Tasks
- CI/CD - From a merge to master to a new working version available in live.


## Entity Framework Migrations
Migrations can be handled in two ways
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
dotnet tool update 	--global dotnet-ef --version 5.0.8
```
Latest versions can be checked here: https://www.nuget.org/packages/dotnet-ef/
Check the same version of Entity Framework used in this project
```
dotnet-ef migrations list  
dotnet-ef migrations add MigrationName  
dotnet-ef migrations remove  

dotnet-ef database update
dotnet-ef database drop
```
