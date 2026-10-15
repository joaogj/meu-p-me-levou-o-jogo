# Design

## Context

Veja proposal.md (Why). Estado atual que molda as decisões:

- O índice do git guarda todos os arquivos de texto em LF. Não há `.gitattributes`, e o Windows usa `core.autocrlf=true`, então o checkout converte para CRLF. O Unity no Windows não grava todos os YAML do mesmo jeito: `ProjectSettings/ProjectSettings.asset` sai em CRLF (`w/mixed` no `git ls-files --eol`), enquanto a cena sai em LF. Por isso o `.gitattributes` é necessário: com `eol=lf`, o git normaliza na hora do `add` e o fim de linha do arquivo no disco deixa de aparecer como mudança. O `git diff --ignore-cr-at-eol` nos seis arquivos "modificados" era vazio.
- Ainda não há binários versionados (texturas, modelos, áudio). Eles vão chegar com os assets da Asset Store.
- O `.claude/settings.json` registra hooks em `SessionStart`, `PreToolUse`, `PostToolUse`, `Notification`, `PreCompact`, `PostCompact`, `Stop`, `SubagentStart` e `SubagentStop`, todos apontando para `.claude/hooks/*.sh`. A pasta foi apagada no commit `7d7ad08`. A status line usa `.claude/statusline.sh`, que existe.
- O `unity-mcp` está configurado no `~/.claude.json` do usuário, apontando para `relay_win.exe`. O lado do Editor vem do pacote `com.unity.ai.assistant`, já presente no manifest. O MCP expõe `Unity_RunCommand` (executa C# no Editor), `Unity_GetConsoleLogs` e capturas de câmera e de cena, mas nenhuma ferramenta específica para rodar testes.
- A regra "o Editor só roda no Mac" aparece em `CLAUDE.md`, no `context` de `openspec/config.yaml` e nos agentes `qa-tester` e `technical-artist`.

## Goals / Non-Goals

**Goals:**
- O git só mostra mudança quando o conteúdo de um arquivo mudou, qualquer que seja o fim de linha que o Unity grave no disco em cada sistema. O repositório guarda tudo em LF.
- Uma única regra de verificação, válida nas duas máquinas, que o Claude e os agentes seguem igual.
- Um jeito comprovado de o Claude rodar os testes pelo `unity-mcp`.

**Non-Goals:**
- Automatizar a verificação (CI, hooks que rodam testes). Fica para quando houver build.
- Resolver conflitos de merge em cena além da regra de convivência.

## Decisions

### 1. LF em todo arquivo de texto, pelo `.gitattributes`
Usar `* text=auto eol=lf` e declarar explicitamente os tipos de texto do Unity (`*.unity`, `*.prefab`, `*.asset`, `*.mat`, `*.meta`, `*.anim`, `*.controller`, `*.inputactions`, `*.uxml`, `*.uss`, `*.tss`, `*.asmdef`, `*.cs`, `*.shader`, `*.hlsl`) como `text eol=lf`, e os binários comuns da Asset Store (`*.png`, `*.jpg`, `*.tga`, `*.psd`, `*.exr`, `*.fbx`, `*.obj`, `*.blend`, `*.wav`, `*.ogg`, `*.mp3`, `*.ttf`, `*.otf`, `*.dll`, `*.so`, `*.bundle`) como `binary`. Depois, `git add --renormalize .` uma vez. O `.gitattributes` vale para qualquer clone e não depende do `core.autocrlf` de cada máquina.

Alternativa descartada: trocar o `core.autocrlf` para `input` no Windows. Funciona, mas é configuração local que cada clone precisa lembrar, e não protege um clone novo.

Alternativa descartada: configurar o UnityYAMLMerge como driver de merge no `.gitattributes`. O caminho do executável muda entre Windows e Mac; fica como configuração local opcional de cada máquina.

Git LFS fica de fora por enquanto: não há binários versionados ainda, e a decisão de usar LFS depende do volume de arte, que se conhece quando os primeiros pacotes da Asset Store entrarem.

### 2. Remover as entradas de hooks em vez de restaurar os scripts
O commit que apagou `.claude/hooks/` se chama "removendo rules e docs nao utilizadas", o que indica que a remoção foi intencional e só faltou limpar o `settings.json`. Remover as entradas mantém o `statusLine`, as permissões e o `deny`.

Alternativa descartada: restaurar os scripts do histórico. Traria de volta comportamento que o João decidiu tirar, e os scripts nunca foram testados no Windows.

### 3. Uma regra de verificação escrita uma vez e referenciada
O texto completo da regra fica no `CLAUDE.md`, na seção "Unity e verificação". O `context` de `openspec/config.yaml` troca a frase do Mac por um resumo de uma linha dizendo que a verificação é feita no Editor via `unity-mcp` e que, sem ele, a tarefa fica aberta com o passo explícito. Os agentes `qa-tester` e `technical-artist` dizem o mesmo em uma ou duas frases, no tom que já usam. O CLAUDE.md já diz que o `config.yaml` é a fonte única para stack e convenções; a regra de ambiente continua resumida lá para valer nas instruções do OpenSpec.

Alternativa descartada: escrever a regra completa nos quatro arquivos. Quatro cópias divergem na próxima mudança.

### 4. Utilitário de Editor versionado para rodar testes e ler o resultado
Um assembly só de Editor, `Assets/Scripts/EditorTools/` (`MeuPMeLevou.EditorTools`), com:
- `TestRun.Start(TestMode)`: guarda o modo em `SessionState`, apaga o log do run anterior e chama `TestRunnerApi.Execute`. O Claude dispara com um `Unity_RunCommand` de uma linha.
- Uma classe `[InitializeOnLoad]` que registra o `ICallbacks` a cada recarregamento de domínio. É isso que faz o callback sobreviver à entrada no Play Mode.
- A cada teste terminado, o callback acrescenta uma linha em `Temp/test-results.log` (resultado, nome, mensagem). A contagem não fica em memória, porque a memória se perde no reload. No fim do run, o callback monta o resumo em `Temp/test-results.txt`, que o Claude lê. `Temp/` já é ignorada pelo git.
- `TestRunSummary`, classe C# pura que transforma as linhas do log no resumo (modo, resultado geral, total, aprovados, falhas com mensagem).

Provado antes de decidir: um `ICallbacks` criado dentro de um `Unity_RunCommand` não sobrevive ao reload; o PlayMode rodou até o fim e nenhum resultado chegou ao arquivo. O domain reload está ligado no projeto (padrão) e continua assim.

Alternativa descartada: o trecho avulso no `Unity_RunCommand`. Funciona no EditMode, mas perde o resultado no PlayMode (provado).

Alternativa descartada: rodar o Unity em `-batchmode -runTests` pela linha de comando. Não funciona com o Editor aberto no mesmo projeto, que é justamente o modo de trabalho escolhido.

Alternativa descartada: desligar o domain reload nas Enter Play Mode Options para o callback sobreviver. Mudaria o comportamento do Play Mode do jogo inteiro por causa de uma ferramenta.

### 5. Impacto em WebGL e Android
Nenhum. A mudança não toca código do jogo, pacotes nem configurações de build.

### 6. O que fica testável em EditMode ou PlayMode
- EditMode: `TestRunSummary` (formatação do resumo a partir das linhas do log), com teste em `Assets/Tests/EditMode`.
- PlayMode / manual no Editor: `TestRun`, o registro do callback e a sobrevivência ao reload. Verificados rodando as suítes que já existem (43 EditMode e 4 PlayMode) e comparando com a janela do Test Runner.

## Risks / Trade-offs

- [A renormalização gerar um diff grande e difícil de revisar] → Rodar `git add --renormalize .` num commit só para isso e conferir que `git diff --cached --ignore-cr-at-eol` fica vazio, ou seja, que só muda fim de linha.
- [O Mac ter alterações locais em CRLF] → O índice já está em LF e o Mac não converte, então não se espera nada. Antes de puxar a mudança no Mac, confirmar `git status` limpo.
- [O `TestRunnerApi` com PlayMode recarregar o domínio e perder o callback] → O callback é registrado por `[InitializeOnLoad]` a cada reload e o resultado vai acumulando em arquivo. Se ainda assim o resultado não chegar, registrar a limitação no PR e rodar o PlayMode pela janela do Test Runner.
- [O utilitário de Editor quebrar numa atualização do Test Framework] → O `packages-lock.json` trava a versão; o assembly é só de Editor e não entra em build do jogo.
- [O pacote `com.unity.ai.assistant` é pré-lançamento e pode quebrar a ponte numa atualização] → O `packages-lock.json` trava a versão; atualizar só nas duas máquinas ao mesmo tempo.
- [O `PATH` de sessões já abertas não enxergar o Node e a CLI recém-instalados] → Reiniciar o terminal ou o VS Code depois da instalação.

## Migration Plan

1. Commit do `.gitattributes` e da renormalização, separado do resto.
2. Commit das regras e do `settings.json`.
3. No Mac: puxar, confirmar `git status` limpo, instalar a mesma versão da CLI `openspec` e configurar o `unity-mcp` no Claude Code.

Para desfazer, reverter os commits. A renormalização não muda conteúdo, só fim de linha.
