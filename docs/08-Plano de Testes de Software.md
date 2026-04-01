# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
| **Caso de Teste** | **CT01 – Trocar Senha** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-003 - Recuperar senha por meio de redefinição de senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue redefinir sua senha com sucesso, respeitando as regras de validação exigidas pelo sistema. |
| Passos 	| - Acessar a tela de redefinição de senha (rota `/refazer-senha`) <br> - Confirmar se o e-mail alvo está listado corretamente <br> - Preencher o campo "Digite a nova senha" informando uma senha válida (Mínimo 8 caracteres, contendo ao menos uma letra maiúscula, um número e um caractere especial) <br> - Preencher o campo "Confirmar senha" com a exata mesma senha <br> - Clicar no botão "Salvar" |
|Critério de Êxito | - O sistema valida os critérios de segurança, salva a nova senha com sucesso e apresenta uma mensagem de confirmação (e/ou redireciona para a tela de login). |

<br>

| **Caso de Teste** | **CT02 – Dashboard** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 - Gerenciar metas pessoais permitindo cadastrar, visualizar, editar e excluir metas. <br> RF-007 - Atualizar o status das metas (em andamento, concluída ou cancelada). <br> RF-009 - Visualizar painel de evolução com resumo das metas do usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar as atividades do dia, acessar seus detalhes e atualizar o status de conclusão diretamente pelo Dashboard. |
| Passos 	| - Acessar a aplicação e efetuar o login <br> - Navegar pelo menu lateral e clicar em "Dashboard" (rota `/dashboard`) <br> - Na seção "Oque fazer hoje?", visualizar a lista de atividades <br> - Clicar em uma atividade específica (ex: "Cardio") <br> - Verificar se os detalhes (descrição e meta associada) são exibidos no painel lateral <br> - Na seção "Status", marcar uma das opções disponíveis ("Concluido", "Parcialmente concluido" ou "Nao concluido") |
|Critério de Êxito | - As atividades pendentes são listadas corretamente na tela. <br> - Os detalhes da atividade clicada são renderizados no painel ao lado. <br> - O status da atividade é atualizado com sucesso ao marcar o respectivo checkbox. |

<br>

| **Caso de Teste** | **CT03 – Registro de Atividades** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 - Gerenciar metas pessoais permitindo cadastrar, visualizar, editar e excluir metas. <br> RF-006 - Definir título, descrição, categoria e prazo para cada meta cadastrada. <br> RF-012 - Anexar imagens como comprovação de progresso das metas. |
| Objetivo do Teste 	| Verificar se o usuário consegue registrar uma nova meta preenchendo os campos principais de nome e motivação, e interagindo com as opções de tempo, objetivos e categoria. |
| Passos 	| - Acessar a aplicação e efetuar o login <br> - Navegar pelo menu lateral e clicar em "Registrar Atividade" (rota `/registro-de-atividades`) <br> - Preencher o campo de texto "Digite um nome para sua meta" (título) <br> - Preencher a área de texto "Digite sua motivação" (descrição) <br> - Marcar os checkboxes desejados ("Definir tempo de conclusao?", "Atribuir objetivos ?", "Atribuir Categoria ?") e preencher os dados caso novos campos sejam exibidos <br> - Clicar no botão "Registrar" |
|Critério de Êxito | - O sistema valida os dados inseridos e registra a nova meta com sucesso. <br> - Uma mensagem de feedback visual é apresentada ao usuário confirmando a criação. <br> - A meta recém-criada passa a estar disponível no Dashboard e na lista de Metas. |

<br>

| **Caso de Teste** | **CT04 – Visualizar Histórico de Metas** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-005 - Gerenciar metas pessoais permitindo cadastrar, visualizar, editar e excluir metas. <br> RF-009 - Visualizar painel de evolução com resumo das metas do usuário. |
| Objetivo do Teste 	| Verificar se o usuário consegue visualizar o histórico de progresso das suas metas através do calendário e utilizar filtros para refinar a busca. |
| Passos 	| - Acessar a aplicação e efetuar o login <br> - Navegar pelo menu lateral e clicar em "Histórico" (rota `/historico`) <br> - Visualizar a seção "Visualizar historico" contendo as metas cadastradas (ex: Emagrecer, Quitar dívidas, etc.) <br> - Observar o calendário mensal exibido abaixo das metas <br> - Clicar na opção "Filtrar" para testar a ordenação/filtro do histórico <br> - Selecionar uma meta específica na lista (ex: "Emagrecer") para verificar o destaque no calendário |
|Critério de Êxito | - A tela carrega corretamente as metas do usuário e seus respectivos status. <br> - O calendário exibe marcadores visuais (ícones verdes) nos dias em que houve progresso ou conclusão de atividades. <br> - Os filtros funcionam corretamente, atualizando os dados do calendário com base na meta selecionada. |

<br>

| **Caso de Teste** | **CT05 – Configurações Gerais** |
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - Cadastrar usuários informando nome, e-mail e senha. |
| Objetivo do Teste 	| Verificar se o usuário consegue alterar e salvar as preferências da aplicação, como tema (claro/escuro) e permissão de notificações. |
| Passos 	| - Acessar a aplicação e efetuar o login <br> - Clicar no ícone de engrenagem (Configurações) localizado no canto superior direito (rota `/Configurações-geral`) <br> - Verificar a exibição do idioma ("Idioma: Portugues-Br") <br> - Alternar a opção de "Tema" selecionando a caixa "Escuro" ou "Claro" <br> - Marcar ou desmarcar a caixa de seleção "Exibir Notificação" <br> - Clicar no botão "Salvar" |
|Critério de Êxito | - As preferências são atualizadas e salvas com sucesso. <br> - Ao alterar o tema, a interface deve refletir imediatamente a mudança para o modo claro ou escuro. <br> - O sistema passa a respeitar a nova configuração de exibição de notificações. |
 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
