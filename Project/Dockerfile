# Use the official .NET SDK image for the build phase
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the project file and restore dependencies
COPY Api.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build and publish the application
RUN dotnet build -c Release -o /Api/build
RUN dotnet publish -c Release -o /Api/publish

# Use the official .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set the working directory in the final container
WORKDIR /Api

# Copy the published application from the build stage
COPY --from=build /Api/publish .

# Expose ports (optional, depending on your application needs)
EXPOSE 80
EXPOSE 443

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Api.dll"]
