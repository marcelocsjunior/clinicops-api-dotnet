# Arquitetura — ClinicOps API .NET

## Visão geral

O **ClinicOps API .NET** será uma API REST construída com ASP.NET Core Web API para gestão operacional de clínicas e ambientes corporativos.

O foco arquitetural do MVP é entregar uma estrutura clara, incremental e fácil de defender em banca, cobrindo os fundamentos esperados de um back-end .NET moderno:

- Controllers REST;
- DTOs de entrada e saída;
- Services com regras de negócio;
- Dependency Injection;
- Entity Framework Core;
- persistência com SQLite no MVP;
- documentação via Swagger/OpenAPI.

## Princípios técnicos

- **Simplicidade intencional**: começar enxuto para entregar valor e reduzir ruído técnico.
- **Separação de responsabilidades**: cada camada com papel bem definido.
- **Evolução incremental**: cada sprint adiciona uma capacidade real e validável.
- **Contrato REST claro**: endpoints previsíveis e documentados.
- **Persistência controlada**: SQLite no MVP e possibilidade futura de SQL Server.
- **Domínio operacional realista**: chamados, ativos, clínicas, técnicos e manutenção.
- **Governança de portfólio**: sem dados reais, sem secrets e sem complexidade gratuita.

## Separação por camadas

### Controllers

Responsáveis por expor os endpoints HTTP, receber requisições, validar o fluxo básico e retornar respostas padronizadas.

Exemplo futuro:

```text
TicketsController
AssetsController
ClinicsController
MaintenanceLogsController
DashboardController
```

### DTOs

Responsáveis pelos contratos de entrada e saída da API.

A API não deverá expor entidades internas diretamente quando houver risco de acoplamento ou necessidade de modelar melhor os contratos.

Exemplos futuros:

```text
CreateTicketRequest
UpdateTicketRequest
TicketResponse
CreateAssetRequest
ClinicResponse
DashboardSummaryResponse
```

### Services

Responsáveis pelas regras de negócio e orquestração entre controller e persistência.

Exemplos:

- abrir chamado;
- atualizar status;
- encerrar chamado;
- validar vínculo entre ativo e clínica;
- consolidar dados para dashboard.

### Models

Representam as entidades principais do domínio.

Entidades previstas:

- Clinic;
- Asset;
- Ticket;
- Technician;
- MaintenanceLog.

### Data

Camada responsável pela persistência com EF Core.

Itens previstos:

- `ClinicOpsDbContext`;
- configuração do SQLite;
- DbSets das entidades;
- migrations em sprint futura.

## Estrutura de pastas futura

```text
clinicops-api-dotnet/
  ClinicOps.sln
  README.md
  LICENSE
  .gitignore
  docs/
    arquitetura.md
    roteiro-banca.md
    exemplos-requisicoes.md
    portfolio-case.md
    roadmap.md
  src/
    ClinicOps.Api/
      Controllers/
        StatusController.cs
        ClinicsController.cs
        AssetsController.cs
        TicketsController.cs
        MaintenanceLogsController.cs
        DashboardController.cs
      Data/
        ClinicOpsDbContext.cs
      DTOs/
        Clinics/
        Assets/
        Tickets/
        MaintenanceLogs/
        Dashboard/
      Models/
        Clinic.cs
        Asset.cs
        Ticket.cs
        Technician.cs
        MaintenanceLog.cs
      Services/
        Interfaces/
        Implementations/
      Program.cs
      appsettings.json
      appsettings.Development.json
```

## Entidades principais

### Clinic

Representa uma clínica, unidade ou ambiente corporativo atendido.

Campos planejados:

- Id
- Name
- City
- State
- IsActive
- CreatedAt
- UpdatedAt

### Asset

Representa um ativo técnico, equipamento, computador, servidor, impressora, estação ou equipamento relacionado à operação.

Campos planejados:

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

Representa um chamado técnico aberto para uma clínica ou ativo.

Campos planejados:

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

Representa o técnico responsável por atendimentos e manutenções.

Campos planejados:

- Id
- FullName
- Email
- IsActive
- CreatedAt
- UpdatedAt

### MaintenanceLog

Representa o histórico de manutenção realizada em um ativo.

Campos planejados:

- Id
- AssetId
- TechnicianId
- Description
- PerformedAt
- CreatedAt

## Decisões técnicas iniciais

### .NET 8

Escolhido por ser uma versão moderna, estável e adequada para Web APIs atuais.

### ASP.NET Core Web API

Escolhido por ser o padrão direto para construção de APIs REST no ecossistema .NET.

### SQLite no MVP

Escolhido para simplificar execução local, demonstração em banca e validação rápida do projeto sem dependência de servidor externo de banco de dados.

### SQL Server em evolução futura

Previsto como evolução natural para ambiente corporativo ou produção, mantendo aderência ao ecossistema Microsoft.

### Swagger/OpenAPI

Obrigatório para demonstrar contrato da API, facilitar testes e apresentar endpoints na banca técnica.

### xUnit em fase posterior

Será introduzido quando os fluxos principais estiverem implementados, evitando teste prematuro sobre modelo ainda instável.

## Justificativa de simplicidade arquitetural

O MVP precisa demonstrar domínio técnico sem virar laboratório de arquitetura excessiva.

A estrutura em camadas simples permite explicar com clareza:

- o papel do Controller;
- a função dos DTOs;
- onde fica a regra de negócio;
- como a injeção de dependência organiza os serviços;
- como o EF Core persiste os dados;
- como o Swagger documenta a API.

Essa abordagem é mais adequada para uma apresentação técnica objetiva, porque reduz distrações e concentra a defesa nos fundamentos de back-end.

## Decisão de não usar Clean Architecture completa no MVP

A Clean Architecture completa não será usada inicialmente.

Motivos:

- aumentaria a quantidade de projetos e abstrações antes de haver necessidade real;
- criaria mais cerimônia do que valor para o escopo inicial;
- poderia dificultar a apresentação didática na banca;
- o objetivo da primeira versão é demonstrar fundamentos sólidos, não complexidade ornamental.

A evolução futura pode extrair camadas adicionais caso o projeto cresça, por exemplo:

```text
ClinicOps.Domain
ClinicOps.Application
ClinicOps.Infrastructure
ClinicOps.Api
```

No MVP, a decisão técnica é pragmática: arquitetura simples, coesa e fácil de manter.