# Roadmap — ClinicOps API .NET

## Visão geral

O roadmap do **ClinicOps API .NET** foi organizado em sprints curtas, com entregas incrementais e fáceis de validar em banca técnica.

A estratégia é começar com documentação, depois bootstrap da API, depois domínio principal de chamados, e só então evoluir para ativos, clínicas, manutenção e dashboard.

## Sprint 0 — Baseline documental

### Objetivo

Preparar o repositório como segundo case .NET do portfólio, com documentação inicial clara e defensável.

### Entregas

- README completo.
- Documento de arquitetura.
- Roteiro para banca.
- Exemplos planejados de requisições.
- Resumo do case para portfólio.
- Roadmap técnico.
- Issue criada.
- Branch criada.
- Pull Request aberto para revisão.

### Restrições

- Não criar código .NET.
- Não criar solution.
- Não criar projeto ASP.NET Core.
- Não criar EF Core ou migrations.
- Não usar dados reais.

## Sprint 1 — Bootstrap ASP.NET Core Web API + Swagger

### Objetivo

Criar a base executável da API.

### Entregas previstas

- `ClinicOps.sln`.
- Projeto `src/ClinicOps.Api`.
- ASP.NET Core Web API em .NET 8.
- Swagger/OpenAPI.
- Endpoint `GET /api/status`.
- README atualizado com comandos de execução.

### Critérios de aceite previstos

- `dotnet restore` OK.
- `dotnet build` OK.
- API sobe localmente.
- Swagger acessível.
- `/api/status` retorna resposta válida.

## Sprint 2 — Tickets API com Controller, DTO, Service, DI e EF Core

### Objetivo

Implementar o primeiro fluxo de negócio: chamados técnicos.

### Entregas previstas

- Entidade `Ticket`.
- DTOs de criação, atualização e resposta.
- `TicketsController`.
- `TicketService`.
- Interface de serviço.
- Configuração inicial de EF Core.
- Persistência SQLite.
- Endpoints principais de tickets.

### Endpoints previstos

```http
GET    /api/tickets
GET    /api/tickets/{id}
POST   /api/tickets
PUT    /api/tickets/{id}
DELETE /api/tickets/{id}
```

## Sprint 3 — Assets e Clinics

### Objetivo

Adicionar unidades e ativos/equipamentos para dar contexto operacional aos chamados.

### Entregas previstas

- Entidade `Clinic`.
- Entidade `Asset`.
- DTOs de clinics e assets.
- Controllers de clinics e assets.
- Services de clinics e assets.
- Relacionamento entre ativo e clínica.
- Ajuste nos chamados para vínculo operacional.

### Endpoints previstos

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

## Sprint 4 — Maintenance Logs e Dashboard

### Objetivo

Adicionar histórico de manutenção e visão consolidada da operação.

### Entregas previstas

- Entidade `Technician`.
- Entidade `MaintenanceLog`.
- Registro de manutenção por ativo.
- Associação com técnico responsável.
- Endpoint de dashboard operacional.

### Endpoints previstos

```http
GET    /api/maintenance-logs
POST   /api/maintenance-logs

GET    /api/dashboard/summary
```

### Métricas planejadas para dashboard

- Total de clínicas.
- Clínicas ativas.
- Total de ativos.
- Ativos ativos.
- Total de chamados.
- Chamados abertos.
- Chamados em andamento.
- Chamados encerrados.

## Sprint 5 — Qualidade, testes e documentação final

### Objetivo

Fechar o MVP com maturidade técnica para apresentação.

### Entregas previstas

- Revisão de README.
- Revisão de documentação em `docs/`.
- Exemplos atualizados conforme implementação real.
- Testes automatizados com xUnit.
- Melhorias de validação.
- GitHub Actions em fase posterior, se fizer sentido.
- Preparação de narrativa final para banca.

## Estratégia de evolução

O projeto deve evoluir sem salto arquitetural desnecessário.

Ordem recomendada:

1. Documentar.
2. Subir API mínima.
3. Implementar domínio principal: tickets.
4. Adicionar contexto: clinics e assets.
5. Adicionar histórico: maintenance logs.
6. Consolidar visão: dashboard.
7. Refinar qualidade e documentação.

## Fora de escopo inicial

- Autenticação e autorização.
- Multi-tenant avançado.
- Front-end.
- Deploy cloud.
- Integração com sistemas reais.
- Dados reais de clientes.
- Clean Architecture completa.
- Mensageria.
- Observabilidade avançada.

Esses itens podem ser avaliados após o MVP, caso agreguem valor ao portfólio sem roubar foco da banca técnica.