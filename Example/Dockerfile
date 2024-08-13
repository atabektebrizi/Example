#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Example/Example.csproj", "Example/"]
COPY ["Example.ApplicationLayer/Example.ApplicationLayer.csproj", "Example.ApplicationLayer/"]
COPY ["Example.Database/Example.Database.csproj", "Example.Database/"]
COPY ["Example.DomainLayer/Example.DomainLayer.csproj", "Example.DomainLayer/"]
COPY ["Example.ViewModel/Example.ViewModel.csproj", "Example.ViewModel/"]
RUN dotnet restore "./Example/Example.csproj"
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "./Example.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Example.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]