FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /src

COPY . .

RUN dotnet publish -c Release -r linux-x64 -o /app


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app ./

ENTRYPOINT ["dotnet","Asping.dll"]