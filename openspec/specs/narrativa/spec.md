# Narrativa

## Purpose
Define a história principal, os personagens e a regra de tom do jogo.

## Requirements

### Requirement: Premissa
O jogo SHALL começar com o Jaime recebendo no app de namoro a mensagem da Mari "me encontra no meu lugar feliz", três anos depois do último contato, e com o perfil dela sumindo logo em seguida.

#### Scenario: Abertura
- **WHEN** o jogador inicia um novo jogo
- **THEN** a primeira cena mostra a notificação da Mari no celular do Jaime
- **AND** ao tentar responder, o app mostra "Essa conta não existe mais"

### Requirement: Reviravolta do ghosting
A história SHALL revelar, só no ato final, que foi o Jaime quem deu ghosting na Mari no dia do encontro por preconceito com o lugar onde ela morava.

#### Scenario: Revelação na quadra
- **WHEN** o jogador ouve o áudio de WhatsApp encontrado na quadra de Nilópolis
- **THEN** a verdade sobre o ghosting é revelada

#### Scenario: Sem spoiler antes da hora
- **WHEN** o jogador ainda não chegou a Nilópolis
- **THEN** nenhum diálogo, documento ou resposta da IA revela o ghosting

### Requirement: Regra de tom sobre os moradores
Nenhum conteúdo do jogo MUST retratar moradores da Baixada como perigosos, burros ou caricatos. O alvo do humor é o medo e o preconceito do Jaime.

#### Scenario: Revisão de conteúdo
- **WHEN** um diálogo, NPC ou documento novo é criado
- **THEN** ele é revisado contra esta regra antes de entrar no jogo

### Requirement: Elenco
O jogo SHALL ter estes personagens: Jaime (protagonista), Mari (o date), Maria (a versão idealizada da Mari), Ângela (moça procurando a mãe), Edinho (só queria comer um podrão em paz) e Laurinha (criança da rua que conhecia a Mari).

#### Scenario: Encontro com o elenco
- **WHEN** o jogador termina o jogo pelo caminho principal
- **THEN** ele encontrou todos os personagens do elenco pelo menos uma vez
