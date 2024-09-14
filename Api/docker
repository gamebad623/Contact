# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install phase
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

# Specify the project file explicitly for dotnet restore
RUN dotnet restore "./Api.csproj"

# Build phase
RUN dotnet build "./Api.csproj" -c Release -o /app/build

# Publish phase
FROM build AS publish
RUN dotnet publish "./Api.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
