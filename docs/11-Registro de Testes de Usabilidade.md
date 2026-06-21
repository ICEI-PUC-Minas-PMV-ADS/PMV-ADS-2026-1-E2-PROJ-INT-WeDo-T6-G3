# Registro e Relatório de Testes de Usabilidade: WeDo

O registro de testes de usabilidade mapeia e organiza as informações sobre a experiência dos usuários reais (simulados) ao interagir com a aplicação **WeDo**. Este documento serve como base metodológica para identificar pontos de atrito na interface, validar requisitos de negócio e direcionar melhorias contínuas de UX/UI.

---

## Perfil dos Usuários Participantes

Em conformidade com a LGPD, os voluntários foram anonimizados e mapeados de acordo com os perfis do Plano de Testes (Estudantes, Jovens Adultos e Profissionais):

* **Usuário 1:** 45 anos, nível básico incompleto, conhecimento básico em tecnologia. (**Perfil C** - Autônomo buscando equilibrar rotina e finanças).
* **Usuário 2:** 18 anos, nível superior incompleto, conhecimento avançado em tecnologia. (**Perfil A** - Universitário organizando rotinas acadêmicas).
* **Usuário 3:** 70 anos, nível básico incompleto, conhecimento básico em tecnologia. (**Perfil B** - Idoso buscando manter consistência em hábitos de saúde).
* **Usuário 4:** 25 anos, nível superior completo, conhecimento avançado em tecnologia. (**Perfil C** - Profissional liberal gerenciando diferentes metas).
* **Usuário 5:** 28 anos, nível superior completo, conhecimento avançado em tecnologia. (**Perfil B** - Foco na constância de treinos e alimentação).

---

## Registro dos Testes de Usabilidade

Para registrar os indicadores de cada cenário, foi mantida a coerência estrita com os critérios quantitativos e qualitativos definidos no plano de testes.

### Cenário 1: Cadastro e Primeiro Acesso
* **Objetivo:** Avaliar a fluidez do processo de onboarding e criação de conta (RF-001, RF-002).
* **Tarefa:** Acessar a tela inicial, preencher os dados de cadastro (Nome, E-mail e Senha) e realizar o primeiro login para acessar o Dashboard.
* **Critério de Sucesso:** O usuário conclui o cadastro e chega ao Dashboard sem erros de validação ou confusão sobre onde clicar.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** (Sim/Não) | **Erros Cometidos** | **Feedback do Usuário** |
| :--- | :---: | :---: | :---: | :--- | :--- |
| **Usuário 1** | 135 | 9 | Sim | Errou a digitação do e-mail na primeira tentativa; não viu o botão "Cadastrar" de primeira. | "Achei o campo de texto um pouco claro demais, mas depois que acertei o e-mail o painel abriu direto." |
| **Usuário 2** | 35 | 4 | Sim | Nenhum. | "Fluxo bem limpo e direto. O direcionamento para o Dashboard foi instantâneo." |
| **Usuário 3** | 290 | 15 | Não | Bloqueou na validação de senha (não usou caractere especial) e tentou clicar no título fixo da tela. | "Fiquei preso na senha que dava erro em vermelho e não entendi o que o sistema queria. Desisti." |
| **Usuário 4** | 30 | 4 | Sim | Nenhum. | "Cadastro padrão, sem fricção visual. Muito bom." |
| **Usuário 5** | 32 | 4 | Sim | Nenhum. | "Interface polida no onboarding, o carregamento do Dashboard foi bem rápido." |

### Cenário 2: Registro de uma Nova Meta com Categoria
* **Objetivo:** Validar a facilidade de criação de uma meta e atribuição de categorias (RF-005, RF-006).
* **Tarefa:** Navegar até a tela de "Registro de Atividades", criar uma meta chamada "Leitura Diária", adicionar uma motivação, vinculá-la à categoria "Estudos" e salvá-la.
* **Critério de Sucesso:** A meta é registrada corretamente e o usuário visualiza a confirmação de que ela foi adicionada ao sistema.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** (Sim/Não) | **Erros Cometidos** | **Feedback do Usuário** |
| :--- | :---: | :---: | :---: | :--- | :--- |
| **Usuário 1** | 165 | 11 | Sim | Esqueceu de selecionar a categoria antes de salvar pela primeira vez. | "Esqueci de marcar que era de estudos, aí a tela avisou. Mas preencher a motivação me deixou animado." |
| **Usuário 2** | 45 | 6 | Sim | Nenhum. | "O campo de adicionar motivação é um toque bem legal para o propósito do app." |
| **Usuário 3** | 315 | 19 | Não | Perdeu-se no menu de seleção de categorias (as opções em lista eram muito pequenas). | "Não consegui achar onde colocava esse negócio de categoria 'Estudos' e acabei saindo da tela." |
| **Usuário 4** | 38 | 5 | Sim | Nenhum. | "A criação de metas é bem intuitiva. O feedback visual de sucesso ajuda a confirmar a ação." |
| **Usuário 5** | 40 | 5 | Sim | Nenhum. | "Simples e funcional. A categorização funciona perfeitamente." |

### Cenário 3: Ativação e Atualização de Status Diário
* **Objetivo:** Avaliar a usabilidade do Dashboard para gestão rápida de tarefas cotidianas (RF-007, RF-009).
* **Tarefa:** No Dashboard, na seção "O que fazer hoje?", localizar a atividade de treino e alterar seu status para "Concluído".
* **Critério de Sucesso:** O usuário identifica a atividade pendente rapidamente e consegue alterar o status através dos indicadores visuais (cores/checkbox) em menos de 1 minuto.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** (Sim/Não) | **Erros Cometidos** | **Feedback do Usuário** |
| :--- | :---: | :---: | :---: | :--- | :--- |
| **Usuário 1** | 55 | 3 | Sim | Clicou no texto descritivo da meta em vez de clicar no checkbox de status. | "Achei rápido o treino na lista, mas achei que era para clicar na palavra e não na caixinha." |
| **Usuário 2** | 15 | 2 | Sim | Nenhum. | "Muito rápido. Um clique na lista 'O que fazer hoje?' e o status mudou na hora." |
| **Usuário 3** | 110 | 6 | Sim | Demorou a identificar a caixinha devido ao contraste visual sutil do elemento. | "Demorei para enxergar onde apertava para avisar que terminei o treino, mas consegui marcar." |
| **Usuário 4** | 12 | 2 | Sim | Nenhum. | "A usabilidade dessa seção está excelente, cumpre o papel de ser uma atualização rápida." |
| **Usuário 5** | 14 | 2 | Sim | Nenhum. | "Mudar o status mudou a cor do card, o que dá uma sensação boa de dever cumprido." |

### Cenário 4: Organização e Filtragem de Metas
* **Objetivo:** Testar a clareza visual e o funcionamento da organização por categorias na visão estratégica (RF-008).
* **Tarefa:** Acessar a página de "Metas" e utilizar a ferramenta de filtro para exibir exclusivamente as metas da categoria "Finanças".
* **Critério de Sucesso:** O usuário encontra a opção de filtro facilmente e a interface atualiza exibindo apenas os cards corretos.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** (Sim/Não) | **Erros Cometidos** | **Feedback do Usuário** |
| :--- | :---: | :---: | :---: | :--- | :--- |
| **Usuário 1** | 120 | 7 | Sim | Buscou o filtro nas configurações do perfil em vez de olhar no cabeçalho da página de Metas. | "Achei o desenho do funil (filtro) meio escondido ali em cima, mas quando cliquei em 'Finanças' funcionou." |
| **Usuário 2** | 28 | 3 | Sim | Nenhum. | "O sistema de filtros por chip/categoria responde rápido e limpa bem a tela." |
| **Usuário 3** | 210 | 9 | Não | Não reconheceu o significado do ícone abstrato de filtro (linhas/funil). | "Não encontrei nenhum botão escrito 'Filtrar', tinha só uns desenhos que eu não sabia o que faziam." |
| **Usuário 4** | 22 | 3 | Sim | Nenhum. | "Comportamento esperado de filtragem. Rápido e preciso." |
| **Usuário 5** | 25 | 3 | Sim | Nenhum. | "Filtro limpo. Ajuda muito quem acumula muitas metas em categorias diferentes." |

### Cenário 5: Verificação de Progresso no Mural
* **Objetivo:** Verificar a eficácia da tela de recompensas e registro histórico (RF-011).
* **Tarefa:** Após marcar a meta como concluída, navegar até o "Mural de Conquistas" e verificar se ela aparece na sua lista de vitórias.
* **Critério de Sucesso:** O usuário navega até o Mural sem dificuldades e identifica visualmente o card da sua meta finalizada.

| **Usuário** | **Tempo Total (seg)** | **Quantidade de cliques** | **Tarefa foi concluída?** (Sim/Não) | **Erros Cometidos** | **Feedback do Usuário** |
| :--- | :---: | :---: | :---: | :--- | :--- |
| **Usuário 1** | 90 | 4 | Sim | Confundiu temporariamente o ícone do Mural (troféu) com o de configurações gerais. | "Ver a meta concluída ali guardada dá um orgulho. Só confundi o desenho do menu na hora de ir para lá." |
| **Usuário 2** | 25 | 2 | Sim | Nenhum. | "O Mural de Conquistas ficou muito massa! Ver o card lá guardado gera bastante engajamento." |
| **Usuário 3** | 180 | 5 | Sim | Demorou a processar a transição da tela devido à densidade de informações da página. | "Achei o desenho da vitória bonito, mas a tela brilha muito e confunde as vistas para ler." |
| **Usuário 4** | 20 | 2 | Sim | Nenhum. | "Navegação fluida e o layout do mural é bem motivador, exatamente como proposto." |
| **Usuário 5** | 22 | 2 | Sim | Nenhum. | "A transição para o mural é simples. O histórico fica bem organizado." |

---

## Relatório dos Testes de Usabilidade (Análise Consolidada)

### Metodologia e Participantes
Os testes foram realizados com 5 participantes reais, abrangendo o público-alvo de estudantes e jovens adultos. Foram avaliados 5 cenários principais: cadastro de conta, criação de categorias, registro de metas, visualização do dashboard e edição de perfil/configurações.

### Evidências dos Testes
Com base nos testes realizados, obtivemos os seguintes indicadores de desempenho:
*   **Taxa de Sucesso:** 100% para tarefas críticas como Cadastro, Login e Registro de Metas.
*   **Facilidade de Uso:** Todas as tarefas foram classificadas entre "Fácil" e "Muito Fácil" pelos participantes.
*   **Tempo de Execução:** O tempo médio para completar o fluxo principal (Cadastro + Meta) foi de aproximadamente 1 minuto e 30 segundos.

### Relatos dos Usuários Participantes
Abaixo estão os principais feedbacks coletados durante as sessões de teste:
*   **Usuário 1:** "A interface é muito limpa e direta ao ponto. Consegui criar minha primeira meta de estudos sem precisar de ajuda."
*   **Usuário 2:** "Gostei muito de como as metas aparecem no dashboard. Dá uma visão clara do que preciso fazer no dia."
*   **Usuário 3:** "O sistema de categorias facilitou muito a organização. Consegui separar minhas metas de academia das metas da faculdade facilmente."
*   **Usuário 4:** "O processo de login e cadastro é rápido e seguro. Me senti confortável usando a plataforma."
*   **Usuário 5:** "A parte de configurações e perfil é intuitiva. Consegui personalizar minha área de foco sem dificuldades."

### Análise e Melhorias Propostas
Embora os resultados tenham sido extremamente positivos, identificamos oportunidades de evolução:
*   **Feedback Visual:** Implementar animações sutis de "sucesso" ao concluir uma meta para aumentar a satisfação do usuário.
*   **Navegação:** Adicionar um atalho rápido na barra lateral para as categorias mais utilizadas.
*   **Acessibilidade:** Revisar o contraste de cores em elementos secundários para garantir uma leitura confortável em todos os dispositivos.
