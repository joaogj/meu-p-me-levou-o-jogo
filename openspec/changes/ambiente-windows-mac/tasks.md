# Tasks

## 1. Fim de linha

- [x] 1.1 Criar o `.gitattributes` com `* text=auto eol=lf`, os tipos de texto do Unity e os binários da decisão 1, e verificar com `git check-attr -a` em um `.unity`, um `.asset` e um `.png` fictício que os atributos saem como esperado
- [x] 1.2 Rodar `git add --renormalize .` e verificar que `git diff --cached --ignore-cr-at-eol` fica vazio e que, depois do commit, `git status` não lista mais `ProjectSettings/` nem `Assets/UniversalRenderPipelineGlobalSettings.asset`
- [x] 1.3 Com o Editor aberto no Windows, salvar a cena `M0_Caxias` sem mudanças pelo `unity-mcp` e verificar que `git status` continua limpo, mesmo com o `ProjectSettings.asset` em CRLF no disco (`w/mixed`), e que `git diff` não mostra nenhuma linha alterada

## 2. Claude Code

- [x] 2.1 Remover de `.claude/settings.json` o bloco `hooks` inteiro, mantendo `statusLine` e `permissions`, e verificar que o JSON é válido (`node -e "JSON.parse(require('fs').readFileSync('.claude/settings.json'))"`) e que nenhum caminho `.claude/hooks/` sobra no arquivo
- [ ] 2.2 Abrir uma sessão nova do Claude Code e verificar que a status line aparece e que nenhum erro de hook é mostrado ao iniciar nem ao rodar um comando Bash

## 3. Regras de ambiente e verificação

- [x] 3.1 Reescrever a seção "Unity e verificação" do `CLAUDE.md` com a regra da decisão 3: Claude local no Windows ou no Mac com o Editor conectado pelo `unity-mcp`; tarefa só fecha com console sem erros, testes verdes e, se visual, captura; cena e prefab mudam pela API do Editor; uma máquina edita a cena por vez; mesma versão do Editor; `unity-mcp` configurado por máquina; Node.js e CLI `openspec` como pré-requisitos; sem o MCP, a tarefa fica aberta com o passo explícito. Verificar com `grep -n "Mac do João\|na nuvem" CLAUDE.md` sem resultados
- [x] 3.2 Acrescentar em "Decisões já tomadas" do `CLAUDE.md` que as ferramentas de geração de assets do Unity AI não são usadas, e verificar que a linha sobre arte da Asset Store continua intacta
- [x] 3.3 Trocar no `context` de `openspec/config.yaml` a frase "Limites do ambiente" pelo resumo da decisão 3, e verificar com `openspec instructions tasks --change ambiente-windows-mac --json` que o novo texto aparece no campo `context`
- [x] 3.4 Atualizar a regra de verificação em `.claude/agents/qa-tester.md` e `.claude/agents/technical-artist.md`, e verificar com `grep -rn "só roda no Mac\|abrir o Editor aqui" .claude/agents` sem resultados

## 4. Testes pelo unity-mcp

- [x] 4.1 Criar `TestRunSummary` (classe C# pura que monta o resumo a partir das linhas do log) e `TestRunSummaryTests` em EditMode, com o assembly `MeuPMeLevou.EditorTools` só de Editor, e verificar que o teste novo passa e que o console não tem erros de compilação
- [x] 4.2 Criar `TestRun.Start(TestMode)` e o registro `[InitializeOnLoad]` do `ICallbacks` (decisão 4), e verificar que, ao rodar a suíte EditMode, `Temp/test-results.txt` mostra o mesmo total que a contagem de testes descobertos (43 mais os novos)
- [x] 4.3 Rodar a suíte PlayMode com `TestRun.Start` e verificar que o resultado chega a `Temp/test-results.txt` depois do recarregamento de domínio (4 de 4), que nenhuma `InitTestScene` sobra em `Assets/` e que `git status` não mostra arquivos novos além dos do utilitário
- [x] 4.4 Registrar no `CLAUDE.md`, em uma ou duas linhas, o comando que o Claude usa para rodar os testes pelo MCP e onde lê o resultado, e verificar que é o mesmo passo que funcionou em 4.2 e 4.3
- [ ] 4.5 Conferir na janela do Test Runner do Editor que os totais batem com os de `Temp/test-results.txt` nos dois modos (passo manual do João ou de uma sessão com acesso à janela)

## 5. Validação integrada

- [x] 5.1 Rodar `openspec validate --all --strict` no Windows e verificar zero erros nesta mudança
- [ ] 5.2 No Mac: puxar a branch, confirmar `git status` limpo, instalar a CLI `openspec` na mesma versão do Windows (`openspec --version`), configurar o `unity-mcp` no Claude Code e verificar com `Unity_GetConsoleLogs` que o Editor responde

## Workflow follow-up

- Abrir um PR com os commits separados da decisão "Migration Plan" (fim de linha primeiro, regras depois).
- Arquivar a mudança com `/opsx:archive` depois que a tarefa 5.2 for feita no Mac.
