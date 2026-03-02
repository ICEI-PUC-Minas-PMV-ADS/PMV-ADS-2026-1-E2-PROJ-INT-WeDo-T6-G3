# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

Identifique, em torno de, 5 personas. Para cada persona, lembre-se de descrever suas angústicas, frustrações e expectativas de vida relacionadas ao problema. Além disso, defina uma "aparência" para a persona. Para isso, você poderá utilizar sites como [https://this-person-does-not-exist.com/pt#google_vignette](https://this-person-does-not-exist.com/pt) ou https://thispersondoesnotexist.com/ 

### Persona 1,Lucas Ferreira

| | | |
|---|---|---|
| ![Lucas Ferreira]() | **Lucas Ferreira** _"Quero evoluir, mas fico me comparando com quem está em outro nível."_ | **Idade:** 21 anos **Profissão:** Estudante de ADS + Estagiário **Localização:** São Paulo, SP **Formação:** Graduação em Análise e Desenvolvimento de Sistemas **Objetivo:** Manter consistência nos estudos e mensurar sua evolução técnica |

| Descrição | Dores | Expectativas |
|---|---|---|
| Lucas tem uma rotina intensa entre aulas, estágio e projetos pessoais. Apaixonado por programação, consome muito conteúdo técnico no YouTube e Discord. Apesar do esforço, tem dificuldade em perceber seu próprio progresso e tende a se comparar com perfis de devs nas redes sociais, o que frequentemente o desmotiva. | Sente que estuda muito, mas não consegue mensurar sua evolução de forma concreta. Já tentou Notion, Trello e planilhas, mas abandona em poucas semanas. A comparação com influenciadores tech o faz sentir permanentemente "para trás", desvalorizando suas conquistas reais do dia a dia. | Registrar sessões de estudo e acompanhar o XP acumulado ao longo do tempo. Competir em um ranking de estudos com amigos do curso,não com estranhos da internet. Usar a foto como prova de que concluiu uma tarefa e ter visibilidade sobre sua própria evolução por categoria. |

---

### Persona 2,Beatriz Souza

| | | |
|---|---|---|
| ![Beatriz Souza]() | **Beatriz Souza** _"Fico animada no começo, mas sem alguém pra me cobrar, desisto."_ | **Idade:** 23 anos **Profissão:** Estudante de Nutrição + Estagiária **Localização:** Belo Horizonte, MG **Formação:** Graduação em Nutrição **Objetivo:** Manter hábitos saudáveis com consistência junto às amigas |

| Descrição | Dores | Expectativas |
|---|---|---|
| Beatriz tenta conciliar faculdade, estágio e academia. Tem um grupo de amigas que também busca manter uma rotina saudável, mas a comunicação fica dispersa em grupos de WhatsApp. Quando a motivação de uma cai, o grupo todo tende a parar junto, sem nenhum mecanismo de retomada. | Sente falta de accountability real,ninguém "segura" o grupo quando a motivação cai. Não tem como saber se as amigas estão mantendo os hábitos, e seu esforço individual acaba sendo invisível para quem ela se importa. Ferramentas individuais não resolvem um problema coletivo. | Acompanhar o feed de atividades das amigas em tempo real. Marcar as colegas quando forem juntas à academia e dividir o XP da conquista. Ter um registro visual (foto) das atividades do grupo e sentir que seu esforço é reconhecido pelo círculo social mais próximo. |

---

### Persona 3,Rafael Mendes

| | | |
|---|---|---|
| ![Rafael Mendes]() | **Rafael Mendes** _"Gasto demais no fim de semana e me arrependo,mas também não quero parar de sair."_ | **Idade:** 26 anos **Profissão:** Analista Júnior em Logística **Localização:** Curitiba, PR **Formação:** Tecnólogo em Gestão Empresarial **Objetivo:** Equilibrar vida social ativa com responsabilidade financeira |

| Descrição | Dores | Expectativas |
|---|---|---|
| Rafael tem uma vida social ativa e valoriza os momentos de lazer com os amigos. Porém, os gastos nos fins de semana comprometem frequentemente seu planejamento mensal. Já tentou aplicativos financeiros tradicionais, mas os abandona rapidamente por sentir que eles só mostram o que ele errou, sem nenhum estímulo positivo. | Aplicativos financeiros são entediantes e punitivos: apenas evidenciam os erros sem oferecer recompensa por acertos. Não há incentivo para registrar conquistas financeiras, como ter ficado dentro do orçamento. Sente que os amigos também lidam mal com finanças, mas o tema é tabu no grupo. | Ganhar XP ao registrar que ficou dentro do orçamento em um fim de semana. Ver que os amigos também tentam equilibrar lazer e responsabilidade, normalizando a conversa sobre finanças. Competir de forma leve e sem julgamento em um ranking da categoria financeira. |

---

### Persona 4,Camila Torres

| | | |
|---|---|---|
| ![Camila Torres]() | **Camila Torres** _"Quero crescer em tudo ao mesmo tempo e acabo não evoluindo em nada."_ | **Idade:** 24 anos **Profissão:** Freelancer de Design Gráfico **Localização:** Recife, PE **Formação:** Graduação em Design + Pós-graduação EAD **Objetivo:** Ter uma visão integrada e equilibrada de todas as áreas da vida |

| Descrição | Dores | Expectativas |
|---|---|---|
| Camila tem total autonomia sobre seu tempo como freelancer, o que é uma liberdade e um desafio. Sem estrutura externa, alterna entre dias ultra produtivos e dias completamente parados. Usa diversas ferramentas digitais no trabalho (Figma, Adobe Suite), mas nenhuma integra sua vida pessoal, profissional e de saúde de forma social e gamificada. | Sente que evolui em áreas isoladas, mas não tem uma visão do conjunto de sua vida. Trabalha sozinha e sente falta de um grupo que compartilhe o mesmo ritmo de crescimento. Não tem métricas para avaliar se está equilibrando estudos, trabalho e saúde ao longo do tempo. | Usar o Dashboard por categoria para enxergar onde está investindo mais energia e onde está negligenciando. Conectar-se com outros freelancers e estudantes EAD em situação parecida. Ter a "teia de vida" como espelho visual do seu equilíbrio individual comparado ao do grupo. |

---

### Persona 5,André Lima

| | | |
|---|---|---|
| ![André Lima]() | **André Lima** _"Treino todo dia, mas ninguém sabe disso,e isso me desmotiva."_ | **Idade:** 20 anos **Profissão:** Estudante de Educação Física **Localização:** Porto Alegre, RS **Formação:** Graduação em Educação Física (em andamento) **Objetivo:** Manter consistência nos treinos e inspirar pessoas próximas pelo exemplo |

| Descrição | Dores | Expectativas |
|---|---|---|
| André é altamente disciplinado com seus treinos e frequentemente serve de referência entre os amigos em assuntos de saúde e atividade física. Porém, sente que seu esforço diário passa despercebido. Usa o Instagram eventualmente para registrar progresso, mas o ambiente da rede social valoriza aparência, não constância. | Seu esforço cotidiano é invisível para o círculo social. As redes sociais tradicionais valorizam resultado estético e não consistência. Sente dificuldade em motivar os amigos a adotarem hábitos saudáveis, pois não há uma plataforma compartilhada que torne o progresso de todos visível e comparável. | Registrar treinos com fotos como prova de presença e receber reconhecimento do grupo por consistência. Marcar amigos que treinaram juntos e distribuir o XP coletivamente. Usar o ranking de saúde para motivar o círculo de amigos de forma leve e colaborativa, sem o peso julgador das redes sociais convencionais. |

---

Utilize também como referência o exemplo abaixo:

<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" alt="Persona1"/>

Enumere e detalhe as personas da sua solução. Para tanto, baseie-se tanto nos documentos disponibilizados na disciplina e/ou nos seguintes links:

> **Links Úteis**:
> 
> - [Rock Content](https://rockcontent.com/blog/personas/)
> - [Hotmart](https://blog.hotmart.com/pt-br/como-criar-persona-negocio/)
> - [O que é persona?](https://resultadosdigitais.com.br/blog/persona-o-que-e/)
> - [Persona x Público-alvo](https://flammo.com.br/blog/persona-e-publico-alvo-qual-a-diferenca/)
> - [Mapa de Empatia](https://resultadosdigitais.com.br/blog/mapa-da-empatia/)
> - [Mapa de Stalkeholders](https://www.racecomunicacao.com.br/blog/como-fazer-o-mapeamento-de-stakeholders/)
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Ana Clara  | Uma forma de identificar se uma agência é realmente confiável           | Me sentir mais segura ao contratar seus serviços               |
|Ana Clara       | Ter um mecanismo eficiente e rápido de comunicação                 | Que eu possa sanar todas as minhas dúvidas rapidamente |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

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
