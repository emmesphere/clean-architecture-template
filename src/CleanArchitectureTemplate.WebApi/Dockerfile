# ---- build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Directory.Packages.props ./
COPY Directory.Build.props ./

COPY src/CleanArchitectureTemplate.WebApi/CleanArchitectureTemplate.WebApi.csproj src/CleanArchitectureTemplate.WebApi/
COPY src/CleanArchitectureTemplate.Application/CleanArchitectureTemplate.Application.csproj src/CleanArchitectureTemplate.Application/
COPY src/CleanArchitectureTemplate.Infrastructure/CleanArchitectureTemplate.Infrastructure.csproj src/CleanArchitectureTemplate.Infrastructure/
COPY src/CleanArchitectureTemplate.Domain/CleanArchitectureTemplate.Domain.csproj src/CleanArchitectureTemplate.Domain/
COPY src/CleanArchitectureTemplate.BuildingBlocks/CleanArchitectureTemplate.BuildingBlocks.csproj src/CleanArchitectureTemplate.BuildingBlocks/

RUN dotnet restore src/CleanArchitectureTemplate.WebApi/CleanArchitectureTemplate.WebApi.csproj

COPY . ./

RUN dotnet publish src/CleanArchitectureTemplate.WebApi/CleanArchitectureTemplate.WebApi.csproj \
    -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "CleanArchitectureTemplate.WebApi.dll"]
