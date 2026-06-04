# Plano de Testes de Software

| **Caso de Teste** | **CT01 – Cadastro de Usuário** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - Cadastrar usuários informando nome, e-mail e senha. |
| Objetivo do Teste 	| Verificar se o sistema permite a criação de uma nova conta preenchendo todos os campos obrigatórios. |
| Passos 	| 1. Acessar a página inicial do sistema. <br>2. No formulário de Cadastro, preencher "Nome completo", "E-mail" e "Senha". <br>3. Clicar no botão "Cadastrar". |
|Critério de Êxito | O sistema valida os dados, salva o novo usuário no banco de dados e redireciona para a tela de login ou Dashboard. |

<br>

| **Caso de Teste** | **CT02 – Trocar Senha** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-003 - Recuperar senha por meio de redefinição de senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue redefinir sua senha com sucesso, respeitando as regras de validação exigidas pelo sistema. |
| Passos 	| 1. Acessar a tela de redefinição de senha (rota `/refazer-senha`) <br>2. Confirmar se o e-mail alvo está listado corretamente <br>3. Preencher o campo "Digite a nova senha" informando uma senha válida (Mínimo 8 caracteres, contendo ao menos uma letra maiúscula, um número e um caractere especial) <br>4. Preencher o campo "Confirmar senha" com a exata mesma senha <br>5. Clicar no botão "Salvar" |
|Critério de Êxito | - O sistema valida os critérios de segurança, salva a nova senha com sucesso e apresenta uma mensagem de confirmação (e/ou redireciona para a tela de login). |

<br>


| **Caso de Teste** | **CT03 – Dashboard** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-007 - Atualizar o status das metas (em andamento, concluída ou cancelada). <br> RF-009 - Visualizar painel de evolução com resumo das metas do usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar as atividades do dia, acessar seus detalhes e atualizar o status de conclusão diretamente pelo Dashboard. |
| Passos 	| 1. Acessar a aplicação e efetuar o login <br>2. Navegar pelo menu lateral e clicar em "Dashboard" (rota `/dashboard`) <br>3. Na seção "Oque fazer hoje?", visualizar a lista de atividades <br>4. Clicar em uma atividade específica (ex: "Cardio") <br>5. Verificar se os detalhes (descrição e meta associada) são exibidos no painel lateral <br>6. Na seção "Status", marcar uma das opções disponíveis ("Concluido", "Parcialmente concluido" ou "Nao concluido") |
|Critério de Êxito | - As atividades pendentes são listadas corretamente na tela. <br> - Os detalhes da atividade clicada são renderizados no painel ao lado. <br> - O status da atividade é atualizado com sucesso ao marcar o respectivo checkbox. |

<br>

| **Caso de Teste** | **CT04 – Gerenciamento e Organização de Metas** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-005, RF-008 e RF-010 - Gerenciar metas e categorias para organização e controle. |
| Objetivo do Teste 	| Validar se o usuário consegue visualizar suas metas e se a organização por categorias está funcional. |
| Passos 	| 1. Efetuar login e clicar em "Metas" no menu lateral.<br>2. Visualizar a listagem de metas existentes.<br>3. Utilizar o recurso de filtro ou seleção de categorias (ex: "Saúde" ou "Finanças").<br>4. Verificar se a interface agrupa as metas conforme a categoria selecionada. |
|Critério de Êxito | O sistema exibe as metas corretamente e permite a organização visual através das categorias cadastradas. |

<br>

| **Caso de Teste** | **CT05 – Registro de Atividades** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 - Gerenciar metas pessoais permitindo cadastrar, visualizar, editar e excluir metas. <br> RF-006 - Definir título, descrição, categoria e prazo para cada meta cadastrada. <br> RF-012 - Anexar imagens como comprovação de progresso das metas. |
| Objetivo do Teste 	| Verificar se o usuário consegue registrar uma nova meta preenchendo os campos principais de nome e motivação, e interagindo com as opções de tempo, objetivos e categoria. |
| Passos 	| 1. Acessar a aplicação e efetuar o login <br>2. Navegar pelo menu lateral e clicar em "Registrar Atividade" (rota `/registro-de-atividades`) <br>3. Preencher o campo de texto "Digite um nome para sua meta" (título) <br>4. Preencher a área de texto "Digite sua motivação" (descrição) <br>5. Marcar os checkboxes desejados ("Definir tempo de conclusao?", "Atribuir objetivos ?", "Atribuir Categoria ?") e preencher os dados caso novos campos sejam exibidos <br>6. Clicar no botão "Registrar" |
|Critério de Êxito | - O sistema valida os dados inseridos e registra a nova meta com sucesso. <br> - Uma mensagem de feedback visual é apresentada ao usuário confirmando a criação. <br> - A meta recém-criada passa a estar disponível no Dashboard e na lista de Metas. |

<br>

| **Caso de Teste** | **CT06 – Mural de Conquistas** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-011 - Registrar conquista no mural quando metas são concluídas. |
| Objetivo do Teste 	| Garantir que o sistema automatize o registro de sucesso quando uma meta atinge o status de concluída. |
| Passos 	| 1. No Dashboard, atualizar o status de uma meta para "Concluído" (RF-007).<br>2. Navegar até a tela "Mural" através do menu lateral.<br>3. Verificar se a meta concluída aparece listada como uma conquista.|
|Critério de Êxito | A meta deve ser exibida no Mural de Conquistas imediatamente após a alteração de status para concluída. |

<br>

| **Caso de Teste** | **CT07 – Visualizar Histórico de Metas** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 - Gerenciar metas pessoais permitindo cadastrar, visualizar, editar e excluir metas. <br> RF-009 - Visualizar painel de evolução com resumo das metas do usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar o histórico de progresso das suas metas através do calendário e utilizar filtros para refinar a busca. |
| Passos 	| 1. Acessar a aplicação e efetuar o login <br>2. Navegar pelo menu lateral e clicar em "Histórico" (rota `/historico`) <br>3. Visualizar a seção "Visualizar historico" contendo as metas cadastradas (ex: Emagrecer, Quitar dívidas, etc.) <br>4. Observar o calendário mensal exibido abaixo das metas <br>5. Clicar na opção "Filtrar" para testar a ordenação/filtro do histórico <br>6. Selecionar uma meta específica na lista (ex: "Emagrecer") para verificar o destaque no calendário |
|Critério de Êxito | - A tela carrega corretamente as metas do usuário e seus respectivos status. <br> - O calendário exibe marcadores visuais (ícones verdes) nos dias em que houve progresso ou conclusão de atividades. <br> - Os filtros funcionam corretamente, atualizando os dados do calendário com base na meta selecionada. |

<br>

| **Caso de Teste** | **CT08 – Painel de Notificações** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-009 - Visualizar painel de evolução com resumo das metas do usuário. |
| Objetivo do Teste 	| Verificar se a tela de notificações resume corretamente as atividades recentes e a evolução do usuário. |
| Passos 	| 1. Realizar uma ação no sistema (ex: cadastrar nova meta ou concluir atividade).<br>2. Clicar no ícone de notificações (Sino) ou acessar a rota /notificacoes.<br>3. Validar se os cards informativos refletem as ações recentes do usuário. |
|Critério de Êxito | A tela deve renderizar mensagens claras sobre o progresso das metas e alertas de sistema em ordem cronológica. |

<br>

| **Caso de Teste** | **CT09 – Configurações Gerais** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - Cadastrar usuários informando nome, e-mail e senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue alterar e salvar as preferências da aplicação, como tema (claro/escuro) e permissão de notificações. |
| Passos 	| 1. Acessar a aplicação e efetuar o login <br>2. Clicar no ícone de engrenagem (Configurações) localizado no canto superior direito (rota `/Configurações-geral`) <br>3. Verificar a exibição do idioma ("Idioma: Portugues-Br") <br>4. Alternar a opção de "Tema" selecionando a caixa "Escuro" ou "Claro" <br>5. Marcar ou desmarcar a caixa de seleção "Exibir Notificação" <br>6. Clicar no botão "Salvar" |
|Critério de Êxito | - As preferências são atualizadas e salvas com sucesso. <br> - Ao alterar o tema, a interface deve refletir imediatamente a mudança para o modo claro ou escuro. <br> - O sistema passa a respeitar a nova configuração de exibição de notificações. |

<br>

| **Caso de Teste** | **CT10 – Edição de Perfil** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-004 - Editar informações do perfil do usuário. |
| Objetivo do Teste 	| Validar a funcionalidade de alteração de dados cadastrais. |
| Passos 	| 1. Acessar a tela de Configurações de Perfil através do ícone de usuário.<br>2. Alterar o nome ou e-mail nos campos de edição.<br>3. Clicar no botão de confirmação/salvar. |
|Critério de Êxito | O sistema deve persistir as novas informações no banco de dados e exibir os dados atualizados na interface. |
