# 1. Use the .NET 10.0 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /app

# 2. Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# 3. Copy everything else and build the release
COPY . ./
RUN dotnet publish -c Release -o out

# 4. Use the ASP.NET 10.0 runtime to run the app
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build-env /app/out .

# 5. Tell the app to listen on the port Render provides
ENV ASPNETCORE_URLS=http://+:10000

# 6. Start the app (Ensure 'Task3.dll' matches your project output)
ENTRYPOINT ["dotnet", "Task3.dll"]
