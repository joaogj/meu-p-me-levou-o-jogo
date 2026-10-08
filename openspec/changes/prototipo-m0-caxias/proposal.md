# Proposal

## Why

Antes de produzir conteúdo e arte, precisamos provar as três decisões mais arriscadas do GDD: a câmera atrás do ombro em vielas apertadas, a queda de luz que troca o cenário para o Outro Lado e o chat livre com a Mari pelo Claude. Se alguma delas não funcionar, o resto do plano muda. O protótipo cobre só uma área pequena de Duque de Caxias.

## What Changes

- Configurar o projeto Unity (6000.6.4f1) para o jogo: URP, Cinemachine, Input System, módulos de física, áudio, UI e rede, e o Test Framework.
- Jaime jogável em uma viela de Caxias feita com blocos cinza, com andar, correr com fôlego e câmera atrás do ombro com troca de ombro.
- Celular com bateria, lanterna e menu aberto pela tecla Tab.
- Um gatilho de queda de luz que troca o cenário para o Outro Lado.
- Chat com a Mari por um servidor local que chama o Claude, com falas de reserva quando a API não responde.
- Fora do escopo do M0: criaturas, saúde, saves, esquiva, agachar, ataque, controle de videogame, remapeamento de teclas, ângulos fixos de câmera, NPCs com IA, finais, as outras quatro fases, arte final e publicação do servidor na internet.

## Capabilities

### New Capabilities

Nenhuma. O protótipo implementa requisitos que já existem nas specs, sem mudar o comportamento descrito nelas.

### Modified Capabilities

Nenhuma. Por isso a mudança declara `skip_specs: true`. Os requisitos implementados são:

- `camera`: câmera atrás do ombro, colisão com paredes e balanço opcional.
- `controles`: movimento com teclado, câmera com mouse, trocar de ombro, celular e lanterna, pausa.
- `celular`: bateria como recurso, chat livre com a Mari e falas de reserva sem conexão.
- `fases`: Outro Lado com queda de luz.
- `npcs-ia`: servidor intermediário, limite de custo e falas de reserva (aplicados ao chat da Mari).

## Impact

- **Projeto Unity:** `Packages/manifest.json` ganha os pacotes e módulos listados no design. Código novo em `Assets/Scripts/`, cena nova em `Assets/Scenes/M0_Caxias.unity`, testes em `Assets/Tests/`.
- **Servidor:** pasta nova `server/` na raiz do repositório, fora de `Assets/`, com um serviço Node.js que guarda a chave da API.
- **Dependência externa:** é preciso uma chave da API da Anthropic para testar o chat de verdade. Sem ela, o chat funciona só com as falas de reserva.
- **Custos:** cada mensagem do chat consome a API, com limite por sessão.
