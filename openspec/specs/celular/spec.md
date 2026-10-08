# Celular e chat da Mari

## Purpose
Define o celular do Jaime: lanterna, bateria, alerta de monstros e o chat com a Mari controlado pelo Claude.

## Requirements

### Requirement: Bateria como recurso
O celular SHALL ter bateria que gasta com a lanterna e com o chat, e que só recarrega em pontos de save.

#### Scenario: Bateria acabando
- **WHEN** a bateria chega a 0%
- **THEN** a lanterna e o chat ficam indisponíveis até o próximo ponto de save

### Requirement: Alerta de criaturas
O celular SHALL vibrar e mostrar "Mari está digitando…" quando uma criatura estiver perto, no papel do rádio de Silent Hill.

#### Scenario: Criatura por perto
- **WHEN** uma criatura entra no raio de alerta
- **THEN** o celular vibra e mostra "Mari está digitando…" até ela sair do raio

### Requirement: Chat livre com a Mari
O jogador SHALL poder escrever livremente para a Mari, e o Claude responde no papel dela, recebendo o capítulo atual, o que o jogador já descobriu e a lista do que não pode revelar.

#### Scenario: Pergunta sobre o passado
- **WHEN** o jogador pergunta por que ela sumiu antes de chegar a Nilópolis
- **THEN** a Mari responde de forma evasiva, sem revelar o ghosting

#### Scenario: Sem conexão
- **WHEN** a API não responde dentro do tempo limite
- **THEN** o jogo usa uma fala pré-escrita do capítulo atual
