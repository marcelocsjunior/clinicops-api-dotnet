# ClinicOps API .NET

API REST em ASP.NET Core para gestão de chamados técnicos, ativos e manutenção em ambientes clínicos e corporativos.

## Objetivo

O **ClinicOps API .NET** será o segundo case técnico em .NET do portfólio para o Processo Seletivo 01645/2026 — Mentor Educacional de TI — Desenvolvedor Back-End .NET — SENAI/SC LAB365.

A proposta é demonstrar aplicação prática de back-end .NET em um domínio operacional real: suporte técnico, infraestrutura, ativos, chamados e manutenção em clínicas e empresas que dependem de tecnologia para operar com segurança e continuidade.

A Sprint 1 criou a base executável inicial da API com ASP.NET Core Web API, Swagger/OpenAPI e endpoint de status.

## Stack prevista

- .NET 8
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite no MVP
- SQL Server em evolução futura
- Swagger / OpenAPI
- xUnit em fase posterior
- GitHub Actions em fase posterior

## Escopo do MVP

O MVP futuro deverá permitir:

- cadastrar clínicas ou unidades atendidas;
- cadastrar ativos e equipamentos por unidade;
- abrir, consultar, atualizar e encerrar chamados técnicos;
- registrar manutenções realizadas;
- associar técnicos responsáveis;
- consultar um resumo operacional simples em formato de dashboard.

## Entidades previstas

### Clinic

- Id
- Name
- City
- State
- IsActive
- CreatedAt
- UpdatedAt

### Asset

- Id
- ClinicId
- Name
- AssetType
- SerialNumber
- Location
- IsActive
- CreatedAt
- UpdatedAt

### Ticket

- Id
- ClinicId
- AssetId
- Title
- Description
- Priority
- Status
- OpenedAt
- ClosedAt
- CreatedAt
- UpdatedAt

### Technician

- Id
- FullName
- Email
- IsActive
- CreatedAt
- UpdatedAt

### MaintenanceLog

- Id
- AssetId
- TechnicianId
- Description
- PerformedAt
- CreatedAt

## Endpoints planejados

```http
GET    /api/status

GET    /api/clinics
GET    /api/clinics/{id}
POST   /api/clinics
PUT    /api/clinics/{id}
DELETE /api/clinics/{id}

GET    /api/assets
GET    /api/assets/{id}
POST   /api/assets
PUT    /api/assets/{id}
DELETE /api/assets/{id}

GET    /api/tickets
GET    /api/tickets/{id}
POST   /api/tickets
PUT    /api/tickets/{id}
DELETE /api/tickets/{id}

GET    /api/maintenance-logs
POST   /api/maintenance-logs

GET    /api/dashboard/summary
```

## Arquitetura planejada

O projeto seguirá uma arquitetura simples, objetiva e defensável para MVP:

```text
src/
  ClinicOps.Api/
    Controllers/
    Data/
    DTOs/
    Models/
    Services/
    Program.cs
```

Separação planejada:

- **Controllers**: entrada HTTP e contrato REST.
- **DTOs**: modelos de entrada e saída da API.
- **Services**: regras de negócio e orquestração.
- **Models**: entidades do domínio.
- **Data**: DbContext, configuração EF Core e persistência.

A decisão inicial é não usar Clean Architecture completa no MVP. Para o objetivo de banca e portfólio, uma estrutura em camadas simples comunica melhor os fundamentos: Controller, DTO, Service, Dependency Injection, EF Core e persistência.

## Roadmap

- **Sprint 0 — Baseline documental**: documentação inicial, posicionamento do case e preparação do repositório.
- **Sprint 1 — Bootstrap ASP.NET Core Web API + Swagger**: criação da solution, projeto Web API e endpoint de status.
- **Sprint 2 — Tickets API**: Controller, DTO, Service, DI e EF Core para chamados técnicos.
- **Sprint 3 — Assets e Clinics**: cadastro de unidades e ativos/equipamentos.
- **Sprint 4 — Maintenance Logs e Dashboard**: registros de manutenção e resumo operacional.
- **Sprint 5 — Qualidade, testes e documentação final**: ajustes finais, testes e narrativa de apresentação.

## Uso como case de portfólio

O ClinicOps API .NET será apresentado como um case de back-end conectado à operação técnica real. O projeto traduz experiência prática com infraestrutura crítica, suporte técnico, manutenção de equipamentos e ambientes clínicos para uma API REST organizada, documentada e evolutiva.

Narrativa-base para banca:

> O ClinicOps API .NET é meu segundo case de portfólio em .NET. Enquanto o MentorLab API trabalha o domínio educacional e serve como base direta para a aula teste, o ClinicOps aplica ASP.NET Core Web API em um domínio operacional real: chamados técnicos, ativos e manutenção em clínicas e ambientes corporativos. A proposta é demonstrar que consigo usar a mesma base de back-end .NET em contextos distintos, com organização, documentação e visão prática de mercado.

## Diferença entre ClinicOps e MentorLab

| Projeto | Domínio | Finalidade | Diferencial |
|---|---|---|---|
| MentorLab API .NET | Educacional | Gestão de alunos, trilhas, exercícios e feedbacks | Case principal conectado diretamente à aula teste |
| ClinicOps API .NET | Operacional | Gestão de chamados, ativos e manutenção | Case conectado à experiência prática em clínicas, suporte técnico e infraestrutura |

Essa separação evita que os dois projetos pareçam apenas dois CRUDs com nomes diferentes. A diferença está no domínio, nas entidades, na narrativa operacional e nos problemas resolvidos.

## Status atual

```text
Sprint atual: Sprint 1 — Bootstrap ASP.NET Core Web API + Swagger
Status: em desenvolvimento via Pull Request
Código .NET: criado
Solution: ClinicOps.sln criada
Projeto ASP.NET Core: src/ClinicOps.Api criado
Persistência: planejada, ainda não implementada
```

## Sprint 1 — Bootstrap ASP.NET Core Web API + Swagger

A Sprint 1 cria a base executável inicial do projeto.

### Estrutura criada

```text
ClinicOps.sln
src/
  ClinicOps.Api/
    ClinicOps.Api.csproj
    Program.cs
    appsettings.json
    appsettings.Development.json
    Properties/
      launchSettings.json
```

### Funcionalidades entregues

- ASP.NET Core Web API em .NET 8.
- Swagger/OpenAPI habilitado em ambiente de desenvolvimento.
- Endpoint inicial de status.
- Porta local recomendada: `5081`.

### Endpoint inicial

```http
GET /api/status
```

Resposta esperada:

```json
{
  "status": "ok",
  "service": "ClinicOps API",
  "environment": "Development",
  "timestampUtc": "..."
}
```

### Como restaurar dependências

```bash
dotnet restore ClinicOps.sln
```

### Como compilar

```bash
dotnet build ClinicOps.sln
```

### Como executar

```bash
dotnet run --project src/ClinicOps.Api/ClinicOps.Api.csproj --urls http://0.0.0.0:5081
```

### URLs locais

```text
http://localhost:5081/swagger
http://localhost:5081/api/status
```

### Fora de escopo nesta sprint

- EF Core.
- SQLite.
- Migrations.
- CRUDs de domínio.
- Entidades `Clinic`, `Asset`, `Ticket`, `Technician` e `MaintenanceLog`.
- Dados reais.
- Secrets.

Esses itens entram nas próximas sprints.

## Segurança e governança

- Não usar dados reais de clientes.
- Não citar clínicas reais.
- Não versionar secrets.
- Não versionar banco local.
- Não versionar arquivos pessoais ou temporários.
- Manter escopo incremental por sprint.

## Licença

Distribuído sob licença MIT. Consulte o arquivo [LICENSE](LICENSE).
