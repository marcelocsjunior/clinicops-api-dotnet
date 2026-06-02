# Roteiro para banca — ClinicOps API .NET

## Pitch de 1 minuto

> O ClinicOps API .NET é meu segundo case de portfólio em .NET. Enquanto o MentorLab API trabalha o domínio educacional e serve como base direta para a aula teste, o ClinicOps aplica ASP.NET Core Web API em um domínio operacional real: chamados técnicos, ativos e manutenção em clínicas e ambientes corporativos. A proposta é demonstrar que consigo usar a mesma base de back-end .NET em contextos distintos, com organização, documentação e visão prática de mercado.

## Como explicar o projeto na banca

A explicação deve seguir uma linha simples e forte:

1. **Contexto**: clínicas e empresas dependem de tecnologia para operar.
2. **Problema**: chamados, ativos e manutenções normalmente ficam espalhados em planilhas, conversas e memória operacional.
3. **Solução**: API REST para organizar esse fluxo em entidades, endpoints e persistência.
4. **Tecnologia**: ASP.NET Core Web API, C#, EF Core, SQLite e Swagger.
5. **Valor técnico**: demonstra Controller, DTO, Service, DI, persistência e contrato REST.
6. **Valor prático**: conecta desenvolvimento back-end com operação real de suporte técnico.

## Conexão com experiência real

Este case conversa diretamente com experiência prática em:

- suporte técnico em ambientes clínicos;
- infraestrutura crítica;
- manutenção de estações, servidores e equipamentos;
- organização de chamados e evidências;
- gestão de ativos;
- necessidade de rastreabilidade em atendimento técnico;
- visão de continuidade operacional.

A defesa não deve citar clientes reais nem dados reais. O discurso deve ficar no domínio genérico: clínicas, ambientes corporativos, ativos e chamados técnicos.

## Narrativa recomendada

> Eu escolhi o ClinicOps como segundo case porque ele representa um domínio operacional que conheço bem: suporte técnico, ativos, manutenção e ambientes clínicos. A ideia não é fazer apenas mais um CRUD, mas mostrar como uma API REST pode estruturar um fluxo real de operação: clínica, equipamento, chamado, técnico responsável, manutenção e dashboard. Isso prova que consigo aplicar ASP.NET Core Web API em contextos diferentes, mantendo organização, documentação e visão de produto.

## Perguntas prováveis da banca

### 1. Por que criar um segundo projeto se o MentorLab já cobre API REST?

Resposta-base:

> Porque os dois cases têm domínios diferentes. O MentorLab é educacional e conversa diretamente com a aula teste. O ClinicOps é operacional e demonstra aplicação da mesma base técnica em suporte, ativos e manutenção. Isso mostra transferência de conhecimento e capacidade de modelar problemas diferentes com .NET.

### 2. O ClinicOps não é apenas outro CRUD?

Resposta-base:

> A base técnica inclui CRUD, mas o diferencial está no domínio e na modelagem operacional. O projeto trabalha relação entre clínica, ativo, chamado, técnico e manutenção. Além disso, prevê dashboard de resumo operacional, status de chamados, prioridade e rastreabilidade de atendimento.

### 3. Por que usar SQLite no MVP?

Resposta-base:

> SQLite reduz dependência externa, facilita demonstração local e permite validar EF Core rapidamente. Para evolução corporativa, o caminho natural é SQL Server, mas no MVP o foco é clareza, portabilidade e apresentação objetiva.

### 4. Por que não começar com Clean Architecture completa?

Resposta-base:

> Para o MVP e para a banca, uma arquitetura em camadas simples é mais objetiva. Ela permite explicar bem Controller, DTO, Service, DI e EF Core sem excesso de abstrações. Se o projeto crescer, a separação pode evoluir para Domain, Application, Infrastructure e API.

### 5. Como você garante que não está usando dados reais?

Resposta-base:

> O projeto usa apenas dados fictícios e domínio genérico. Não há nomes reais de clínicas, clientes, equipamentos ou chamados. O objetivo é demonstrar competência técnica sem expor informações sensíveis.

### 6. O que esse projeto demonstra tecnicamente?

Resposta-base:

> Demonstra construção de API REST com ASP.NET Core, organização em camadas, uso de DTOs, serviços injetados por DI, persistência com EF Core, documentação com Swagger, modelagem relacional e evolução incremental por sprints.

### 7. Como o dashboard será construído?

Resposta-base:

> O dashboard será um endpoint de resumo operacional, consolidando informações como total de chamados, chamados abertos, encerrados, ativos cadastrados e unidades ativas. A proposta inicial é simples, mas suficiente para mostrar agregação e leitura operacional dos dados.

### 8. Como diferenciar prioridade e status de chamados?

Resposta-base:

> Prioridade indica urgência ou impacto do chamado. Status indica etapa do fluxo, como aberto, em andamento, resolvido ou fechado. Essa separação ajuda a organizar operação e priorização técnica.

## Como diferenciar este case do MentorLab API .NET

| Critério | MentorLab API .NET | ClinicOps API .NET |
|---|---|---|
| Domínio | Educação e aprendizagem | Operação técnica e manutenção |
| Problema | Organizar alunos, trilhas, exercícios e feedbacks | Organizar clínicas, ativos, chamados e manutenções |
| Conexão com a aula | Base direta para a aula teste | Segundo case para mostrar versatilidade |
| Narrativa | Ensino, mentoria e trilhas educacionais | Suporte técnico, infraestrutura e ambientes clínicos |
| Valor demonstrado | Didática e domínio educacional | Experiência operacional e visão prática de mercado |

## Fala curta para defesa

> No MentorLab eu demonstro o domínio educacional, alinhado à aula teste. No ClinicOps eu demonstro o domínio operacional, conectado à minha experiência prática em infraestrutura e suporte técnico. Os dois usam .NET, mas resolvem problemas diferentes. Isso mostra que não estou apenas repetindo código: estou aplicando arquitetura de API em contextos distintos.

## Riscos que podem ser citados com maturidade

- Escopo crescer demais e perder objetividade.
- Misturar dados reais no projeto.
- Transformar o MVP em arquitetura excessivamente complexa.
- Criar entidades demais antes de validar o fluxo principal.
- Falta de testes em fases iniciais.

## Como responder aos riscos

> A estratégia é controlar o escopo por sprints, começar com documentação, depois criar bootstrap, depois implementar tickets e só então evoluir para ativos, clínicas, manutenção e dashboard. Assim o projeto cresce com rastreabilidade e sem bagunça operacional.