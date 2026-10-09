# M0 Caxias: implementação

Registro do que foi implementado na change `prototipo-m0-caxias`, atualizado a cada grupo de tarefas.
Os requisitos ficam em `openspec/specs/` e as decisões em `openspec/changes/prototipo-m0-caxias/design.md`;
este documento descreve o código e como ele foi verificado.

Branch: `feature/m0-caxias-implementacao`.

## Mapa do projeto

| Pasta | Conteúdo |
| --- | --- |
| `Assets/Scripts/Jaime/` | Assembly `MeuPMeLevou.Jaime`: movimento, fôlego, câmera. |
| `Assets/Input/Jaime.inputactions` | Input Actions com o mapa `Exploration`. |
| `Assets/Scenes/M0_Caxias.unity` | Cena do protótipo: viela de blocos cinza. |
| `Assets/Tests/EditMode/` | Testes de regra pura e de bindings de input. |
| `Assets/Tests/PlayMode/` | Testes que carregam a cena. |

Convenção: namespace raiz `MeuPMeLevou`, identificadores em inglês, campos privados `_camelCase`
e `[SerializeField] private` para o Inspector.

## Componentes

### Input Actions (`Jaime.inputactions`) — tarefa 2.1

Mapa `Exploration`, usado por todos os componentes abaixo:

| Ação | Tipo | Controle |
| --- | --- | --- |
| `Move` | Vector2 | W, A, S, D |
| `Look` | Vector2 | delta do mouse |
| `Sprint` | Botão | Shift esquerdo |
| `SwitchShoulder` | Botão | Q |
| `Phone` | Botão | Tab |
| `Flashlight` | Botão | F |
| `Pause` | Botão | Esc |

`Phone`, `Flashlight` e `Pause` ainda não têm consumidor no código; entram nas tarefas 3.x.

### `Stamina` (classe C# pura) — tarefa 2.2

Regra do fôlego, sem dependência de cena. `Tick(deltaTime, wantsSprint, isMoving)` devolve se o Jaime corre
neste passo.

- Correr gasta fôlego (20/s por padrão).
- Andar sem correr recupera (15/s).
- Parado não recupera.
- Com fôlego zerado não corre (`CanSprint` é falso).

### `JaimeMovement` (MonoBehaviour) — tarefa 2.2

Cola entre `Move`/`Sprint`, `Stamina` e o `CharacterController`. Movimento relativo à câmera, com velocidades de
andar (2,5) e correr (5) e gravidade configuráveis no Inspector.

### `JaimeCameraLook` (MonoBehaviour) — tarefa 2.4

Gira só o yaw do alvo da câmera (`AlvoCamera`) com o delta do mouse. O Third Person Follow usa a rotação do alvo.

### `ShoulderSwitch` (MonoBehaviour) — tarefa 2.4

Alterna `CameraSide` do `CinemachineThirdPersonFollow` entre 0 e 1 quando `SwitchShoulder` é apertada, com
transição suave (`_switchSpeed`).

### Câmera (objeto `CameraJaime` na cena) — tarefa 2.4

Cinemachine Camera com Third Person Follow: deslocamento de ombro (0,5; 0,2), distância 3, evitação de
obstáculos ligada (raio 0,2, ignora a tag `Player`). A colisão com paredes vem do próprio Cinemachine, sem raycast
próprio.

### Cena `M0_Caxias` — tarefa 2.3

Viela de blocos cinza com um trecho estreito entre z = 10 e z = 20 (livre de cerca de 1,5 m entre as paredes).

## Verificação

| Tarefa | Como foi verificada |
| --- | --- |
| 1.3 | Test Runner lista as duas suítes: EditMode (15 testes) e PlayMode (2 testes). |
| 2.1 | `JaimeInputActionsTests` simula teclado e mouse e confere que cada ação dispara do controle da tabela. Substitui a checagem manual no Input Debugger. |
| 2.2 | `StaminaTests` (5 testes): gasta correndo, recupera andando, não recupera parado, não corre zerado, limites 0 e máximo. |
| 2.4 | `CameraInAlleyTests` percorre o trecho estreito com o ombro padrão e depois de apertar Q, e falha se o centro da câmera entrar em uma parede. Também confere que o Q muda `CameraSide`. |

## Notas

- **Renomeação para inglês.** O primeiro código do M0 saiu em português (`Folego`, `MovimentoJaime`, mapa
  `Exploracao`). Foi renomeado para seguir o CLAUDE.md e o design: `Stamina`, `JaimeMovement`, `ShoulderSwitch`,
  `JaimeCameraLook`, mapa `Exploration`. Os arquivos foram movidos com os `.meta`, então os GUIDs e as ligações
  da cena foram mantidos, e os campos serializados da cena foram migrados sem perder valores.
- Nomes de objetos da cena (`Jaime`, `AlvoCamera`, `TrechoEstreitoEsquerda`) continuam em português; são conteúdo
  da cena, não código.
