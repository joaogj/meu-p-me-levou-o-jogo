# CLAUDE.md

Jogo 3D linear de terror em terceira pessoa (paródia de Silent Hill 2 na Baixada Fluminense), Unity 6000.6.4f1 com URP. Código (identificadores e comentários) em inglês. Falas, textos de UI, GDD, specs e documentação em português, com as palavras-chave do OpenSpec (SHALL, MUST, WHEN, THEN, Scenario) em inglês.

## Regra do humor (vale para código, falas, specs e arte)

O medo e a piada são do Jaime, não da Baixada. Moradores são as pessoas mais normais e gentis do jogo e nunca são o alvo da graça. Quem é ridicularizado é o preconceito e a covardia do protagonista. Na dúvida sobre uma fala, corte ou reescreva.

## Onde está cada coisa

- `docs/GDD.md` e `docs/conceito.md`: design e conceito.
- `openspec/specs/`: requisitos atuais. `openspec/changes/`: propostas em andamento.
- `openspec/config.yaml`: stack, estrutura de pastas e convenções de C#. É a fonte única; não repita essas regras aqui.

## Fluxo

1. Toda feature nova começa como proposta em `openspec/changes/` (use `/opsx:propose`), nunca direto no código.
2. Implemente com `/opsx:apply`, só depois de a proposta estar acordada.
3. Arquive com `/opsx:archive` quando todas as tarefas tiverem verificação registrada.

## Unity e verificação

- O projeto é desenvolvido no Windows e no Mac. O Claude roda localmente, com o Editor aberto e conectado pelo `unity-mcp`.
- Uma tarefa só é marcada como feita depois de passar pelo Editor: console sem erros, testes EditMode e PlayMode verdes e, quando for visual, uma captura da cena.
- Para rodar os testes, o Claude chama `MeuPMeLevou.EditorTools.TestRun.Start(TestMode.EditMode)` (ou `PlayMode`) num `Unity_RunCommand` e lê `Temp/test-results.txt` quando o `RUNNING` some. O resultado do PlayMode também chega ali, apesar do recarregamento de domínio.
- Sem o `unity-mcp` conectado, a tarefa fica aberta, com o passo de verificação dito explicitamente.
- Cenas e prefabs mudam pela API do Editor via `unity-mcp`, nunca editando o YAML.
- Uma máquina edita a cena por vez: `git pull` antes de abrir o Editor e `git push` antes de trocar de máquina. As duas usam a mesma versão do Editor (`ProjectSettings/ProjectVersion.txt`).
- A configuração do `unity-mcp` no Claude Code é por máquina (o executável do relay muda entre Windows e Mac) e não vai para o repositório.
- Pré-requisitos nas duas máquinas: Node.js e a CLI `openspec`, na mesma versão.
- Mantenha regras de jogo em classes C# puras (testáveis em EditMode) e o MonoBehaviour só como cola com a cena.
- Versione os `.meta` junto com os assets e nunca edite GUIDs à mão.
- Mudança em pacote atualiza `Packages/manifest.json` e `Packages/packages-lock.json`.

## Decisões já tomadas

- Sem servidor de chat nem Claude API no M0. O chat da Mari usa falas estáticas escritas à mão, em ScriptableObject atrás da interface `IDialogueSource`. A Claude API entra depois, sempre por servidor intermediário; a chave nunca vai no cliente.
- Câmera atrás do ombro com Cinemachine 3, Input System novo (sem o Input Manager antigo), UI Toolkit para interfaces novas.
- Arte só de assets da Asset Store, com a licença conferida para uso comercial. As ferramentas de geração de assets do Unity AI (`Unity_AssetGeneration_*`) não são usadas.
