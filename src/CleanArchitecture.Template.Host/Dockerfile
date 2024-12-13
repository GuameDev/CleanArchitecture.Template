#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CleanArchitecture.Template.Host/CleanArchitecture.Template.Host.csproj", "CleanArchitecture.Template.Host/"]
COPY ["CleanArchitecture.Template.Application/CleanArchitecture.Template.Application.csproj", "CleanArchitecture.Template.Application/"]
COPY ["CleanArchitecture.Template.Domain/CleanArchitecture.Template.Domain.csproj", "CleanArchitecture.Template.Domain/"]
COPY ["CleanArchitecture.Template.Infrastructure/CleanArchitecture.Template.Infrastructure.csproj", "CleanArchitecture.Template.Infrastructure/"]
RUN dotnet restore "./CleanArchitecture.Template.Host/CleanArchitecture.Template.Host.csproj"
COPY . .
WORKDIR "/src/CleanArchitecture.Template.Host"
RUN dotnet build "./CleanArchitecture.Template.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CleanArchitecture.Template.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Keeping the ENTRYPOINT as before
ENTRYPOINT ["dotnet", "CleanArchitecture.Template.Host.dll"]
