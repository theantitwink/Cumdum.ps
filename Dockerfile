# Start with the .NET SDK for building the app
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
# Work within a folder named `/src`
RUN mkdir -p /src/cumdum.ps/
WORKDIR /src/cumdum.ps/

# Copy everything in this project and build app
COPY . ./
RUN dotnet restore Server/Cumdumps.Server.csproj
RUN dotnet publish Server/Cumdumps.Server.csproj -c:Release -o /app -p:IsBuildingInDocker=true

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:latest
RUN mkdir -p /app
WORKDIR /app
COPY --from=build /app ./

# Expose port 80
# This is important in order for the Azure App Service to pick up the app
ENV PORT 8080
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "Cumdumps.Server.dll", "--urls:http://localhost:8080"]
