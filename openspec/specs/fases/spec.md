# Fases

## Purpose
Define os municípios jogáveis, a ordem e o mecanismo de Outro Lado.

## Requirements

### Requirement: Ordem das fases
O jogo SHALL ter cinco fases em ordem, ligadas pelo trem como hub: Duque de Caxias (negação), Nova Iguaçu (aparência), São João de Meriti (sufoco), Nilópolis (memória) e Japeri (aceitação, fim da linha).

#### Scenario: Progressão
- **WHEN** o jogador conclui uma fase
- **THEN** a estação da fase seguinte é liberada no trem

### Requirement: Outro Lado com queda de luz
Cada fase SHALL ter eventos de "caiu a luz" que transformam o ambiente no Outro Lado, com ferrugem, gambiarra viva e postes piscando.

#### Scenario: Queda de luz
- **WHEN** um gatilho de queda de luz é ativado
- **THEN** a iluminação apaga, o ambiente troca para a versão Outro Lado e a trilha muda

### Requirement: Pontos de save
Os saves SHALL acontecer em lanchonetes 24h e bares com a TV ligada.

#### Scenario: Salvar o jogo
- **WHEN** o jogador interage com a TV de um bar ou lanchonete 24h
- **THEN** o jogo é salvo e a bateria do celular é recarregada
