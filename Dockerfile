# 1. Use the .NET SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# 2. Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# 3. Copy everything else and build the release
COPY . ./
RUN dotnet publish -c Release -o out

# 4. Use the ASP.NET runtime to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# 5. Tell the app to listen on the port Render provides
ENV ASPNETCORE_URLS=http://+:10000

# 6. Start the app (Make sure 'Task3.dll' matches your project name!)
ENTRYPOINT ["dotnet", "Task3.dll"]
