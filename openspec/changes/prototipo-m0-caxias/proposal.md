# Proposal

## Why

Antes de produzir conteúdo e arte, precisamos provar as três decisões mais arriscadas do GDD: a câmera atrás do ombro em vielas apertadas, a queda de luz que troca o cenário para o Outro Lado e a conversa com a Mari pelo celular. Se alguma delas não funcionar, o resto do plano muda. O protótipo cobre só uma área pequena de Duque de Caxias.

## What Changes

- Configurar o projeto Unity (6000.6.4f1) para o jogo: URP, Cinemachine, Input System, módulos de física, áudio, UI e rede, e o Test Framework.
- Jaime jogável em uma viela de Caxias feita com blocos cinza, com andar, correr com fôlego e câmera atrás do ombro com troca de ombro.
- Celular com bateria, lanterna e menu aberto pela tecla Tab.
- Um gatilho de queda de luz que troca o cenário para o Outro Lado.
- Chat com a Mari no celular com falas estáticas: o jogador escolhe entre mensagens prontas e a Mari responde com falas escritas. A conversa com o Claude fica para depois.
- Fora do escopo do M0: criaturas, saúde, saves, esquiva, agachar, ataque, controle de videogame, remapeamento de teclas, ângulos fixos de câmera, chat livre com o Claude e servidor intermediário, NPCs com IA, finais, as outras quatro fases e arte final.

## Capabilities

### New Capabilities

Nenhuma. O protótipo implementa requisitos que já existem nas specs, sem mudar o comportamento descrito nelas.

### Modified Capabilities

Nenhuma. Por isso a mudança declara `skip_specs: true`. Os requisitos implementados são:

- `camera`: câmera atrás do ombro, colisão com paredes e balanço opcional.
- `controles`: movimento com teclado, câmera com mouse, trocar de ombro, celular e lanterna, pausa.
- `celular`: bateria como recurso e as falas pré-escritas da Mari (as mesmas que servem de reserva sem conexão). O chat livre com o Claude não entra no M0.
- `fases`: Outro Lado com queda de luz.

## Impact

- **Projeto Unity:** `Packages/manifest.json` ganha os pacotes e módulos listados no design. Código novo em `Assets/Scripts/`, cena nova em `Assets/Scenes/M0_Caxias.unity`, testes em `Assets/Tests/`.
- **Sem dependências externas:** o M0 não usa a API do Claude, então não precisa de chave nem de servidor.
- **Conteúdo:** as falas da Mari ficam em um asset de dados no projeto, prontas para virar as falas de reserva quando o chat com o Claude entrar.
