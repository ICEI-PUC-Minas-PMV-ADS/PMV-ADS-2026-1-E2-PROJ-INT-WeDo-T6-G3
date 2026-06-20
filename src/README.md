# Código Fonte - WeDo

Esta pasta contém o código-fonte da aplicação **WeDo**, desenvolvida como parte do projeto de Desenvolvimento de uma Aplicação Interativa do 2° semestre de Análise e Desenvolvimento de Sistemas.

## 🛠 Stack Tecnológica

Diferente das versões iniciais, a aplicação foi implementada utilizando as seguintes tecnologias:

*   **Linguagem:** C#
*   **Framework Web:** ASP.NET Core MVC (com Razor Views)
*   **Banco de Dados:** SQL Server (Entity Framework Core)
*   **Autenticação:** Sistema baseado em Cookies (Microsoft.AspNetCore.Authentication.Cookies)
*   **Estilização:** CSS3 e Bootstrap 5
*   **Recursos Adicionais:** Localização (i18n) para Português, Inglês e Espanhol.

## 📂 Estrutura do Projeto

*   **/Controllers**: Contém a lógica de controle da aplicação (Usuários, Metas, Notificações, etc.).
*   **/Models**: Define as entidades do sistema (Usuario, Meta, Categoria, Notificacao) e o Contexto do Banco de Dados (`AppDbContext`).
*   **/Views**: Contém as páginas da interface do usuário escritas em Razor (HTML + C#).
*   **/Services**: Serviços auxiliares para envio de E-mail e processamento de Notificações automáticas.
*   **/Resources**: Arquivos de tradução (`.resx`) para suporte a múltiplos idiomas.
*   **/wwwroot**: Arquivos estáticos como CSS, JavaScript e bibliotecas (jQuery, Bootstrap).

## 🚀 Como Executar o Projeto

### Pré-requisitos
*   Visual Studio 2022 (com a carga de trabalho "Desenvolvimento Web e ASP.NET") ou VS Code com o C# Dev Kit.
*   .NET SDK (versão compatível com o projeto, recomendada 8.0 ou superior).
*   SQL Server (ou SQL Server Express LocalDB).

### Passos para execução
1.  Abra o arquivo de solução (`WeDo.sln`) no Visual Studio.
2.  Verifique a string de conexão no arquivo `appsettings.json`. Por padrão, o projeto utiliza `(localdb)\\mssqllocaldb`.
3.  Abra o **Console do Gerenciador de Pacotes** e execute o comando para criar o banco de dados:
    ```bash
    Update-Database
    ```
4.  Pressione `F5` ou clique no botão de execução para iniciar a aplicação.
5.  O navegador abrirá automaticamente na tela de Login.

## 📝 Histórico de Versões

### [1.0.0] - 20/06/2026
#### Adicionado
- Implementação completa do CRUD de Metas e Categorias.
- Sistema de autenticação por cookies e gerenciamento de perfil.
- Dashboard interativo com lista de tarefas diárias.
- Sistema de notificações automáticas para prazos e conquistas.
- Suporte a múltiplos idiomas (PT-BR, EN-US, ES-ES).
- Recuperação de senha via e-mail.
