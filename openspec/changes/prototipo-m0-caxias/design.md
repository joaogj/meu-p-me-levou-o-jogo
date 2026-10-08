# Design

## Context

Veja proposal.md (Why). O projeto Unity está no Editor 6000.6.4f1, com `Packages/manifest.json` contendo só `com.unity.modules.tetgen`. Isso quer dizer que módulos básicos como física, áudio, UI e rede estão desligados, e não há URP, Cinemachine nem Input System. O render pipeline atual é o Built-in. `Assets/` está vazia.

O Editor do Unity roda no Mac do João. O ambiente do Claude na nuvem não roda o Editor, então qualquer verificação dentro do Unity acontece no Mac (pelo próprio João ou por uma sessão do Claude rodando no Mac).

## Goals / Non-Goals

**Goals:**
- Deixar o projeto com a base técnica que as próximas fases vão reutilizar (pipeline, câmera, input, testes).
- Medir os três riscos em uma cena pequena e descartável.
- Manter a chave da API fora do build desde o primeiro dia.

**Non-Goals:**
- Arquitetura final de cenas, save ou carregamento de fases.
- Arte, áudio e interface finais. Tudo é provisório (blocos cinza, texto simples).
- Hospedar o servidor na internet. No M0 ele roda localmente no Mac.

## Decisions

### 1. Pacotes e módulos
Instalar pelo Package Manager: URP (`com.unity.render-pipelines.universal`), Cinemachine 3 (`com.unity.cinemachine`), Input System (`com.unity.inputsystem`), Test Framework (`com.unity.test-framework`), uGUI/TextMeshPro (`com.unity.ugui`) e os módulos `physics`, `animation`, `audio`, `imgui`, `jsonserialize`, `uielements`, `unitywebrequest`. As versões ficam por conta do Package Manager para o Editor 6000.6 e são travadas no `packages-lock.json`. Alternativa descartada: fixar versões à mão no manifest, que arrisca versões incompatíveis com o Editor.

### 2. Render pipeline
Criar um URP Asset e um Renderer próprios e atribuí-los em Graphics e Quality. A troca para o Outro Lado usa um segundo Volume de pós-processamento. Alternativa descartada: ficar no Built-in, que não combina com o visual PS2 planejado nem com os Volumes.

### 3. Input
Usar o Input System com um único Input Actions asset (`Jaime.inputactions`) e um mapa "Exploracao" com as ações Mover, Olhar, Correr, TrocarOmbro, Celular, Lanterna e Pausar. Alternativa descartada: o Input Manager antigo, que não oferece o remapeamento e a troca de dispositivo exigidos pela spec `controles` nas próximas fases.

### 4. Personagem e câmera
Jaime com `CharacterController`, movimento relativo à câmera e fôlego para correr. Câmera com Cinemachine Camera e o componente Third Person Follow, que já faz a câmera se aproximar do personagem quando há parede no caminho. Trocar de ombro anima o lado do Third Person Follow. O balanço opcional usa o ruído do Cinemachine e liga ou desliga por uma configuração. Alternativa descartada: câmera própria com raycast, que dá mais trabalho e reinventa o que o Cinemachine já resolve.

### 5. Queda de luz
Uma única cena com dois grupos de objetos, Normal e Outro Lado. Um gatilho de área dispara uma só vez: apaga as luzes do grupo Normal, ativa o grupo Outro Lado, liga o Volume do Outro Lado e troca o áudio de ambiente. Alternativa descartada: carregar uma segunda cena, o que exigiria um sistema de carregamento fora do escopo do M0.

### 6. Celular e interface
Interface em UI Toolkit (UXML/USS), com a tela do celular sobreposta e um campo de texto para o chat. A bateria é um valor de 0 a 100 que cai com a lanterna ligada e a cada mensagem enviada. A lógica de bateria fica em uma classe C# simples, sem depender de cena, para ser testada no modo EditMode. Alternativa descartada: uGUI, que também funciona, mas o UI Toolkit é o caminho recomendado para interfaces novas no Unity 6.

### 7. Chat com a Mari
O jogo envia para o servidor local (`http://localhost:8787/mari`) o id da sessão, o capítulo, a lista de descobertas e a mensagem do jogador. O servidor guarda a personalidade da Mari por capítulo e a lista do que ela não pode revelar, monta o prompt e chama o Claude com o modelo Haiku (`claude-haiku-5-5`). Ele responde com o texto e a origem ("claude" ou "reserva"). Se o servidor não responder em 10 segundos, ou responder com erro, o jogo usa uma fala de reserva do capítulo guardada no próprio jogo. O "Mari está digitando…" fica na tela enquanto espera.

Os prompts ficam no servidor, não no jogo, para que nem a chave nem as instruções sobre a reviravolta fiquem expostas no build. O servidor conta mensagens por sessão e, ao passar do limite (30 no M0), devolve uma fala de despedida pré-escrita sem chamar a API.

Servidor em Node.js com o SDK oficial da Anthropic, chave lida da variável de ambiente `ANTHROPIC_API_KEY`. Alternativa descartada: chamar a API direto do Unity, que exigiria a chave dentro do build.

### 8. Testes
- Unity Test Framework: EditMode para bateria, fôlego e escolha da fala de reserva; PlayMode para câmera na viela e gatilho de queda de luz.
- Servidor: testes com `node --test`, usando um cliente falso no lugar da API, para cobrir limite de mensagens, timeout e a ausência de spoilers no prompt.

## Risks / Trade-offs

- [O Third Person Follow não se comportar bem em vielas muito estreitas] → testar com a viela mais estreita do GDD (largura de três vezes o ombro) e ajustar o raio de colisão antes de seguir.
- [Latência do chat atrapalhar o clima] → o "digitando…" mascara a espera; a fala de reserva cobre o pior caso.
- [O modelo revelar a reviravolta mesmo com instruções] → a lista de proibições fica no prompt do servidor e há um teste que verifica que o prompt do capítulo 1 não contém a revelação; a revisão manual das respostas faz parte da validação.
- [Verificação depender do Mac] → as tarefas do Unity terminam com um teste ou um passo manual que roda no Editor; as do servidor podem ser verificadas na nuvem.
- [Versões dos pacotes mudarem] → o `packages-lock.json` versionado trava o que foi instalado.

## Migration Plan

Não se aplica: projeto novo, sem jogadores nem dados. Para desfazer, basta reverter o PR.
