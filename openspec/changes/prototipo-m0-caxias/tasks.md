# Tasks

## 1. Base do projeto Unity

- [x] 1.1 Instalar pelo Package Manager os pacotes e módulos do design (decisão 1) e verificar que o Editor abre sem erros no console e que `packages-lock.json` foi atualizado
- [x] 1.2 Criar o URP Asset e o Renderer, atribuí-los em Graphics e Quality, e verificar que uma cena vazia renderiza sem materiais rosa
- [x] 1.3 Criar as pastas `Assets/Scripts`, `Assets/Scenes`, `Assets/Tests/EditMode` e `Assets/Tests/PlayMode` com seus assembly definitions, e verificar que o Test Runner lista as duas suítes vazias

## 2. Jaime, controles e câmera

- [x] 2.1 Criar `Jaime.inputactions` com o mapa "Exploration" (decisão 3) e verificar no Input Debugger que WASD, Shift, mouse, Q, Tab, F e Esc disparam as ações
- [x] 2.2 Implementar o movimento do Jaime com `CharacterController` e fôlego para correr, com teste EditMode da regra de fôlego (gasta correndo, recupera andando, não corre com fôlego zerado)
- [x] 2.3 Montar a cena `M0_Caxias` com uma viela de blocos cinza que inclua um trecho com largura de três vezes o ombro do Jaime, e verificar que dá para andar de ponta a ponta
- [x] 2.4 Configurar a Cinemachine Camera com Third Person Follow e troca de ombro pela tecla Q, com teste PlayMode que percorre o trecho estreito e falha se a câmera entrar em uma parede
- [x] 2.5 Adicionar o balanço de câmera opcional com uma configuração para desligar, e verificar manualmente que, desligado, a câmera fica estável

## 3. Celular

- [x] 3.1 Implementar a bateria como classe C# sem dependência de cena, com teste EditMode para consumo da lanterna, consumo por mensagem e bloqueio em 0%
- [x] 3.2 Criar a tela do celular em UI Toolkit, aberta e fechada com Tab, e verificar que Esc também fecha
- [x] 3.3 Ligar a lanterna à tecla F e à bateria, e verificar que com 0% a lanterna não acende e aparece o aviso de bateria

## 4. Queda de luz

- [ ] 4.1 Criar os grupos Normal e Outro Lado e o Volume do Outro Lado na cena, e verificar que alternar os grupos à mão no Editor dá o efeito esperado
- [ ] 4.2 Implementar o gatilho de área que dispara uma única vez (decisão 5), com teste PlayMode que entra duas vezes no gatilho e confirma uma única troca
- [ ] 4.3 Trocar o áudio de ambiente no gatilho (som provisório) e verificar manualmente a troca

## 5. Chat com a Mari

- [ ] 5.1 Criar o ScriptableObject `MariConversation` e a interface `IDialogueSource` (decisão 7), com teste EditMode que percorre uma conversa de exemplo do começo ao fim
- [ ] 5.2 Escrever a conversa do capítulo 1 com pelo menos cinco trocas, sem revelar o ghosting, e revisar o texto com o João
- [ ] 5.3 Mostrar no celular as escolhas do jogador, o "Mari está digitando…" e as respostas, e verificar manualmente que cada mensagem enviada gasta bateria e que com 0% não dá para enviar

## 6. Validação integrada

- [ ] 6.1 Rodar `openspec validate --all --strict` e verificar zero erros
- [ ] 6.2 Jogar a cena do começo ao fim no Mac: andar pela viela estreita sem a câmera atravessar paredes, acender a lanterna até zerar a bateria, disparar a queda de luz e trocar pelo menos cinco mensagens com a Mari
- [ ] 6.3 Registrar no PR o que funcionou, o que não funcionou e o que muda no GDD por causa disso

## Workflow follow-up

- Arquivar a mudança depois da revisão do João.
