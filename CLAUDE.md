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

- O Editor só roda no Mac do João. Aqui na nuvem não dá para abrir cena, rodar PlayMode nem compilar o projeto.
- Por isso, tarefa que depende do Editor fica aberta, com o passo de verificação dito explicitamente para o João ou uma sessão no Mac.
- Mantenha regras de jogo em classes C# puras (testáveis em EditMode) e o MonoBehaviour só como cola com a cena.
- Versione os `.meta` junto com os assets, nunca edite GUIDs à mão e evite editar cenas e prefabs como texto.
- Mudança em pacote atualiza `Packages/manifest.json` e `Packages/packages-lock.json`.

## Decisões já tomadas

- Sem servidor de chat nem Claude API no M0. O chat da Mari usa falas estáticas escritas à mão, em ScriptableObject atrás da interface `IDialogueSource`. A Claude API entra depois, sempre por servidor intermediário; a chave nunca vai no cliente.
- Câmera atrás do ombro com Cinemachine 3, Input System novo (sem o Input Manager antigo), UI Toolkit para interfaces novas.
- Arte só de assets da Asset Store, com a licença conferida para uso comercial.
