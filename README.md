
# Migrations

# Visual Studio
Get-Migrations
Add-Migration
Remove-Migration

# .NET Core CLI Tools
dotnet tool install --global dotnet-ef --version 5.0.8
dotnet tool update --global dotnet-ef --version 5.0.8

dotnet-ef migrations list
dotnet-ef migrations add MigrationName
dotnet-ef database update
