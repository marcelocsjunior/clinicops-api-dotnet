# Exemplos de requisições — ClinicOps API .NET

> Exemplos fictícios para validação local e demonstração do case.

## Convenções previstas

Base URL local futura:

```text
http://localhost:5081
```

Formato padrão:

```http
Content-Type: application/json
Accept: application/json
```

## GET /api/status

Verifica se a API está operacional.

### Requisição

```http
GET /api/status HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta planejada

```json
{
  "status": "ok",
  "service": "ClinicOps API",
  "environment": "Development",
  "timestampUtc": "2026-06-02T12:00:00Z"
}
```

## POST /api/clinics

Cria uma clínica ou unidade operacional fictícia.

### Requisição

```http
POST /api/clinics HTTP/1.1
Host: localhost:5081
Content-Type: application/json
Accept: application/json
```

```json
{
  "name": "Clínica Exemplo Norte",
  "city": "Cidade Exemplo",
  "state": "MG",
  "isActive": true
}
```

### Resposta planejada

```json
{
  "id": 1,
  "name": "Clínica Exemplo Norte",
  "city": "Cidade Exemplo",
  "state": "MG",
  "isActive": true,
  "createdAt": "2026-06-02T12:00:00Z",
  "updatedAt": null
}
```

## GET /api/clinics

Lista clínicas ou unidades cadastradas.

### Requisição

```http
GET /api/clinics HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta planejada

```json
[
  {
    "id": 1,
    "name": "Clínica Exemplo Norte",
    "city": "Cidade Exemplo",
    "state": "MG",
    "isActive": true,
    "createdAt": "2026-06-02T12:00:00Z",
    "updatedAt": null
  }
]
```

## POST /api/assets

Cria um ativo ou equipamento vinculado a uma clínica.

### Requisição

```http
POST /api/assets HTTP/1.1
Host: localhost:5081
Content-Type: application/json
Accept: application/json
```

```json
{
  "clinicId": 1,
  "name": "Servidor de Arquivos Exemplo",
  "assetType": "Server",
  "serialNumber": "SN-DEMO-0001",
  "location": "Sala Técnica",
  "isActive": true
}
```

### Resposta planejada

```json
{
  "id": 1,
  "clinicId": 1,
  "name": "Servidor de Arquivos Exemplo",
  "assetType": "Server",
  "serialNumber": "SN-DEMO-0001",
  "location": "Sala Técnica",
  "isActive": true,
  "createdAt": "2026-06-02T12:05:00Z",
  "updatedAt": null
}
```

## GET /api/assets

Lista ativos cadastrados.

### Requisição

```http
GET /api/assets HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta planejada

```json
[
  {
    "id": 1,
    "clinicId": 1,
    "name": "Servidor de Arquivos Exemplo",
    "assetType": "Server",
    "serialNumber": "SN-DEMO-0001",
    "location": "Sala Técnica",
    "isActive": true,
    "createdAt": "2026-06-02T12:05:00Z",
    "updatedAt": null
  }
]
```

## POST /api/tickets

Abre um chamado técnico.

### Requisição

```http
POST /api/tickets HTTP/1.1
Host: localhost:5081
Content-Type: application/json
Accept: application/json
```

```json
{
  "clinicId": 1,
  "assetId": 1,
  "title": "Falha de acesso ao compartilhamento de arquivos",
  "description": "Usuários relatam lentidão e erro intermitente ao acessar pasta compartilhada.",
  "priority": "High"
}
```

### Resposta planejada

```json
{
  "id": 1,
  "clinicId": 1,
  "assetId": 1,
  "title": "Falha de acesso ao compartilhamento de arquivos",
  "description": "Usuários relatam lentidão e erro intermitente ao acessar pasta compartilhada.",
  "priority": "High",
  "status": "Open",
  "openedAt": "2026-06-02T12:10:00Z",
  "closedAt": null,
  "createdAt": "2026-06-02T12:10:00Z",
  "updatedAt": null
}
```

## GET /api/tickets

Lista chamados técnicos.

### Requisição

```http
GET /api/tickets HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta planejada

```json
[
  {
    "id": 1,
    "clinicId": 1,
    "assetId": 1,
    "title": "Falha de acesso ao compartilhamento de arquivos",
    "priority": "High",
    "status": "Open",
    "openedAt": "2026-06-02T12:10:00Z",
    "closedAt": null
  }
]
```

## PUT /api/tickets/{id}

Atualiza dados principais de um chamado.

### Requisição

```http
PUT /api/tickets/1 HTTP/1.1
Host: localhost:5081
Content-Type: application/json
Accept: application/json
```

```json
{
  "title": "Falha de acesso ao compartilhamento de arquivos",
  "description": "Erro validado em estação específica. Atendimento em andamento.",
  "priority": "High",
  "status": "InProgress"
}
```

### Resposta planejada

```json
{
  "id": 1,
  "clinicId": 1,
  "assetId": 1,
  "title": "Falha de acesso ao compartilhamento de arquivos",
  "description": "Erro validado em estação específica. Atendimento em andamento.",
  "priority": "High",
  "status": "InProgress",
  "openedAt": "2026-06-02T12:10:00Z",
  "closedAt": null,
  "createdAt": "2026-06-02T12:10:00Z",
  "updatedAt": "2026-06-02T12:30:00Z"
}
```

## DELETE /api/tickets/{id}

Remove ou desativa um chamado, conforme decisão futura de implementação.

### Requisição

```http
DELETE /api/tickets/1 HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta planejada

```http
204 No Content
```

## POST /api/technicians

Cria um técnico fictício.

### Requisição

```http
POST /api/technicians HTTP/1.1
Host: localhost:5081
Content-Type: application/json
Accept: application/json
```

```json
{
  "fullName": "Técnico Demo",
  "email": "tecnico.demo@example.com",
  "isActive": true
}
```

### Resposta esperada

```json
{
  "id": 1,
  "fullName": "Técnico Demo",
  "email": "tecnico.demo@example.com",
  "isActive": true,
  "createdAt": "2026-06-02T12:40:00Z",
  "updatedAt": null
}
```

## GET /api/technicians

Lista técnicos cadastrados.

### Requisição

```http
GET /api/technicians HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta esperada

```json
[
  {
    "id": 1,
    "fullName": "Técnico Demo",
    "email": "tecnico.demo@example.com",
    "isActive": true,
    "createdAt": "2026-06-02T12:40:00Z",
    "updatedAt": null
  }
]
```

## POST /api/maintenance-logs

Registra uma manutenção em ativo com técnico responsável.

### Requisição

```http
POST /api/maintenance-logs HTTP/1.1
Host: localhost:5081
Content-Type: application/json
Accept: application/json
```

```json
{
  "assetId": 1,
  "technicianId": 1,
  "description": "Manutenção preventiva registrada para demonstração"
}
```

### Resposta esperada

```json
{
  "id": 1,
  "assetId": 1,
  "assetName": "Ultrassom Demo",
  "technicianId": 1,
  "technicianName": "Técnico Demo",
  "description": "Manutenção preventiva registrada para demonstração",
  "performedAt": "2026-06-02T12:45:00Z",
  "createdAt": "2026-06-02T12:45:00Z"
}
```

## GET /api/maintenance-logs

Lista registros de manutenção.

### Requisição

```http
GET /api/maintenance-logs HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta esperada

```json
[
  {
    "id": 1,
    "assetId": 1,
    "assetName": "Ultrassom Demo",
    "technicianId": 1,
    "technicianName": "Técnico Demo",
    "description": "Manutenção preventiva registrada para demonstração",
    "performedAt": "2026-06-02T12:45:00Z",
    "createdAt": "2026-06-02T12:45:00Z"
  }
]
```

## GET /api/dashboard/summary

Retorna resumo operacional simples.

### Requisição

```http
GET /api/dashboard/summary HTTP/1.1
Host: localhost:5081
Accept: application/json
```

### Resposta planejada

```json
{
  "totalClinics": 1,
  "activeClinics": 1,
  "totalAssets": 1,
  "activeAssets": 1,
  "totalTickets": 5,
  "openTickets": 2,
  "inProgressTickets": 1,
  "closedTickets": 2,
  "totalTechnicians": 1,
  "activeTechnicians": 1,
  "totalMaintenanceLogs": 1,
  "lastUpdatedUtc": "2026-06-02T13:00:00Z"
}
```

## Fluxo operacional de demonstração

```bash
curl -X POST http://localhost:5081/api/clinics \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Unidade Demo",
    "city": "Cidade Demo",
    "state": "SC",
    "isActive": true
  }'

curl -X POST http://localhost:5081/api/assets \
  -H "Content-Type: application/json" \
  -d '{
    "clinicId": 1,
    "name": "Ultrassom Demo",
    "assetType": "MedicalEquipment",
    "serialNumber": "SN-DEMO-0001",
    "location": "Sala Demo",
    "isActive": true
  }'

curl -X POST http://localhost:5081/api/technicians \
  -H "Content-Type: application/json" \
  -d '{
    "fullName": "Técnico Demo",
    "email": "tecnico.demo@example.com",
    "isActive": true
  }'

curl -X POST http://localhost:5081/api/maintenance-logs \
  -H "Content-Type: application/json" \
  -d '{
    "assetId": 1,
    "technicianId": 1,
    "description": "Manutenção preventiva registrada para demonstração"
  }'

curl http://localhost:5081/api/dashboard/summary
```

## Observações de governança

- Todos os exemplos são fictícios.
- Nenhum dado real de cliente deve ser usado.
- Nomes de clínicas, ativos e números de série são demonstrativos.
- Os contratos poderão ser ajustados durante a implementação.
- A documentação deverá acompanhar a evolução real dos endpoints.
