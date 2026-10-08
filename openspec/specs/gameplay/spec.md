# Gameplay

## Purpose
Define o estilo de jogo: exploração e puzzles em 3D, fuga no lugar de combate, e a estrutura linear em cinco fases.

## Requirements

### Requirement: Jogo 3D linear
O jogo SHALL ser em 3D, linear, com cinco fases ligadas pelo trem, sem mundo aberto.

#### Scenario: Viagem de trem
- **WHEN** o jogador conclui os objetivos de uma fase
- **THEN** ele volta ao trem e escolhe seguir para a próxima estação liberada

### Requirement: Exploração e puzzles
O jogo SHALL priorizar exploração e puzzles: achar chaves e documentos, abrir portas e resolver enigmas de becos e cenários.

#### Scenario: Porta trancada
- **WHEN** o jogador tenta abrir uma porta trancada
- **THEN** o jogo indica que falta uma chave ou um código, sem mostrar onde achá-lo

### Requirement: Fuga no lugar de combate
O jogador SHALL poder despistar ou se esconder das criaturas. O Jaime SHALL ter apenas armas improvisadas e golpes lentos.

#### Scenario: Esconder-se
- **WHEN** o jogador entra em um esconderijo (armário, lixeira grande, banca fechada) fora da linha de visão de uma criatura
- **THEN** a criatura perde o rastro depois de alguns segundos

#### Scenario: Homem do Gás
- **WHEN** o Homem do Gás persegue o jogador
- **THEN** o jogador não consegue derrotá-lo e só escapa por fuga ou por um ponto de passagem do cenário

### Requirement: Itens e inventário simples
O inventário SHALL ser simples, com chaves, documentos e poucos itens de recuperação, sem sistema de crafting.

#### Scenario: Usar item de recuperação
- **WHEN** o jogador usa um item de recuperação com a saúde incompleta
- **THEN** a saúde sobe e o item é removido do inventário

### Requirement: Saúde e recuperação
O Jaime SHALL ter uma barra de saúde que se recupera com itens encontrados no cenário (por exemplo, "guaraná gelado").

#### Scenario: Saúde zerada
- **WHEN** a saúde chega a zero
- **THEN** o jogo volta ao último ponto de save
