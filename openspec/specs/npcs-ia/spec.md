# NPCs com IA

## Purpose
Define as conversas livres com os moradores e a infraestrutura de IA.

## Requirements

### Requirement: Conversa livre com moradores
Os moradores SHALL conversar livremente pelo Claude, cada um com uma ficha de personalidade, conhecimento local e a regra de tom da narrativa no prompt.

#### Scenario: Pedido de ajuda
- **WHEN** o jogador pede informação a um morador
- **THEN** o morador responde de forma prestativa e coerente com a ficha dele

### Requirement: Servidor intermediário
As chamadas ao Claude MUST passar por um servidor intermediário. A chave da API MUST NOT ser incluída no build do jogo.

#### Scenario: Chamada de NPC
- **WHEN** o jogo precisa de uma resposta de NPC
- **THEN** ele chama o servidor intermediário, que é o único com a chave da API

### Requirement: Limite de custo
Cada NPC SHALL aceitar um número máximo de mensagens por cena, e as conversas SHALL usar um modelo rápido e barato.

#### Scenario: Limite atingido
- **WHEN** o jogador passa do limite de mensagens com um NPC na cena
- **THEN** o NPC encerra a conversa com uma fala pré-escrita de despedida

### Requirement: Falas de reserva
Todo NPC com IA SHALL ter falas pré-escritas para quando estiver offline.

#### Scenario: Jogo offline
- **WHEN** o jogo está sem internet
- **THEN** os NPCs usam só as falas pré-escritas e o jogo continua jogável
