## Why

Antes de escrever conteúdo ou arte, precisamos provar as três decisões mais arriscadas do jogo: a câmera atrás do ombro em vielas apertadas, a queda de luz que transforma o cenário e o chat livre com a Mari controlado pelo Claude. Se alguma delas não funcionar, o resto do GDD muda. O protótipo cobre só Duque de Caxias, para não gastar tempo com as outras fases.

## What Changes

- Criar o projeto Unity 6 com URP, em 3D linear.
- Jaime jogável em uma área pequena de Caxias, com câmera atrás do ombro (Cinemachine) e colisão com paredes.
- Controles de teclado e mouse conforme a spec `controles` (WASD, Shift, Espaço, mouse, E, Tab, F, Esc).
- Um gatilho de queda de luz que troca o cenário para o Outro Lado.
- Celular com bateria, lanterna que gasta bateria e o chat com a Mari.
- Chat com a Mari por um servidor intermediário que chama o Claude, com falas de reserva pré-escritas quando a API não responde.
- Fora do escopo: criaturas, Homem do Gás, finais, as outras quatro fases, dublagem, arte final e menus completos.

## Impact

- Capacidades novas: `prototipo` (esta proposta). As capacidades `camera`, `controles`, `celular` e `npcs-ia` já têm specs; o protótipo as implementa, sem mudar os requisitos.
- Código: projeto Unity novo em `Assets/`, e um serviço pequeno do chat em `server/`.
- Custos: a API do Claude entra já no protótipo, com limite de mensagens por sessão de teste.
