# Câmera

## Purpose
Define a câmera em terceira pessoa atrás do ombro e os momentos pontuais de ângulo fixo cinematográfico.

## Requirements

### Requirement: Câmera atrás do ombro
O jogo SHALL usar uma câmera 3D em terceira pessoa atrás do ombro do Jaime como câmera padrão, controlada pelo jogador, implementada com o Cinemachine.

#### Scenario: Girar a câmera
- **WHEN** o jogador move o mouse ou o analógico direito
- **THEN** a câmera gira em torno do Jaime mantendo a distância configurada

### Requirement: Colisão da câmera
A câmera MUST NOT atravessar paredes, postes ou outros objetos sólidos do cenário.

#### Scenario: Beco apertado
- **WHEN** o Jaime anda por uma viela estreita com a câmera atrás dele
- **THEN** a câmera se aproxima do personagem em vez de atravessar a parede

### Requirement: Ângulos fixos pontuais
O jogo SHALL usar ângulos fixos cinematográficos apenas em momentos específicos: a chegada em Caxias, a quadra de Nilópolis e a cena final em Japeri.

#### Scenario: Chegada em Caxias
- **WHEN** o Jaime desce do Uber na primeira cena
- **THEN** a câmera assume um ângulo fixo e devolve o controle ao jogador ao fim da cena

### Requirement: Balanço de câmera opcional
O jogo SHALL oferecer um balanço leve de câmera para reforçar o clima de terror e uma opção nas configurações para desligá-lo.

#### Scenario: Balanço desligado
- **WHEN** o jogador desliga o balanço de câmera nas configurações
- **THEN** a câmera permanece estável em todas as fases
