# Registro de Testes de Software
---

| **Caso de Teste** 	| **CT01 – Cadastrar Usuário** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - Cadastrar usuários informando nome, e-mail e senha. |
|Registro de evidência |https://youtu.be/-ZjEEg0M2m0 |

| **Caso de Teste** 	| **CT02 – Trocar Senha** 	|
|:---:	|:---:	|
| Requisito Associado | RF-003 - Recuperar senha por meio de redefinição de senha. |
| Registro de evidência | https://youtu.be/jAn6rpb3jjk |

| **Caso de Teste** 	| **CT03 – Dashboard** |
|:---:	|:---:	|
| Requisito Associado |RF-007 - Atualizar o status das metas (em andamento, concluída ou cancelada). <br> RF-009 - Visualizar painel de evolução com resumo das metas do usuário.  |
| Registro de evidência |https://youtu.be/F2VoGSLjl3A |

| **Caso de Teste** 	| **CT06 – Mural de Conquistas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-011 - Registrar conquista no mural quando metas são concluídas. |
|Registro de evidência | https://youtu.be/De3jI3rPVMc |

| **Caso de Teste** 	| **CT07 –   Visualizar Histórico de Metas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-009 - Visualizar painel de evolução. |
|Registro de evidência | https://youtu.be/xh7ax80UpLs |

| **Caso de Teste** 	| **CT08 - Painel de Notificações** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-009 - Visualizar painel de resumos das metas de usúario. |
|Registro de evidência | https://youtu.be/HElhA61ftFY |

| **Caso de Teste** 	| **CT09 – Configurações Gerais** 	|
|:---:	|:---:	|
| Requisito Associado | RF-013 - Personalizar as preferências da aplicação (idioma, tema claro/escuro e notificações). |
| Registro de evidência | https://drive.google.com/file/d/1Q4kx8ltGV8xWZWYNK42LCuIZ0rmllrQX/view?usp=sharing |

| **Caso de Teste** 	| **CT10 – Edição de Perfil** 	|
|:---:	|:---:	|
| Requisito Associado | RF-004 - Editar informações do perfil do usuário. |
| Registro de evidência | https://drive.google.com/file/d/1siNKr52B7pJkeTcD9v7Y_vT56nddyBDG/view?usp=sharing |

## Relatório de testes de software

### Registro de Testes de Software

### Atendimento aos Requisitos Funcionais e Não Funcionais
A bateria de testes confirmou que a solução atende aos objetivos propostos, com os seguintes destaques:

*   **RF-001 e RF-002 (Cadastro e Login):** Validados com sucesso. O sistema de autenticação por cookies garante o acesso seguro e a persistência da sessão do usuário.
*   **RF-005 e RF-006 (Gestão de Metas):** O CRUD completo (Criar, Visualizar, Editar e Excluir) funciona corretamente.
*   **RF-009 (Painel de Evolução):** O dashboard consolida as metas ativas do dia, cumprindo seu papel de organizador diário.
*   **RNF-001 (Responsividade):** Testado em dispositivos móveis e desktops, garantindo que a interface se adapte sem perda de funcionalidade.

### Discussão dos Resultados
Os resultados demonstram uma solução estável e funcional. 
*   **Pontos Fortes:** A integração entre os Controllers e as Views Razor permite um fluxo de dados rápido. O sistema de notificações automáticas é um diferencial que aumenta a utilidade da ferramenta.
*   **Fragilidades:** Identificou-se que a validação de campos no lado do servidor (Server-side) é robusta, mas o feedback visual imediato no navegador (Client-side) pode ser aprimorado.

### Falhas Detectadas e Impactos
*   **Falha de Configuração SMTP:** A funcionalidade de recuperação de senha depende de credenciais de e-mail no `appsettings.json`. 
    *   **Impacto:** Usuários que esquecem a senha ficam impossibilitados de recuperá-la sem intervenção do administrador.
*   **Conflito de Datas:** Foi possível registrar uma meta com data de término anterior à data de início em um dos cenários de teste.
    *   **Impacto:** Compromete a eficácia do acompanhamento de progresso.

### Estratégias de Correção e Melhorias
Para as próximas iterações, o grupo planeja:
1.  **Ajustes no Código:** Implementar validações de intervalo de data diretamente nos Models.
2.  **Interface:** Adicionar máscaras de entrada e seletores de data mais intuitivos.
