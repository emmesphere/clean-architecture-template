# Clean Architecture Template (.NET 8)

A minimal, production-ready Clean Architecture template for .NET 8 APIs.

## Features

-   Clean Architecture (Domain, Application, Infrastructure, WebApi)
-   DDD building blocks (AggregateRoot, ValueObject, DomainEvents)
-   Minimal APIs
-   Serilog (Console + Seq)
-   Health Checks
-   EF Core (configurable)
-   Docker / Podman support
-   GitHub Actions CI
-   Unit, Integration and Architecture Tests

------------------------------------------------------------------------

## 📂 Project Structure

    src/
     ├── Domain
     ├── Application
     ├── Infrastructure
     ├── WebApi
     └── BuildingBlocks

    tests/
     ├── Domain.Tests
     ├── Application.Tests
     ├── WebApi.Tests
     └── ArchitectureTests

------------------------------------------------------------------------

## 🚀 Run Locally

``` bash
dotnet restore
dotnet build
dotnet run --project src/CleanArchitectureTemplate.WebApi
```

------------------------------------------------------------------------

## 🐋 Run with Docker / Podman

``` bash
podman compose up --build
```

API: http://localhost:8080\
Seq: http://localhost:5341

------------------------------------------------------------------------

## 📊 Logging

-   Console enabled by default
-   Seq enabled in Development
-   Configurable via `appsettings.json` or environment variables

------------------------------------------------------------------------

## ❤️ Health Endpoints

    /health
    /health/ready

------------------------------------------------------------------------

## 🧪 Tests

``` bash
dotnet test
```

------------------------------------------------------------------------

# Using as a .NET Template

This repository is configured as a `dotnet new` template.

### 1️⃣ Install locally

From the repository root:

``` bash
dotnet new install .
```

### 2️⃣ Create a new project

``` bash
dotnet new cleanarch -n MyProject
```

This will:

-   Replace all occurrences of `CleanArchitectureTemplate`
-   Generate a new solution with your project name
-   Preserve the full Clean Architecture structure

### 3️⃣ Uninstall (if needed)

``` bash
dotnet new uninstall CleanArchitectureTemplate
```

------------------------------------------------------------------------

## 🛠 CI (GitHub Actions)

Pipeline runs automatically:

-   Restore
-   Build (Release)
-   Tests

Arquivo:

    .github/workflows/ci.yml


------------------------------------------------------------------------

## 📜 License

MIT
