# Proposal

## Why

O projeto passou a ser desenvolvido no Windows e no Mac, com o Claude rodando localmente ao lado do Editor e conectado pelo `unity-mcp`. O repositório e as regras ainda supõem um único Mac e um Claude na nuvem sem Editor, e isso já causa problemas: arquivos aparecem como modificados no Windows só por fim de linha, os hooks do Claude Code apontam para scripts apagados e as regras mandam deixar abertas tarefas que agora podem ser verificadas. Isso precisa ser resolvido antes das tarefas 4.x do M0, que são as primeiras a mexer pesado na cena pelo Windows.

## What Changes

- Adicionar um `.gitattributes` que grava texto em LF nas duas máquinas e marca os binários de Unity (texturas, modelos, áudio, fontes) como binários, e renormalizar o repositório uma vez.
- Remover do `.claude/settings.json` as entradas de hooks que chamam scripts de `.claude/hooks/`, apagados no commit `7d7ad08`. A status line continua.
- Reescrever a regra de ambiente: o Claude roda localmente (Windows ou Mac) com o Editor aberto e conectado pelo `unity-mcp`. Uma tarefa só fecha depois de passar pelo Editor: console sem erros, testes verdes e, quando for visual, uma captura. Sem o MCP, a tarefa fica aberta com o passo de verificação explícito. Vale para `CLAUDE.md`, `openspec/config.yaml` e os agentes `qa-tester` e `technical-artist`.
- Registrar as regras de convivência: mesma versão do Editor nas duas máquinas, uma máquina edita a cena por vez, cenas e prefabs mudam pela API do Editor via MCP (nunca editando o YAML), e a configuração do `unity-mcp` é feita por máquina.
- Registrar como pré-requisito das duas máquinas o Node.js e a CLI `openspec`.
- Deixar explícito que as ferramentas de geração de assets do Unity AI não são usadas; a arte continua vindo só da Asset Store.
- Adicionar um utilitário de Editor versionado (`Assets/Scripts/EditorTools/`) que roda as suítes EditMode e PlayMode e grava o resultado em `Temp/`, sobrevivendo ao recarregamento de domínio do Play Mode, para o Claude rodar e ler os testes pelo `unity-mcp`. Um `ICallbacks` avulso no `Unity_RunCommand` foi testado e perde o resultado do PlayMode.
- Fora do escopo: as tarefas restantes do M0, quebrar a cena `M0_Caxias` em prefabs, configurar o UnityYAMLMerge (o caminho muda por sistema e fica no `git config` local de cada um), versionar um `.mcp.json` (o executável do relay muda por sistema), restaurar os scripts de hooks e qualquer mudança em pacotes do Unity.

## Capabilities

### New Capabilities

Nenhuma.

### Modified Capabilities

Nenhuma. A mudança é de ferramentas, configuração do repositório e documentação, sem mudar o comportamento do jogo descrito em `openspec/specs/`. Por isso declara `skip_specs: true`.

## Impact

- **Repositório:** `.gitattributes` novo; a renormalização toca os arquivos de texto que estiverem com fim de linha diferente de LF no índice. Hoje o índice já está todo em LF, então se espera só o ruído atual de `ProjectSettings/` e `Assets/UniversalRenderPipelineGlobalSettings.asset` sumir.
- **Código de Editor:** pasta nova `Assets/Scripts/EditorTools/` com um assembly definition só de Editor (fora de qualquer build) e um teste EditMode em `Assets/Tests/EditMode/`.
- **Claude Code:** `.claude/settings.json` perde as entradas de hooks; `.claude/agents/qa-tester.md` e `.claude/agents/technical-artist.md` mudam a regra de verificação.
- **Documentação e OpenSpec:** `CLAUDE.md` e o `context` de `openspec/config.yaml` mudam a seção de ambiente e verificação.
- **Pacotes do Unity e Asset Store:** nenhum pacote ou asset é adicionado. O `com.unity.ai.assistant` (que fornece a ponte do `unity-mcp`) já está no manifest e não muda.
- **Máquinas:** o Mac precisa do `unity-mcp` configurado no Claude Code e da mesma versão da CLI `openspec`; isso é um passo manual registrado nas tarefas.
