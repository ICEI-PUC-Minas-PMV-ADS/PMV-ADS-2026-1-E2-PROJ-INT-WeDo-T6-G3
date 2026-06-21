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

## Relatório dos Testes de Usabilidade (Análise Consolidada)

### 1. Métricas Quantitativas Gerais

* **Taxa de Sucesso por Cenário:**
    * Cenário 1 (Cadastro e Login): **80%** (4 de 5 concluíram)
    * Cenário 2 (Criar Meta por Categoria): **80%** (4 de 5 concluíram)
    * Cenário 3 (Atualização de Status): **100%** (5 de 5 concluíram)
    * Cenário 4 (Filtragem de Atividades): **60%** (3 de 5 concluíram)
    * Cenário 5 (Verificação no Mural): **100%** (5 de 5 concluíram)
* **Tempo Médio para Completar cada Cenário:**
    * Cenário 1: 104,4 segundos
    * Cenário 2: 109,6 segundos
    * Cenário 3: 41,2 segundos
    * Cenário 4: 81,0 segundos
    * Cenário 5: 67,4 segundos
* **Número Médio de Erros Cometidos por Tarefa:** 1,2 erros por usuário ao longo de todo o ciclo de testes.
* **Taxa de Abandono Geral:** **12%** (Das 25 tarefas executadas no total, ocorreram 3 abandonos parciais concentrados no Usuário 3, ocasionados por barreiras visuais e de lógica de validação).

### 2. Análise Qualitativa e Padrões Identificados

* **Principais Dificuldades Enfrentadas:**
    * *Ícones Abstratos vs Rótulos:* O uso de simbologias puras sem rótulos em texto (como o ícone de funil para o filtro) gerou dúvidas e cliques inválidos nos perfis de menor fluência digital (U1 e U3).
    * *Mecânicas de Validação Rígidas:* Restrições de segurança na criação de senha sem indicação instantânea dos critérios geraram estresse cognitivo, induzindo o usuário ao abandono precoce no fluxo inicial.
    * *Acessibilidade de Elementos Visuais:* Fontes de tamanho reduzido nas listas suspensas de categorias e taxas de contraste abaixo do ideal dificultaram o uso contínuo por parte do público idoso.
* **Sucessos de Interação:** Os fluxos do Dashboard diário ("O que fazer hoje?") e o Mural de Conquistas performaram acima da média de mercado. O feedback visual (mudança cromática e sensação de recompensa) demonstrou forte apelo motivacional e engajamento prático.

### 3. Classificação dos Problemas por Nível de Prioridade

#### Crítico (Impede o uso do sistema ou gera abandono direto)
* **Problema:** Mensagens de erro vagas na digitação de senha no cadastro e tamanho reduzido da área de clique (*padding*) na seleção de categorias.
* **Impacto:** Causou a desistência do Usuário 3 no primeiro acesso e barrou a criação de novas atividades cotidianas.

#### Moderado (Prejudica e desacelera de forma severa a experiência)
* **Problema:** Botões e gatilhos de filtro representados puramente por ícones gráficos isolados de identificação textual explicativa.
* **Impacto:** Usuários leigos gastaram tempo excessivo procurando funcionalidades estratégicas ou erraram o caminho de navegação.

#### Leve (Inconveniência visual ou oportunidade de otimização estética)
* **Problema:** Baixo contraste nas bordas dos checkboxes e excesso de elementos brilhantes justapostos na visualização do Mural.
* **Impacto:** Causou confusão visual momentânea e lentidão pontual no clique preciso do Dashboard.

### 4. Propostas de Ações Corretivas e Evolução do Sistema

| Categoria | Problema Identificado | Ação Corretiva Proposta (Solução) |
| :--- | :--- | :--- |
| **Crítico** | Erros de senha confusos no cadastro. | Implementar validação inline dinâmica (checklist visual com ticks verdes mudando em tempo real à medida que as regras são atendidas). |
| **Crítico** | Seleção de categorias inacessível. | Expandir a área clicável da lista para o padrão mínimo de $44 \times 44 \text{ px}$ e adotar tags coloridas pré-definidas para segmentação rápida. |
| **Moderado** | Ícones de filtragem e mural sem rótulos. | Substituir ícones puros por botões híbridos (Ícone + Texto explicativo: ex. `[Funil] Filtrar Finanças`). |
| **Leve / Acessibilidade** | Contraste de cores sutil. | Adequar o esquema de cores das fontes secundárias e bordas às diretrizes WCAG (relação mínima de contraste de $4.5:1$). |
