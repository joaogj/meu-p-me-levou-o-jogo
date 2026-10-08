# Design

## Context

Veja proposal.md (Why). O projeto Unity está no Editor 6000.6.4f1, com `Packages/manifest.json` contendo só `com.unity.modules.tetgen`. Isso quer dizer que módulos básicos como física, áudio, UI e rede estão desligados, e não há URP, Cinemachine nem Input System. O render pipeline atual é o Built-in. `Assets/` está vazia.

O Editor do Unity roda no Mac do João. O ambiente do Claude na nuvem não roda o Editor, então qualquer verificação dentro do Unity acontece no Mac (pelo próprio João ou por uma sessão do Claude rodando no Mac).

## Goals / Non-Goals

**Goals:**
- Deixar o projeto com a base técnica que as próximas fases vão reutilizar (pipeline, câmera, input, testes).
- Medir os três riscos em uma cena pequena e descartável.
- Deixar as falas da Mari em dados, para que o chat com o Claude possa entrar depois sem refazer a tela do celular.

**Non-Goals:**
- Arquitetura final de cenas, save ou carregamento de fases.
- Arte, áudio e interface finais. Tudo é provisório (blocos cinza, texto simples).
- Chat livre com o Claude, servidor intermediário e chave da API. Ficam para uma mudança futura.

## Decisions

### 1. Pacotes e módulos
Instalar pelo Package Manager: URP (`com.unity.render-pipelines.universal`), Cinemachine 3 (`com.unity.cinemachine`), Input System (`com.unity.inputsystem`), Test Framework (`com.unity.test-framework`), uGUI/TextMeshPro (`com.unity.ugui`) e os módulos `physics`, `animation`, `audio`, `imgui`, `jsonserialize`, `uielements`. As versões ficam por conta do Package Manager para o Editor 6000.6 e são travadas no `packages-lock.json`. Alternativa descartada: fixar versões à mão no manifest, que arrisca versões incompatíveis com o Editor.

### 2. Render pipeline
Criar um URP Asset e um Renderer próprios e atribuí-los em Graphics e Quality. A troca para o Outro Lado usa um segundo Volume de pós-processamento. Alternativa descartada: ficar no Built-in, que não combina com o visual PS2 planejado nem com os Volumes.

### 3. Input
Usar o Input System com um único Input Actions asset (`Jaime.inputactions`) e um mapa "Exploracao" com as ações Mover, Olhar, Correr, TrocarOmbro, Celular, Lanterna e Pausar. Alternativa descartada: o Input Manager antigo, que não oferece o remapeamento e a troca de dispositivo exigidos pela spec `controles` nas próximas fases.

### 4. Personagem e câmera
Jaime com `CharacterController`, movimento relativo à câmera e fôlego para correr. Câmera com Cinemachine Camera e o componente Third Person Follow, que já faz a câmera se aproximar do personagem quando há parede no caminho. Trocar de ombro anima o lado do Third Person Follow. O balanço opcional usa o ruído do Cinemachine e liga ou desliga por uma configuração. Alternativa descartada: câmera própria com raycast, que dá mais trabalho e reinventa o que o Cinemachine já resolve.

### 5. Queda de luz
Uma única cena com dois grupos de objetos, Normal e Outro Lado. Um gatilho de área dispara uma só vez: apaga as luzes do grupo Normal, ativa o grupo Outro Lado, liga o Volume do Outro Lado e troca o áudio de ambiente. Alternativa descartada: carregar uma segunda cena, o que exigiria um sistema de carregamento fora do escopo do M0.

### 6. Celular e interface
Interface em UI Toolkit (UXML/USS), com a tela do celular sobreposta e a lista de mensagens do chat. A bateria é um valor de 0 a 100 que cai com a lanterna ligada e a cada mensagem enviada. A lógica de bateria fica em uma classe C# simples, sem depender de cena, para ser testada no modo EditMode. Alternativa descartada: uGUI, que também funciona, mas o UI Toolkit é o caminho recomendado para interfaces novas no Unity 6.

### 7. Chat com a Mari
O chat usa falas estáticas. Cada passo da conversa oferece de duas a três mensagens prontas para o jogador escolher, e cada escolha leva a uma resposta escrita da Mari e ao próximo passo. A conversa fica em um ScriptableObject (`ConversaMari`), com nós de fala e escolhas, e uma classe C# sem dependência de cena percorre esses nós. O "Mari está digitando…" aparece por um tempo curto antes de cada resposta, para manter o clima. Cada mensagem enviada gasta bateria.

A interface do chat pede a próxima resposta a uma interface (`IFonteDeFalas`). No M0 a única implementação lê o ScriptableObject. Quando o chat com o Claude entrar, ele vira outra implementação, e as falas estáticas passam a ser a reserva sem conexão prevista na spec `celular`. Alternativa descartada: campo de texto livre com respostas fixas, que soaria quebrado porque a Mari ignoraria o que o jogador escreveu.

### 8. Testes
- Unity Test Framework: EditMode para bateria, fôlego e o percurso da conversa; PlayMode para câmera na viela e gatilho de queda de luz.

## Risks / Trade-offs

- [O Third Person Follow não se comportar bem em vielas muito estreitas] → testar com a viela mais estreita do GDD (largura de três vezes o ombro) e ajustar o raio de colisão antes de seguir.
- [Falas estáticas não provarem o risco do chat com IA] → aceito por decisão do João; o M0 valida a tela e o ritmo da conversa, e o chat com o Claude será validado na mudança que o introduzir.
- [Verificação depender do Mac] → as tarefas do Unity terminam com um teste ou um passo manual que roda no Editor; os testes EditMode também.
- [Versões dos pacotes mudarem] → o `packages-lock.json` versionado trava o que foi instalado.

## Migration Plan

Não se aplica: projeto novo, sem jogadores nem dados. Para desfazer, basta reverter o PR.
