# Clean Architecture Template (.NET 8)

Template base para APIs em .NET 8 utilizando:

-   Clean Architecture
-   DDD (Aggregate Root, Value Object, Domain Events)
-   Minimal APIs
-   Serilog (Console + Seq)
-   Health Checks
-   EF Core (configurável)
-   JWT (configurável)
-   Docker / Podman
-   GitHub Actions CI
-   Testes (Unit, Architecture, WebApi)

Este template foi projetado para ser versátil: Pode ser usado tanto para
um projeto simples (ex: To-Do List) quanto para um microservice mais
complexo.

------------------------------------------------------------------------

## 📂 Estrutura da solução

    src/
     ├── CleanArchitectureTemplate.Domain
     ├── CleanArchitectureTemplate.Application
     ├── CleanArchitectureTemplate.Infrastructure
     ├── CleanArchitectureTemplate.WebApi
     └── CleanArchitectureTemplate.BuildingBlocks

    tests/
     ├── CleanArchitectureTemplate.Domain.Tests
     ├── CleanArchitectureTemplate.Application.Tests
     ├── CleanArchitectureTemplate.WebApi.Tests
     └── CleanArchitectureTemplate.ArchitectureTests

### Camadas

-   **Domain** → Entidades, ValueObjects, AggregateRoot, DomainEvents
-   **Application** → Commands, Handlers, Use Cases
-   **Infrastructure** → EF Core, integrações externas
-   **WebApi** → Endpoints, Middlewares, Configuração
-   **BuildingBlocks** → Result, Error, Base abstractions

------------------------------------------------------------------------

## 🚀 Como rodar localmente

### 1️⃣ Rodar via .NET CLI

``` bash
dotnet restore
dotnet build
dotnet run --project src/CleanArchitectureTemplate.WebApi
```

Health check:

    GET http://localhost:<porta>/health

------------------------------------------------------------------------

### 2️⃣ Rodar com Docker / Podman

``` bash
podman compose up --build
```

ou

``` bash
docker compose up --build
```

API:

    http://localhost:8080

Health:

    http://localhost:8080/health

Seq:

    http://localhost:5341

------------------------------------------------------------------------

## 📊 Logging (Serilog)

-   Console sempre habilitado
-   Seq habilitado em Development
-   Configuração via `appsettings.json` ou variáveis de ambiente

	http://localhost:5341

------------------------------------------------------------------------

## ❤️ Health Checks

Endpoints disponíveis:

    /health
    /health/ready

Podem ser estendidos para incluir:

-   Banco de dados
-   Redis
-   RabbitMQ
-   Serviços externos

------------------------------------------------------------------------

## 🧪 Testes

Rodar todos os testes:

``` bash
dotnet test
```

Tipos de testes:

-   Unit tests (Domain / Application)
-   Integration tests (WebApi)
-   Architecture tests (Layer validation)

------------------------------------------------------------------------

## 🛠 CI (GitHub Actions)

Pipeline executa automaticamente:

-   Restore
-   Build (Release)
-   Testes

Arquivo:

    .github/workflows/ci.yml

------------------------------------------------------------------------

## 🧱 Exemplo incluído

O template contém um exemplo mínimo de domínio:

-   1 Aggregate Root
-   1 Value Object
-   1 Regra de negócio
-   1 Command + Handler
-   1 Endpoint minimal API
-   Persistência configurável

------------------------------------------------------------------------

## 🔐 Segurança

O template já inclui:

-   Headers de segurança básicos
-   HTTPS redirection
-   HSTS (produção)

------------------------------------------------------------------------

## 📜 Licença

MIT
