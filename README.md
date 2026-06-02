# ClinicOps API .NET

API REST em ASP.NET Core para gestão de chamados técnicos, ativos e manutenção em ambientes clínicos e corporativos.

## Objetivo

O **ClinicOps API .NET** será o segundo case técnico em .NET do portfólio para o Processo Seletivo 01645/2026 — Mentor Educacional de TI — Desenvolvedor Back-End .NET — SENAI/SC LAB365.

A proposta é demonstrar aplicação prática de back-end .NET em um domínio operacional real: suporte técnico, infraestrutura, ativos, chamados e manutenção em clínicas e empresas que dependem de tecnologia para operar com segurança e continuidade.

A Sprint 4 adicionou técnicos, registros de manutenção vinculados a ativos e técnicos, e um dashboard operacional consolidado.

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

GET    /api/technicians
GET    /api/technicians/{id}
POST   /api/technicians
PUT    /api/technicians/{id}
DELETE /api/technicians/{id}

GET    /api/maintenance-logs
GET    /api/maintenance-logs/{id}
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
Sprint atual: Sprint 4 — Maintenance Logs API e Dashboard operacional
Status: em desenvolvimento via Pull Request
Código .NET: criado
Solution: ClinicOps.sln criada
Projeto ASP.NET Core: src/ClinicOps.Api criado
Persistência: EF Core com SQLite e migrations incrementais
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

## Sprint 2 — Tickets API com Controller, DTO, Service, DI e EF Core

Nesta sprint eu implementei o primeiro fluxo real de domínio do ClinicOps API .NET: chamados técnicos. A entrega demonstra Controller, DTOs, Service, Dependency Injection, EF Core, SQLite e migration inicial, mantendo o escopo controlado antes de evoluir para clínicas, ativos, manutenção e dashboard.

### Objetivo

Implementar um CRUD completo de tickets técnicos usando ASP.NET Core Web API, Entity Framework Core e SQLite.

### Arquivos principais criados ou alterados

```text
src/ClinicOps.Api/
  Controllers/
    TicketsController.cs
  Data/
    ClinicOpsDbContext.cs
  DTOs/
    Tickets/
      CreateTicketRequest.cs
      UpdateTicketRequest.cs
      TicketResponse.cs
  Migrations/
    *_InitialCreateTickets.cs
    *_InitialCreateTickets.Designer.cs
    ClinicOpsDbContextModelSnapshot.cs
  Models/
    Ticket.cs
  Services/
    Implementations/
      TicketService.cs
    Interfaces/
      ITicketService.cs
  Program.cs
  appsettings.json
  ClinicOps.Api.csproj
```

Também foi atualizado o `.gitignore` para não versionar bancos SQLite locais:

```text
*.db
*.db-shm
*.db-wal
```

### Endpoints implementados

```http
GET    /api/tickets
GET    /api/tickets/{id}
POST   /api/tickets
PUT    /api/tickets/{id}
DELETE /api/tickets/{id}
```

Retornos esperados:

- `GET /api/tickets`: `200 OK`
- `GET /api/tickets/{id}` existente: `200 OK`
- `GET /api/tickets/{id}` inexistente: `404 Not Found`
- `POST /api/tickets` válido: `201 Created`
- `PUT /api/tickets/{id}` existente: `200 OK`
- `PUT /api/tickets/{id}` inexistente: `404 Not Found`
- `DELETE /api/tickets/{id}` existente: `204 No Content`
- `DELETE /api/tickets/{id}` inexistente: `404 Not Found`

### Regras implementadas

- Status padrão ao criar ticket: `Open`.
- Priority padrão ao criar ticket sem prioridade informada: `Medium`.
- `OpenedAt` e `CreatedAt` preenchidos com `DateTime.UtcNow`.
- `UpdatedAt` preenchido ao atualizar ticket.
- Ao atualizar status para `Closed`, `ClosedAt` é preenchido quando ainda estiver nulo.
- Ao alterar status de `Closed` para outro valor, `ClosedAt` é limpo.
- O delete remove fisicamente o ticket nesta sprint para manter o MVP simples.

### Comandos EF

Criar migration inicial:

```bash
dotnet ef migrations add InitialCreateTickets --project src/ClinicOps.Api/ClinicOps.Api.csproj
```

Aplicar banco local:

```bash
dotnet ef database update --project src/ClinicOps.Api/ClinicOps.Api.csproj
```

### Comandos de validação

```bash
dotnet restore ClinicOps.sln
dotnet build ClinicOps.sln
dotnet ef database update --project src/ClinicOps.Api/ClinicOps.Api.csproj
dotnet run --project src/ClinicOps.Api/ClinicOps.Api.csproj --urls http://0.0.0.0:5081
```

### Exemplos curl

Verificar status da API:

```bash
curl http://localhost:5081/api/status
```

Listar tickets:

```bash
curl http://localhost:5081/api/tickets
```

Criar ticket:

```bash
curl -X POST http://localhost:5081/api/tickets \
  -H "Content-Type: application/json" \
  -d '{
    "clinicId": null,
    "assetId": null,
    "title": "Falha de acesso ao compartilhamento de arquivos",
    "description": "Usuários relatam erro intermitente ao acessar pasta compartilhada.",
    "priority": "High"
  }'
```

Atualizar ticket:

```bash
curl -X PUT http://localhost:5081/api/tickets/1 \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Falha de acesso ao compartilhamento de arquivos",
    "description": "Atendimento em andamento e evidência coletada.",
    "priority": "High",
    "status": "InProgress"
  }'
```

Fechar ticket:

```bash
curl -X PUT http://localhost:5081/api/tickets/1 \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Falha de acesso ao compartilhamento de arquivos",
    "description": "Chamado resolvido após validação operacional.",
    "priority": "High",
    "status": "Closed"
  }'
```

Excluir ticket:

```bash
curl -X DELETE http://localhost:5081/api/tickets/1
```

### Fora de escopo confirmado

- Clinics API.
- Assets API.
- Maintenance Logs API.
- Dashboard.
- Autenticação.
- Dados reais.
- Clean Architecture completa.
- Versionamento de banco SQLite local ou secrets.

## Sprint 3 — Clinics API e Assets API

Nesta sprint eu evoluí o domínio operacional do ClinicOps API .NET adicionando clínicas/unidades e ativos/equipamentos. A entrega demonstra modelagem relacional com EF Core, relacionamento 1:N entre Clinic e Asset, controllers, DTOs, services, DI e migration incremental, mantendo o projeto simples, rastreável e preparado para chamados técnicos mais contextualizados.

### Objetivo

Implementar os fluxos de clínicas/unidades e ativos/equipamentos usando ASP.NET Core Web API, Entity Framework Core e SQLite.

### Entidades adicionadas

```text
Clinic
  Id
  Name
  City
  State
  IsActive
  CreatedAt
  UpdatedAt
  Assets

Asset
  Id
  ClinicId
  Name
  AssetType
  SerialNumber
  Location
  IsActive
  CreatedAt
  UpdatedAt
  Clinic
```

### Arquivos principais criados ou alterados

```text
src/ClinicOps.Api/
  Controllers/
    ClinicsController.cs
    AssetsController.cs
  Data/
    ClinicOpsDbContext.cs
  DTOs/
    Clinics/
      CreateClinicRequest.cs
      UpdateClinicRequest.cs
      ClinicResponse.cs
    Assets/
      CreateAssetRequest.cs
      UpdateAssetRequest.cs
      AssetResponse.cs
  Migrations/
    *_AddClinicsAndAssets.cs
    *_AddClinicsAndAssets.Designer.cs
    ClinicOpsDbContextModelSnapshot.cs
  Models/
    Clinic.cs
    Asset.cs
  Services/
    Implementations/
      ClinicService.cs
      AssetService.cs
    Interfaces/
      IClinicService.cs
      IAssetService.cs
  Program.cs
```

### Endpoints implementados

```http
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
```

### Regras de relacionamento

- `Clinic` possui relacionamento 1:N com `Asset`.
- `Asset.ClinicId` é obrigatório e possui FK para `Clinic`.
- O relacionamento usa `DeleteBehavior.Restrict`.
- Uma clínica com ativos vinculados não pode ser removida pela API e retorna `409 Conflict`.
- `Ticket` continua com `ClinicId` e `AssetId` opcionais, sem relacionamento obrigatório nesta sprint.

### Regras de validação

- Clinics: `Name` obrigatório com max 120, `City` obrigatório com max 80, `State` obrigatório com max 2.
- Assets: `ClinicId` deve ser maior que zero, `Name` obrigatório com max 120, `AssetType` obrigatório com max 60, `SerialNumber` max 120 e `Location` max 120.
- Criar ou atualizar asset com `ClinicId` inexistente retorna `400 Bad Request`.

### Comandos EF

Criar migration incremental:

```bash
dotnet ef migrations add AddClinicsAndAssets --project src/ClinicOps.Api/ClinicOps.Api.csproj
```

Aplicar banco local:

```bash
dotnet ef database update --project src/ClinicOps.Api/ClinicOps.Api.csproj
```

### Comandos de validação

```bash
dotnet restore ClinicOps.sln
dotnet build ClinicOps.sln
dotnet ef database update --project src/ClinicOps.Api/ClinicOps.Api.csproj
dotnet run --project src/ClinicOps.Api/ClinicOps.Api.csproj --urls http://0.0.0.0:5081
```

### Exemplos curl

Verificar status da API:

```bash
curl http://localhost:5081/api/status
```

Listar clínicas:

```bash
curl http://localhost:5081/api/clinics
```

Criar clínica:

```bash
curl -X POST http://localhost:5081/api/clinics \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Clínica Exemplo Norte",
    "city": "Cidade Exemplo",
    "state": "MG",
    "isActive": true
  }'
```

Criar ativo vinculado à clínica:

```bash
curl -X POST http://localhost:5081/api/assets \
  -H "Content-Type: application/json" \
  -d '{
    "clinicId": 1,
    "name": "Servidor de Arquivos Exemplo",
    "assetType": "Server",
    "serialNumber": "SN-DEMO-0001",
    "location": "Sala Técnica",
    "isActive": true
  }'
```

Listar ativos:

```bash
curl http://localhost:5081/api/assets
```

Atualizar ativo:

```bash
curl -X PUT http://localhost:5081/api/assets/1 \
  -H "Content-Type: application/json" \
  -d '{
    "clinicId": 1,
    "name": "Servidor de Arquivos Exemplo",
    "assetType": "Server",
    "serialNumber": "SN-DEMO-0001",
    "location": "Rack Principal",
    "isActive": true
  }'
```

Validar proteção de delete da clínica com ativo vinculado:

```bash
curl -i -X DELETE http://localhost:5081/api/clinics/1
```

Excluir ativo:

```bash
curl -i -X DELETE http://localhost:5081/api/assets/1
```

Excluir clínica:

```bash
curl -i -X DELETE http://localhost:5081/api/clinics/1
```

### Fora de escopo confirmado

- Maintenance Logs API.
- Dashboard.
- Autenticação.
- Alterações no fluxo de Tickets além da compatibilidade com o DbContext.
- Dados reais.
- Clean Architecture completa.
- Versionamento de banco SQLite local ou secrets.

## Sprint 4 — Maintenance Logs API e Dashboard operacional

Nesta sprint eu ampliei o domínio operacional do ClinicOps API .NET com cadastro de técnicos, histórico de manutenções por ativo e técnico, e um resumo consolidado para leitura rápida da operação.

### Objetivo

Implementar Technicians API, Maintenance Logs API e Dashboard operacional usando ASP.NET Core Web API, Entity Framework Core e SQLite.

### Entidades adicionadas

```text
Technician
  Id
  FullName
  Email
  IsActive
  CreatedAt
  UpdatedAt
  MaintenanceLogs

MaintenanceLog
  Id
  AssetId
  TechnicianId
  Description
  PerformedAt
  CreatedAt
  Asset
  Technician
```

### Endpoints implementados

```http
GET    /api/technicians
GET    /api/technicians/{id}
POST   /api/technicians
PUT    /api/technicians/{id}
DELETE /api/technicians/{id}

GET    /api/maintenance-logs
GET    /api/maintenance-logs/{id}
POST   /api/maintenance-logs

GET    /api/dashboard/summary
```

### Regras de relacionamento

- `Technician` possui relacionamento 1:N com `MaintenanceLog`.
- `Asset` possui relacionamento 1:N com `MaintenanceLog`.
- `MaintenanceLog.AssetId` e `MaintenanceLog.TechnicianId` são obrigatórios.
- Os relacionamentos usam `DeleteBehavior.Restrict`.
- Técnico ou ativo com manutenção vinculada não pode ser removido pela API e retorna `409 Conflict`.

### Fluxo operacional resumido

1. Criar clínica fictícia.
2. Criar ativo vinculado à clínica.
3. Criar técnico fictício.
4. Registrar manutenção no ativo com o técnico responsável.
5. Consultar `/api/dashboard/summary`.

### Comandos EF

Criar migration incremental:

```bash
dotnet ef migrations add AddTechniciansAndMaintenanceLogs --project src/ClinicOps.Api/ClinicOps.Api.csproj
```

Aplicar banco local:

```bash
dotnet ef database update --project src/ClinicOps.Api/ClinicOps.Api.csproj
```

### Comandos de validação

```bash
dotnet restore ClinicOps.sln
dotnet build ClinicOps.sln --no-restore
dotnet ef database update --project src/ClinicOps.Api/ClinicOps.Api.csproj
dotnet run --project src/ClinicOps.Api/ClinicOps.Api.csproj --urls http://0.0.0.0:5081
```

### Exemplos curl

Criar técnico:

```bash
curl -X POST http://localhost:5081/api/technicians \
  -H "Content-Type: application/json" \
  -d '{
    "fullName": "Técnico Demo",
    "email": "tecnico.demo@example.com",
    "isActive": true
  }'
```

Registrar manutenção:

```bash
curl -X POST http://localhost:5081/api/maintenance-logs \
  -H "Content-Type: application/json" \
  -d '{
    "assetId": 1,
    "technicianId": 1,
    "description": "Manutenção preventiva registrada para demonstração"
  }'
```

Consultar dashboard:

```bash
curl http://localhost:5081/api/dashboard/summary
```

## Segurança e governança

- Não usar dados reais de clientes.
- Não citar clínicas reais.
- Não versionar secrets.
- Não versionar banco local.
- Não versionar arquivos pessoais ou temporários.
- Manter escopo incremental por sprint.

## Licença

Distribuído sob licença MIT. Consulte o arquivo [LICENSE](LICENSE).
