# Portfolio Case — ClinicOps API .NET

## Nome do case

**ClinicOps API .NET**

Repositório:

```text
https://github.com/marcelocsjunior/clinicops-api-dotnet
```

## Problema resolvido

Clínicas e ambientes corporativos dependem de tecnologia para manter a operação funcionando. Na prática, chamados técnicos, ativos, equipamentos, manutenções e responsáveis muitas vezes ficam distribuídos em planilhas, mensagens, memória operacional ou ferramentas sem integração.

O ClinicOps API .NET propõe uma base de API REST para organizar esse fluxo de forma estruturada:

- unidades atendidas;
- ativos e equipamentos;
- chamados técnicos;
- técnicos responsáveis;
- registros de manutenção;
- resumo operacional para acompanhamento.

## Domínio de negócio

O domínio é **operação técnica em clínicas e ambientes corporativos**.

O projeto conversa com cenários como:

- suporte técnico interno ou terceirizado;
- infraestrutura de TI;
- inventário de equipamentos;
- manutenção preventiva e corretiva;
- registro de evidências de atendimento;
- priorização de chamados;
- visão executiva simples da operação.

## Tecnologias previstas

- .NET 8
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite no MVP
- SQL Server em evolução futura
- Swagger / OpenAPI
- xUnit em fase posterior
- GitHub Actions em fase posterior

## Funcionalidades planejadas

- Endpoint de status da API.
- CRUD de clínicas/unidades.
- CRUD de ativos/equipamentos.
- CRUD de chamados técnicos.
- Registro de manutenções.
- Associação entre ativo, clínica, técnico e manutenção.
- Dashboard operacional simples.
- Documentação de endpoints via Swagger/OpenAPI.

## Diferencial técnico

O diferencial técnico está em demonstrar uma API REST com estrutura profissional e incremental:

- organização em camadas simples;
- uso de DTOs para contratos de API;
- Services para regras de negócio;
- Dependency Injection;
- persistência com EF Core;
- modelagem relacional entre entidades;
- documentação técnica e exemplos de requisições;
- evolução por issues, branches e pull requests.

## Diferencial operacional

O diferencial operacional é conectar desenvolvimento back-end com um domínio prático de mercado.

O projeto simula uma demanda comum em ambientes críticos: registrar, acompanhar e organizar chamados técnicos e ativos. Essa visão aproxima o case de problemas reais enfrentados em clínicas, empresas e operações de suporte.

O foco não é apenas cadastrar dados, mas estruturar informação operacional útil para tomada de decisão.

## Diferença para o MentorLab API .NET

| Projeto | Domínio | Objetivo |
|---|---|---|
| MentorLab API .NET | Educacional | Organizar alunos, trilhas, exercícios e feedbacks |
| ClinicOps API .NET | Operacional | Organizar clínicas, ativos, chamados e manutenção |

O MentorLab é o case diretamente conectado à aula teste. O ClinicOps é o segundo case, criado para demonstrar versatilidade técnica em outro domínio.

## Como comprovar na banca

A comprovação pode ser feita por:

- repositório público no GitHub;
- README estruturado;
- documentação técnica em `docs/`;
- issues por sprint;
- branches por entrega;
- pull requests com histórico de evolução;
- Swagger/OpenAPI quando a API for implementada;
- exemplos de requisições;
- endpoint funcional de status na Sprint 1;
- CRUDs implementados nas sprints seguintes.

## Narrativa para banca

> O ClinicOps API .NET é meu segundo case de portfólio em .NET. Enquanto o MentorLab API trabalha o domínio educacional e serve como base direta para a aula teste, o ClinicOps aplica ASP.NET Core Web API em um domínio operacional real: chamados técnicos, ativos e manutenção em clínicas e ambientes corporativos. A proposta é demonstrar que consigo usar a mesma base de back-end .NET em contextos distintos, com organização, documentação e visão prática de mercado.

## Status do case

```text
Sprint atual: Sprint 0 — Baseline documental
Implementação de código: ainda não iniciada
API funcional: planejada para Sprint 1
MVP operacional: planejado até Sprint 5
```

## Cuidados de segurança

- Não usar nomes reais de clínicas.
- Não usar dados reais de clientes.
- Não publicar secrets.
- Não versionar banco local.
- Não versionar arquivos temporários.
- Não transformar exemplos fictícios em evidência real.

## Link do repositório

```text
https://github.com/marcelocsjunior/clinicops-api-dotnet
```