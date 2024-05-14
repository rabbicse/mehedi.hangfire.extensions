#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["examples/Hangfire.Extensions.Example/Hangfire.Extensions.Example.csproj", "examples/Hangfire.Extensions.Example/"]
RUN dotnet restore "./examples/Hangfire.Extensions.Example/Hangfire.Extensions.Example.csproj"
COPY . .
WORKDIR "/src/examples/Hangfire.Extensions.Example"
RUN dotnet build "./Hangfire.Extensions.Example.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hangfire.Extensions.Example.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hangfire.Extensions.Example.dll"]