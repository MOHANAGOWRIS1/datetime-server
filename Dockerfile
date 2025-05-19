# Use the official Microsoft .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set working directory inside the container
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0

WORKDIR /app
COPY --from=build-env /app/out .

# For console app, run the executable (adjust name accordingly)
ENTRYPOINT ["dotnet", "DateandTime.dll"]
