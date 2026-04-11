# Plano de Testes de Usabilidade

Os testes de usabilidade permitem avaliar a qualidade da interface com o usuário da aplicação interativa WeDo, garantindo que o sistema atenda ao propósito de centralizar e facilitar o acompanhamento de metas pessoais.

## Definição dos objetivos

Antes de iniciar os testes, é essencial definir o que se deseja avaliar na usabilidade do sistema WeDo. Os principais objetivos deste teste são:

- Verificar se os usuários conseguem registrar, categorizar e acompanhar metas sem dificuldades de navegação.
- Avaliar se a interface do Dashboard e do Mural de Conquistas comunica o progresso de forma clara e motivacional.
- Identificar barreiras na atualização diária de status das atividades, garantindo que o processo seja rápido e não desencoraje o uso contínuo.
- Validar a eficácia dos filtros de categoria na organização da visão do usuário.

## Seleção dos participantes

Para garantir que o teste reflita o uso real do sistema, os participantes foram selecionados com base nas personas do projeto (estudantes, jovens adultos e profissionais com metas ativas).

**Critérios para selecionar participantes:**
- **Perfil A (Foco em Produtividade/Estudos):** Estudantes universitários que buscam organizar rotinas acadêmicas e visualizar progresso.
- **Perfil B (Foco em Hábitos/Saúde):** Pessoas interessadas em manter a consistência de atividades físicas ou alimentação.
- **Perfil C (Foco em Gestão/Finanças):** Jovens adultos que precisam conciliar diferentes áreas da vida (freelancers, profissionais liberais).
- Diferentes níveis de familiaridade com ferramentas digitais de organização (desde usuários de planilhas até iniciantes).

**Quantidade recomendada:**
O teste será conduzido com **5 a 8 participantes**, garantindo diversidade suficiente para identificar os principais gargalos de interação.

## Definição de cenários de teste

Nesta etapa, os voluntários executarão cinco tarefas baseadas em fluxos reais de uso do sistema WeDo. Nenhuma assistência direta deve ser fornecida durante a execução para não invalidar os dados.

**Cenário 1: Cadastro e Primeiro Acesso**
- **Objetivo:** Avaliar a fluidez do processo de onboarding e criação de conta (RF-001, RF-002).
- **Contexto:** Você é um estudante que acabou de conhecer o WeDo e quer usar a plataforma para organizar seus estudos e rotina.
- **Tarefa:** Acessar a tela inicial, preencher os dados de cadastro (Nome, E-mail e Senha) e realizar o primeiro login para acessar o Dashboard.
- **Critério de sucesso:** O usuário conclui o cadastro e chega ao Dashboard sem erros de validação ou confusão sobre onde clicar.

**Cenário 2: Registro de uma Nova Meta com Categoria**
- **Objetivo:** Validar a facilidade de criação de uma meta e atribuição de categorias (RF-005, RF-006).
- **Contexto:** Você decidiu criar um hábito diário de leitura e precisa registrar isso no sistema para não esquecer.
- **Tarefa:** Navegar até a tela de "Registro de Atividades", criar uma meta chamada "Leitura Diária", adicionar uma motivação, vinculá-la à categoria "Estudos" e salvá-la.
- **Critério de sucesso:** A meta é registrada corretamente e o usuário visualiza a confirmação de que ela foi adicionada ao sistema.

**Cenário 3: Atualização de Status Diário**
- **Objetivo:** Avaliar a usabilidade do Dashboard para gestão rápida de tarefas cotidianas (RF-007, RF-009).
- **Contexto:** Você acabou de voltar da academia e quer registrar que cumpriu sua meta de exercícios de hoje para manter seu histórico positivo.
- **Tarefa:** No Dashboard, na seção "O que fazer hoje?", localizar a atividade de treino e alterar seu status para "Concluído".
- **Critério de sucesso:** O usuário identifica a atividade pendente rapidamente e consegue alterar o status através dos indicadores visuais (cores/checkbox) em menos de 1 minuto.

**Cenário 4: Organização e Filtragem de Metas**
- **Objetivo:** Testar a clareza visual e o funcionamento da organização por categorias na visão estratégica (RF-008).
- **Contexto:** Você está planejando seu orçamento do mês e quer focar apenas nos seus objetivos financeiros, ocultando as metas de saúde e estudos.
- **Tarefa:** Acessar a página de "Metas" e utilizar a ferramenta de filtro para exibir exclusivamente as metas da categoria "Finanças".
- **Critério de sucesso:** O usuário encontra a opção de filtro facilmente e a interface atualiza exibindo apenas os cards corretos.

**Cenário 5: Verificação de Progresso no Mural**
- **Objetivo:** Verificar a eficácia da tela de recompensas e registro histórico (RF-011).
- **Contexto:** Você acabou de finalizar o pagamento da última parcela de uma dívida, concluindo totalmente uma grande meta financeira.
- **Tarefa:** Após marcar a meta como concluída, navegar até o "Mural de Conquistas" e verificar se ela aparece na sua lista de vitórias.
- **Critério de sucesso:** O usuário navega até o Mural sem dificuldades e identifica visualmente o card da sua meta finalizada.

## Métodos de coleta de dados

Durante a execução dos cenários, o moderador do teste observará silenciosamente e registrará o comportamento do usuário. Serão coletados os seguintes dados:

**1. Métricas Quantitativas:**
- **Tempo de conclusão:** Tempo cronometrado para a execução de cada cenário.
- **Taxa de sucesso:** Se o usuário concluiu a tarefa com sucesso, com sucesso parcial (precisou de dicas) ou falhou.
- **Quantidade de cliques/erros:** Número de vezes que o usuário clicou em áreas não clicáveis ou acessou telas erradas antes de encontrar o caminho certo.

**2. Métricas Qualitativas:**
- **Think Aloud (Pensar em voz alta):** Os usuários serão encorajados a verbalizar seus pensamentos, frustrações e expectativas enquanto navegam.
- **Questionário Pós-Teste:** Aplicação de perguntas curtas após a sessão para medir a satisfação geral:
  - *A interface foi fácil de entender?*
  - *Você encontrou dificuldades na organização das suas metas?*
  - *As cores e ícones ajudaram a identificar o status das tarefas?*

**Conformidade com a LGPD:**
Nenhum dado sensível ou de identificação pessoal (como nome completo, CPF ou e-mail real) dos voluntários será armazenado ou exposto nos relatórios finais. Os participantes serão identificados apenas por códigos (ex: Voluntário 01, Voluntário 02), garantindo total privacidade e anonimato.
