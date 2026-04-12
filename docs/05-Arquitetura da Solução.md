# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

O sistema WeDo é composto pelas seguintes classes principais:

- **Usuario** — representa o usuário da plataforma, com atributos como `id`, `nome`, `email`, `senhaHash`, `areaFoco` e `dataCadastro`, e métodos de cadastro, edição de perfil e autenticação.
- **Atividade** — registra as atividades realizadas pelo usuário, com `descricao`, `data`, `fotoUrl`, `status` e referências a `usuarioId` e `categoriaId`.
- **Meta** — define as metas do usuário, com `descricao`, `prazo`, `status` e o campo `conquistaMural` para conquistas no mural.
- **Categoria** — agrupa atividades e metas por categoria, com métodos de busca e listagem.
- **HistoricoAtividade** — mantém o histórico de atividades vinculadas ao usuário, com suporte a filtros por categoria e período.
- **Notificacao** — gerencia notificações enviadas ao usuário, com controle de leitura e tipo.

![Diagrama de Classes - WeDo](img/diagrama_classes_WeDo.jpg)

## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

O diagrama abaixo apresenta as entidades **usuario**, **atividade**, **meta**, **categoria**, **historico_atividade** e **notificacao**, e seus respectivos relacionamentos:

- Um **usuario** *Registra* N **atividade**s, *Define* N **meta**s e *Recebe* N **notificacao**s.
- Uma **atividade** e uma **meta** *Pertencem a* uma **categoria**.
- O **historico_atividade** é *Gerado* a partir das atividades e *Referencia* uma **categoria**.

![Diagrama de Entidade Relacionamento - WeDo](img/%5BWedo%5D%20-%20DIAGRAMA%20DE%20ENTIDADE%20RELACIONAMENTO.jpg)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.

O esquema abaixo detalha as tabelas do sistema e seus atributos:

| Tabela | Colunas principais |
|---|---|
| **usuario** | `id PK`, `nome VARCHAR(100)`, `email UNIQUE`, `senha_hash VARCHAR(150)`, `area_foco VARCHAR(100)`, `data_cadastro DATE` |
| **atividade** | `id PK`, `usuario_id FK`, `categoria_id FK`, `descricao VARCHAR(500)`, `data DATE`, `foto_url VARCHAR(500)`, `status VARCHAR(30)` |
| **meta** | `id PK`, `usuario_id FK`, `categoria_id FK`, `descricao VARCHAR(500)`, `prazo VARCHAR(100)`, `status VARCHAR(20)`, `conquista_mural BOOLEAN` |
| **categoria** | `id PK`, `nome VARCHAR(50)`, `descricao VARCHAR(300)` |
| **historico_atividade** | `id PK`, `usuario_id FK`, `atividade_id FK`, `categoria_id FK`, `data_registro DATETIME` |
| **notificacao** | `id PK`, `usuario_id FK`, `mensagem VARCHAR(500)`, `data_envio DATETIME`, `lida BOOLEAN`, `tipo VARCHAR(30)` |

![Projeto de Base de Dados - WeDo](img/Projeto%20base%20de%20dados.jpeg)

## ATENÇÃO!!!

Os três artefatos — **Diagrama de Classes, Modelo ER e Projeto da Base de Dados** — devem ser desenvolvidos de forma sequencial e integrada, garantindo total coerência e compatibilidade entre eles. O diagrama de classes orienta a estrutura e o comportamento do software; o modelo ER traduz essa estrutura para o nível conceitual dos dados; e o projeto da base de dados materializa essas definições no formato físico (tabelas, colunas, chaves e restrições). A construção isolada ou desconexa desses elementos pode gerar inconsistências, dificultar a implementação e comprometer a qualidade do sistema.

## Tecnologias Utilizadas

#  Planejamento e Arquitetura do Sistema

Este repositório contém a documentação técnica e o código-fonte da solução desenvolvida em **C#/.NET**. O sistema foi projetado para gerenciar atividades, metas e notificações com foco em performance e escalabilidade.

---

##  Stack Tecnológica

Abaixo, as tecnologias e ferramentas selecionadas para a implementação:

### **Backend & Lógica de Negócio**
* **Linguagem:** C# (C-Sharp)
* **Framework:** ASP.NET Core Web API
* **Acesso a Dados:** Entity Framework Core (ORM)
* **Segurança:** BCrypt (para Hash de senhas) e JWT para autenticação.

### **Frontend (Interface)**
* **Framework:** React.js ou Blazor
* **Estilização:** CSS3 / Tailwind CSS
* **Comunicação:** Axios ou Fetch API (JSON/HTTP)

### **Banco de Dados**
* **SGBD:** SQL Server ou PostgreSQL
* **Modelagem:** Relacional com integridade referencial.

### **Ferramentas & Design**
* **IDE:** Visual Studio 2022 ou VS Code
* **Prototipagem:** Figma (UI/UX)
* **Modelagem de Dados:** draw.io e Lucidchart
* **Testes de API:** Postman

---

##  Arquitetura e Fluxo de Dados

O projeto segue uma arquitetura multicamadas, garantindo a separação de responsabilidades:

1.  **Client (Front-end):** Interação do usuário e visualização dos resultados.
2.  **Server (Back-end):** Processamento das requisições, validação de dados e regras de negócio.
3.  **Database (Persistência):** Armazenamento seguro e estruturado das informações.

---

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
