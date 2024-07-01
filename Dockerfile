#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["DigitalOcean/DigitalOcean.csproj", "DigitalOcean/"]
COPY . .
WORKDIR "/src/DigitalOcean"

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "DigitalOcean.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalOcean.dll"]