# Controles

## Purpose
Define os controles de PC (teclado e mouse, com suporte a controle) para um jogo em terceira pessoa atrás do ombro, seguindo o padrão do gênero.

## Requirements

### Requirement: Movimento com teclado
O jogo SHALL mover o Jaime com WASD, andar com Shift, agachar com Ctrl e esquivar com Espaço.

#### Scenario: Andar e correr
- **WHEN** o jogador pressiona W, A, S ou D
- **THEN** o Jaime anda na direção da câmera
- **AND** segurar Shift faz ele correr, com barra de fôlego que se esgota

#### Scenario: Esquiva
- **WHEN** o jogador pressiona Espaço com fôlego suficiente
- **THEN** o Jaime faz uma esquiva curta e o fôlego diminui

### Requirement: Câmera com mouse
O jogo SHALL girar a câmera com o movimento do mouse e permitir ajustar a sensibilidade e inverter o eixo vertical nas configurações.

#### Scenario: Ajuste de sensibilidade
- **WHEN** o jogador altera a sensibilidade nas configurações
- **THEN** a câmera responde na nova velocidade sem reiniciar o jogo

### Requirement: Trocar de ombro
O jogo SHALL permitir trocar o lado da câmera (ombro esquerdo ou direito) com a tecla Q.

#### Scenario: Trocar de ombro
- **WHEN** o jogador pressiona Q
- **THEN** a câmera passa para o outro ombro, com transição suave

### Requirement: Mirar e interagir
O jogo SHALL usar o botão direito do mouse para mirar a arma improvisada e a tecla E para interagir (abrir portas, pegar itens, falar com moradores, entrar em esconderijos).

#### Scenario: Interação com contexto
- **WHEN** o jogador está perto de um objeto interativo
- **THEN** a tecla E aparece no HUD com a ação correspondente

### Requirement: Ataque
O jogo SHALL usar o botão esquerdo do mouse para atacar, com golpe lento e alcance curto, conforme a regra de fuga do jogo.

#### Scenario: Golpe
- **WHEN** o jogador pressiona o botão esquerdo com a arma equipada
- **THEN** o Jaime faz um golpe lento, sem cancelar a animação

### Requirement: Celular e lanterna
O jogo SHALL abrir o celular com a tecla Tab e acender a lanterna com a tecla F, que gasta bateria.

#### Scenario: Lanterna sem bateria
- **WHEN** o jogador pressiona F com a bateria em 0%
- **THEN** a lanterna não acende e o HUD mostra o aviso de bateria

### Requirement: Pausa e menu
O jogo SHALL pausar com Esc, abrindo o menu de opções.

#### Scenario: Pausar
- **WHEN** o jogador pressiona Esc durante a exploração
- **THEN** o jogo pausa e abre o menu de opções

### Requirement: Controle de videogame
O jogo SHALL oferecer controle de videogame com o mesmo mapa lógico: analógico esquerdo para andar, analógico direito para a câmera, botão A para interagir, gatilho direito para atacar, gatilho esquerdo para mirar, botão Y para o celular e botão X para a lanterna.

#### Scenario: Troca de dispositivo
- **WHEN** o jogador conecta um controle durante o jogo
- **THEN** o HUD passa a mostrar os botões do controle sem reiniciar

### Requirement: Remapeamento
O jogo SHALL permitir remapear qualquer ação de teclado e controle nas configurações.

#### Scenario: Conflito de tecla
- **WHEN** o jogador atribui a uma ação uma tecla já usada por outra
- **THEN** o jogo pede confirmação e troca as duas ações
