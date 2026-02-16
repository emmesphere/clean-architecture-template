# Clean Architecture Template (.NET 8)

Template básico para novos projetos:

- **Clean Architecture**: Domain / Application / Infrastructure / WebApi
- **JWT Bearer** (autenticação)
- **OWASP hardening básico**: HTTPS, headers de segurança, rate limiting, ProblemDetails, CORS por allowlist
- Health checks em `/health`

## Segurança

- **Não** commite segredos.
- Em desenvolvimento, use `dotnet user-secrets` para `Jwt:Secret`.
- Em produção, use variáveis de ambiente/secret manager.

## Rodar

```bash
cd src/CleanArchitectureTemplate.WebApi

dotnet run
```

