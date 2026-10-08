# Criaturas

## Purpose
Define as criaturas do jogo, o comportamento de cada uma e a culpa do Jaime que ela representa.

## Requirements

### Requirement: Homem do Gás
O jogo SHALL ter o Homem do Gás, com cabeça de botijão e uma chave de grifo gigante, anunciado pela musiquinha do caminhão de gás distorcida. Ele representa o castigo que o Jaime acha que merece.

#### Scenario: Aproximação
- **WHEN** o Homem do Gás entra no raio de detecção
- **THEN** a musiquinha do caminhão de gás começa a tocar, mais lenta e distorcida conforme ele chega perto

### Requirement: Criaturas comuns
O jogo SHALL ter também o Boneco de Posto (ansiedade), as Senhas (a espera e o "depois eu respondo"), os Manequins do Calçadão (o ideal de aparência) e o Mosquitão (inimigo cômico).

#### Scenario: Encontro com o Boneco de Posto
- **WHEN** o jogador se aproxima de um Boneco de Posto
- **THEN** ele se debate na direção do jogador fazendo barulho de ar escapando

### Requirement: Combate fraco de propósito
O combate SHALL ser desajeitado, priorizando fuga, exploração e puzzles.

#### Scenario: Golpe do Jaime
- **WHEN** o Jaime ataca com uma arma improvisada
- **THEN** o golpe é lento e pouco eficaz, e fugir costuma ser a melhor opção
