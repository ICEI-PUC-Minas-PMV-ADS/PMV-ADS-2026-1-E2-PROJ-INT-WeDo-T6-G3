
# Projeto de Interface

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Visão geral da interação do usuário pelas telas do sistema e protótipo interativo das telas com as funcionalidades que fazem parte do sistema (wireframes).

 Apresente as principais interfaces da plataforma. Discuta como ela foi elaborada de forma a atender os requisitos funcionais, não funcionais e histórias de usuário abordados nas <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a>.

## Diagrama de Fluxo
![DiagramaDeFluxo](https://github.com/ICEI-PUC-Minas-PMV-ADS/PMV-ADS-2026-1-E2-PROJ-INT-WeDo-T6-G3/blob/main/docs/img/Diagrama%20De%20Fluxo.jpeg)


https://lucid.app/lucidchart/7ebc4eee-5ad4-421a-bd7c-5c829cd5c6ec/edit?viewport_loc=4822%2C-4525%2C2950%2C3590%2C_LgGQva0u0ys&invitationId=inv_572f10b5-cf03-4a17-a6ba-3a2807954eea

## Wireframes

Link para visualização do Wireframes: https://www.figma.com/site/28ffPGfNZIXDvDNJQU5qfA/Wedo?node-id=0-1&t=yrziYJckoGbjgous-1

---

### Página de Cadastro e Login (RF-001, RF-002)
Esta tela representa a porta de entrada do sistema WeDo. Ela possui uma divisão clara entre o formulário de Cadastro (lado esquerdo), permitindo que novos usuários insiram Nome, E-mail e Senha, e o formulário de Autenticação/Login (lado direito). A interface contempla o suporte a Social Login (Google e Apple) e o redirecionamento para o fluxo de recuperação de acesso.

<img width="959" height="624" alt="image" src="https://github.com/user-attachments/assets/84e81bf5-2771-4cf5-b9c8-7b472e0cf3c3" />

---

### Dashboard - Página Principal (RF-005, RF-007, RF-009)
O Dashboard atua como o centro de operações diárias do usuário. Ele exibe a lista de tarefas imediatas ("O que fazer hoje?") e permite a atualização rápida do status de cada meta (Concluído, Parcial ou Não Concluído) através de indicadores visuais de cores. No painel central, é possível visualizar o resumo de uma meta específica, incluindo sua descrição e motivação.

<img width="959" height="623" alt="image" src="https://github.com/user-attachments/assets/b8d6d509-38ea-4034-80fa-0ffc2b8a0ccf" />

---

### Página de Metas - Estratégico (RF-005, RF-008, RF-010)
Diferente do Dashboard, esta tela foca na gestão de longo prazo. Ela permite a visualização detalhada de todos os objetivos, oferecendo ferramentas de filtragem por categoria. O diferencial aqui é o componente de calendário/cronograma, que mostra graficamente o período de execução da meta (Início e Fim previsto), ajudando no planejamento temporal do usuário.

<img width="953" height="625" alt="image" src="https://github.com/user-attachments/assets/aa9b5e5e-cf57-4b60-81a7-4c51d60ef897" />

Exemplo da forma de uso da página de Metas:

<img width="954" height="625" alt="image" src="https://github.com/user-attachments/assets/0237d7be-94b1-4a6b-bdc9-d8304ca825c3" />

---

### Registro de Atividades e Novas Metas (RF-005, RF-006, RF-012)
Esta é a interface de entrada de dados. Ela permite o cadastro de novas metas, onde o usuário define o título, a motivação (descrição), o prazo de conclusão e a categoria. Possui controles para definir a frequência semanal (check-boxes dos dias da semana) e, futuramente, o campo para anexar imagens de comprovação de progresso, cumprindo o requisito de evidência de conclusão.

<img width="965" height="627" alt="image" src="https://github.com/user-attachments/assets/1241e5ac-66f4-45e4-a0b8-8fabcd02af20" />

Exemplo da forma de uso da página de Registro: 

<img width="967" height="625" alt="image" src="https://github.com/user-attachments/assets/87091095-4ed3-4352-8dac-d8f236a10399" />

---

### Mural de Conquistas (RF-009, RF-011)
Esta tela funciona como um repositório histórico e motivacional. Ela exibe exclusivamente as metas que atingiram o status de Concluído. O layout apresenta os objetivos finalizados (ex: "Quitar Dívidas", "Tirar CNH") em formato de cards, permitindo que o usuário veja sua evolução e sinta-se recompensado pelo progresso alcançado.

<img width="970" height="629" alt="image" src="https://github.com/user-attachments/assets/39835d23-6e0d-4472-9e4a-583c287eb2a1" />

---

### Página de Histórico (RF-005, RF-009)
Focada em dados passados, esta tela oferece uma visão em calendário de todas as metas manipuladas no mês. Ela permite que o usuário utilize filtros para encontrar metas antigas e visualize, através de marcações no calendário, os dias exatos em que as metas foram iniciadas ou finalizadas, servindo como uma ferramenta de auditoria de produtividade.

<img width="965" height="625" alt="image" src="https://github.com/user-attachments/assets/b04637ad-3783-441b-b022-eba875446668" />

---

### Central de Notificações (RF-002, RF-009)
Esta tela funciona como um canal de comunicação direta do sistema com o usuário. Ela centraliza alertas sobre conquistas recentes (como a conclusão de metas) e confirmações de ações realizadas no sistema (como o registro de novos objetivos). A interface utiliza ícones de alerta com indicadores visuais (pontos vermelhos) para destacar mensagens ainda não lidas, ajudando o usuário a acompanhar sua evolução e as interações do sistema de forma cronológica.

<img width="911" height="589" alt="image" src="https://github.com/user-attachments/assets/fe180008-c893-4675-b295-850e80315595" />

---

### Configurações Gerais (RNF-001, RF-013)
Interface de personalização que permite ajustar o idioma, alternar entre os temas claro/escuro e gerenciar notificações. Possui um botão "Salvar" para garantir que as preferências sejam aplicadas à interface e registradas permanentemente na conta do usuário.

<img width="906" height="584" alt="image" src="https://github.com/user-attachments/assets/c1f37cc3-3ffa-47e9-a0c8-31236f17896b" />

---

### Configurações de Perfil (RF-004)
Tela dedicada à gestão da conta. Permite que o usuário edite suas informações pessoais, como apelido, nome completo e e-mail. A interface utiliza ícones de edição contextual (lápis) para facilitar a interação e inclui um link direto para o fluxo de segurança de troca de credenciais.

<img width="902" height="591" alt="image" src="https://github.com/user-attachments/assets/7be6b72b-27e0-4c26-99b4-a673842a606d" />

---

### Recuperação e Troca de Senha (RF-003)
Esta interface gerencia a segurança do acesso. Ela apresenta campos para a inserção da nova senha com confirmação obrigatória. O diferencial técnico desta tela é a exibição de um checklist de validação em tempo real, garantindo que a nova senha atenda aos critérios de complexidade (caracteres especiais, números e maiúsculas).

<img width="900" height="583" alt="image" src="https://github.com/user-attachments/assets/508fc156-2268-4664-92c0-6ccce7297182" />

