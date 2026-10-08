# Finais

## Purpose
Define os finais e o julgamento escondido que escolhe entre eles.

## Requirements

### Requirement: Julgamento escondido
O jogo SHALL avaliar, sem avisar o jogador, como ele trata os moradores ao longo do jogo (desconfiado e grosso, ou aberto e gentil), com o Claude classificando as conversas livres.

#### Scenario: Jogador preconceituoso
- **WHEN** a maior parte das conversas é classificada como desconfiada ou grosseira
- **THEN** o final "Maria" fica mais provável

### Requirement: Lista de finais
O jogo SHALL ter estes finais: "Pedir desculpas", "Maria", "Ficou" e o final secreto "Caramelo".

#### Scenario: Final Ficou
- **WHEN** o jogador termina com a maioria das conversas classificadas como gentis e visitou todos os bares
- **THEN** o final "Ficou" fica disponível
