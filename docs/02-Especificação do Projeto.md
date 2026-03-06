# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

# Personas

### Persona 1 - Lucas Ferreira

| | | |
|---|---|---|
| ![Lucas Ferreira](./img/lucas.jpeg) | **Lucas Ferreira** <br> _"Estudo muito, mas no fim do mês não sei o que realmente aprendi."_ | **Idade:** 21 anos <br> **Profissão:** Estudante de ADS + Estagiário <br> **Localização:** São Paulo, SP <br> **Formação:** Graduação em Análise e Desenvolvimento de Sistemas <br> **Objetivo:** Acompanhar sua evolução técnica e manter consistência nos estudos |

| Descrição | Dores | Expectativas |
|---|---|---|
| Lucas tem uma rotina intensa entre aulas, estágio e projetos pessoais. Apaixonado por programação, consome muito conteúdo técnico, mas tem dificuldade em transformar esse esforço em metas claras e mensuráveis. Já tentou Notion, Trello e planilhas para se organizar, mas abandona tudo em poucas semanas por não enxergar progresso concreto. | Não consegue mensurar sua própria evolução ao longo do tempo. As ferramentas que já tentou são genéricas e não oferecem uma visão integrada do seu desenvolvimento. Sem registro histórico, suas conquistas diárias passam despercebidas, gerando a sensação constante de que não está evoluindo. | Registrar suas sessões de estudo com descrição e categoria. Acompanhar no dashboard quanto tempo e esforço dedicou a cada área ao longo do tempo. Ter um histórico verificável das suas atividades que comprove - inclusive para si mesmo - que está evoluindo de forma consistente. |

---

### Persona 2 - Beatriz Souza

| | | |
|---|---|---|
| ![Beatriz Souza](./img/beatriz.jpeg) | **Beatriz Souza** <br> _"Começo animada, mas sem ver resultado, desisto antes de criar o hábito."_ | **Idade:** 23 anos <br> **Profissão:** Estudante de Nutrição + Estagiária <br> **Localização:** Belo Horizonte, MG <br> **Formação:** Graduação em Nutrição <br> **Objetivo:** Manter hábitos saudáveis com consistência e visualizar sua evolução |

| Descrição | Dores | Expectativas |
|---|---|---|
| Beatriz tenta conciliar faculdade, estágio e manter uma rotina de cuidados com a saúde. É disciplinada nas primeiras semanas, mas sem uma forma clara de visualizar seu progresso, perde a motivação rapidamente. Não tem um registro estruturado das suas atividades, o que faz com que pequenas conquistas diárias sejam esquecidas ou desvalorizadas. | Sem um histórico visual do que já conquistou, tem dificuldade em perceber sua própria evolução. A ausência de um registro concreto faz com que a sensação de "não estar avançando" prevaleça, mesmo quando está mantendo bons hábitos. Ferramentas genéricas não atendem à especificidade das suas metas de saúde. | Registrar atividades de saúde com descrição e foto como prova concreta do que realizou. Acompanhar no dashboard a frequência e consistência dos seus hábitos ao longo das semanas. Ter um histórico que reforce sua percepção de progresso e a motive a continuar. |

---

### Persona 3 - Rafael Mendes

| | | |
|---|---|---|
| ![Rafael Mendes](./img/rafael.jpeg) | **Rafael Mendes** <br> _"Sei que preciso me organizar financeiramente, mas nunca sei por onde começar."_ | **Idade:** 26 anos <br> **Profissão:** Analista Júnior em Logística <br> **Localização:** Curitiba, PR <br> **Formação:** Tecnólogo em Gestão Empresarial <br> **Objetivo:** Controlar melhor seus gastos e criar metas financeiras alcançáveis |

| Descrição | Dores | Expectativas |
|---|---|---|
| Rafael tem renda fixa, mas dificuldade crônica em planejar seus gastos. Já tentou aplicativos financeiros tradicionais, mas os abandona rapidamente - sente que são punitivos, apenas evidenciam erros e não oferecem nenhuma sensação de conquista ao acertar. Não tem uma visão clara de onde seu dinheiro vai nem de como está evoluindo financeiramente. | Aplicativos financeiros tradicionais são entediantes e focados no erro, não na conquista. Sem uma forma de registrar e acompanhar metas financeiras de forma positiva e estruturada, o planejamento sempre fica em segundo plano. A falta de uma visão consolidada impede que ele perceba seu próprio progresso. | Registrar metas financeiras e acompanhar sua evolução ao longo do tempo. Ter um dashboard que mostre de forma clara e visual onde está acertando e onde precisa melhorar. Perceber conquistas financeiras - como ter ficado dentro do orçamento - de forma concreta e registrada. |

---

### Persona 4 - Camila Torres

| | | |
|---|---|---|
| ![Camila Torres](./img/camila.jpeg) | **Camila Torres** <br> _"Quero crescer em tudo ao mesmo tempo e acabo não enxergando progresso em nada."_ | **Idade:** 24 anos <br> **Profissão:** Freelancer de Design Gráfico <br> **Localização:** Recife, PE <br> **Formação:** Graduação em Design + Pós-graduação EAD <br> **Objetivo:** Ter uma visão integrada e equilibrada de todas as áreas da sua vida |

| Descrição | Dores | Expectativas |
|---|---|---|
| Camila tem total autonomia sobre seu tempo como freelancer, o que é uma liberdade e um desafio. Sem estrutura externa, alterna entre dias extremamente produtivos e dias completamente parados. Tem metas em diferentes áreas - saúde, aprendizado e finanças - mas cada uma registrada em um lugar diferente, sem uma visão consolidada do conjunto. | Sem uma plataforma única, perde o fio condutor entre suas diferentes metas. A falta de uma visão integrada faz com que não perceba desequilíbrios - como estar evoluindo muito profissionalmente enquanto negligencia saúde e finanças. O progresso existe, mas está invisível e fragmentado. | Centralizar metas de diferentes áreas em uma única plataforma. Usar o dashboard por categoria para enxergar onde está investindo energia e onde está negligenciando. Ter um histórico de atividades que funcione como um retrato fiel do seu equilíbrio pessoal ao longo do tempo. |

---

### Persona 5 - André Lima

| | | |
|---|---|---|
| ![André Lima](./img/andre.jpeg) | **André Lima** <br> _"Treino todo dia, mas sem registro, parece que o esforço some."_ | **Idade:** 20 anos <br> **Profissão:** Estudante de Educação Física <br> **Localização:** Porto Alegre, RS <br> **Formação:** Graduação em Educação Física (em andamento) <br> **Objetivo:** Documentar sua consistência nos treinos e acompanhar sua evolução física |

| Descrição | Dores | Expectativas |
|---|---|---|
| André é altamente disciplinado com seus treinos, mas não tem o hábito de registrá-los de forma estruturada. Sem um histórico organizado, perde a percepção da sua própria consistência ao longo do tempo e não consegue identificar padrões - como períodos de queda de desempenho ou de maior evolução. O esforço existe, mas é invisível até para ele mesmo. | A ausência de um registro estruturado faz com que seu progresso seja percebido apenas de forma subjetiva. Sem dados históricos, é difícil identificar o que está funcionando e ajustar sua rotina de treinos com base em evidências concretas. Sente que o esforço diário se perde sem deixar rastro. | Registrar treinos com descrição, categoria e foto como prova concreta do que realizou. Acompanhar no dashboard a frequência e evolução dos seus treinos ao longo das semanas. Ter um histórico que evidencie sua consistência e permita identificar padrões na sua rotina de atividades físicas. |

# Histórias de Usuários

### Autenticação e Perfil

| EU COMO... `PERSONA` | QUERO/PRECISO... `FUNCIONALIDADE` | PARA... `MOTIVO/VALOR` |
|---|---|---|
| Lucas Ferreira | Criar minha conta informando nome, e-mail, senha e minha área de foco principal | Ter um perfil personalizado que reflita minha principal área de desenvolvimento |
| Lucas Ferreira | Fazer login com meu e-mail e senha | Acessar minhas metas e histórico de atividades de forma segura |
| Camila Torres | Editar meu perfil e atualizar minha área de foco | Manter meus dados atualizados conforme meus objetivos evoluem ao longo do tempo |

### Registro e Gestão de Atividades

| EU COMO... `PERSONA` | QUERO/PRECISO... `FUNCIONALIDADE` | PARA... `MOTIVO/VALOR` |
|---|---|---|
| André Lima | Registrar uma atividade informando categoria, descrição e data | Documentar meus treinos de forma estruturada e construir um histórico confiável |
| Beatriz Souza | Anexar uma foto ao registrar uma atividade | Ter uma prova concreta do que realizei e reforçar minha percepção de progresso |
| Lucas Ferreira | Editar ou excluir uma atividade registrada incorretamente | Manter meu histórico de conquistas preciso e confiável |
| Camila Torres | Categorizar cada atividade registrada entre saúde, estudos e finanças | Organizar meu progresso por área e ter uma visão clara de onde estou me dedicando |

### Histórico e Acompanhamento

| EU COMO... `PERSONA` | QUERO/PRECISO... `FUNCIONALIDADE` | PARA... `MOTIVO/VALOR` |
|---|---|---|
| Beatriz Souza | Acessar o histórico completo das minhas atividades registradas | Revisar minha trajetória e reconhecer conquistas que poderiam passar despercebidas |
| André Lima | Visualizar minhas atividades organizadas por data | Identificar padrões na minha rotina e períodos de maior ou menor consistência |
| Rafael Mendes | Registrar metas financeiras e acompanhar seu andamento | Ter controle sobre meu planejamento financeiro de forma estruturada e positiva |

### Dashboard e Relatórios

| EU COMO... `PERSONA` | QUERO/PRECISO... `FUNCIONALIDADE` | PARA... `MOTIVO/VALOR` |
|---|---|---|
| Camila Torres | Visualizar um dashboard com minhas atividades distribuídas por categoria | Enxergar de forma clara quais áreas da vida estou equilibrando ou negligenciando |
| Rafael Mendes | Ver um resumo do meu desempenho na categoria finanças | Acompanhar minha evolução financeira e perceber conquistas que antes eram invisíveis |
| Lucas Ferreira | Acompanhar o total de atividades registradas por categoria ao longo do tempo | Ter evidências concretas do meu progresso e manter a motivação para continuar |
| André Lima | Visualizar a frequência dos meus treinos registrados no dashboard | Confirmar minha consistência com dados reais e ajustar minha rotina quando necessário |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir o cadastro de usuários (Nome, E-mail, Senha e Skill).| ALTA | 
|RF-002| A aplicação deve permitir validar o login do usuário cadastrado.    | ALTA |
|RF-003| A aplicação deve permitir a edição dos dados do perfil e skill principal. | ALTA |
|RF-004| A aplicação deve permitir a busca de outros usuários por nome para amizade. | MÉDIA |
|RF-005| A aplicação deve permitir enviar e aceitar solicitações de amizade. | ALTA |
|RF-006| A aplicação deve permitir a exclusão de um amigo da lista de contatos.| MÉDIA |
|RF-007| A aplicação deve permitir o registro de uma atividade contendo categoria, descrição, data e XP gerado automaticamente.| ALTA |
|RF-008| A aplicação deve permitir o upload de uma foto como prova da atividade.| ALTA |
|RF-009| A aplicação deve permitir marcar amigos em uma atividade comum (Tagging).| ALTA |
|RF-010| A aplicação deve distribuir automaticamente o XP da atividade para todos os usuários marcados.| ALTA |
|RF-011| A aplicação deve permitir exibir uma listagem (Feed) das atividades dos amigos.| MÉDIA |
|RF-012| A aplicação deve permitir que o usuário visualize o histórico de suas atividades registradas.| ALTA |
|RF-013| A aplicação deve permitir gerar um Ranking Global ordenado pelo XP total.| ALTA |
|RF-014| A aplicação deve permitir filtrar o ranking por Categorias específicas.| MÉDIA |
|RF-015| A aplicação deve permitir exibir um Dashboard com o total de XP por categoria do usuário.| MÉDIA |
|RF-016| A aplicação deve permitir que o usuário exclua ou edite atividades previamente registradas.| ALTA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser responsiva | MÉDIA | 
|RNF-002| A aplicação deve processar requisições do usuário em no máximo 3s |  ALTA | 
|RNF-003| O back-end deve ser desenvolvido em C# com .NET Core. |  ALTA | 
|RNF-004| Os dados devem ser persistidos em SQL Server ou MySQL. |  ALTA | 
|RNF-005| As senhas devem ser criptografadas. |  ALTA | 
|RNF-006|O sistema deve manter integridade referencial entre as entidades do banco de dados. |  ALTA | 
|RNF-007| O sistema deve retornar mensagens claras em caso de falha de conexão. |  ALTA | 
|RNF-008|O sistema deve utilizar o Entity Framework Core como ferramenta de mapeamento objeto-relacional (ORM).|ALTA| 
|RNF-009| A aplicação deve restringir o acesso às funcionalidades apenas para usuários autenticados. |  ALTA | 
|RNF-010| A aplicação deve validar os dados inseridos pelo usuário antes de salvar no banco de dados. |  ALTA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
