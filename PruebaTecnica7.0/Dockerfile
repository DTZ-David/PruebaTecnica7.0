#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PruebaTecnica7.0/PruebaTecnica7.0.csproj", "PruebaTecnica7.0/"]
RUN dotnet restore "./PruebaTecnica7.0/./PruebaTecnica7.0.csproj"
COPY . .
WORKDIR "/src/PruebaTecnica7.0"
RUN dotnet build "./PruebaTecnica7.0.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PruebaTecnica7.0.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaTecnica7.0.dll"]