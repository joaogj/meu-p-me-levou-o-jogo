# Tasks

## 1. Base do projeto Unity

- [ ] 1.1 Instalar pelo Package Manager os pacotes e módulos do design (decisão 1) e verificar que o Editor abre sem erros no console e que `packages-lock.json` foi atualizado
- [ ] 1.2 Criar o URP Asset e o Renderer, atribuí-los em Graphics e Quality, e verificar que uma cena vazia renderiza sem materiais rosa
- [ ] 1.3 Criar as pastas `Assets/Scripts`, `Assets/Scenes`, `Assets/Tests/EditMode` e `Assets/Tests/PlayMode` com seus assembly definitions, e verificar que o Test Runner lista as duas suítes vazias
- [ ] 1.4 Atualizar o `.gitignore` com `server/node_modules/` e `.env`, e verificar com `git status` que nenhum desses arquivos aparece

## 2. Jaime, controles e câmera

- [ ] 2.1 Criar `Jaime.inputactions` com o mapa "Exploracao" (decisão 3) e verificar no Input Debugger que WASD, Shift, mouse, Q, Tab, F e Esc disparam as ações
- [ ] 2.2 Implementar o movimento do Jaime com `CharacterController` e fôlego para correr, com teste EditMode da regra de fôlego (gasta correndo, recupera andando, não corre com fôlego zerado)
- [ ] 2.3 Montar a cena `M0_Caxias` com uma viela de blocos cinza que inclua um trecho com largura de três vezes o ombro do Jaime, e verificar que dá para andar de ponta a ponta
- [ ] 2.4 Configurar a Cinemachine Camera com Third Person Follow e troca de ombro pela tecla Q, com teste PlayMode que percorre o trecho estreito e falha se a câmera entrar em uma parede
- [ ] 2.5 Adicionar o balanço de câmera opcional com uma configuração para desligar, e verificar manualmente que, desligado, a câmera fica estável

## 3. Celular

- [ ] 3.1 Implementar a bateria como classe C# sem dependência de cena, com teste EditMode para consumo da lanterna, consumo por mensagem e bloqueio em 0%
- [ ] 3.2 Criar a tela do celular em UI Toolkit, aberta e fechada com Tab, e verificar que Esc também fecha
- [ ] 3.3 Ligar a lanterna à tecla F e à bateria, e verificar que com 0% a lanterna não acende e aparece o aviso de bateria

## 4. Queda de luz

- [ ] 4.1 Criar os grupos Normal e Outro Lado e o Volume do Outro Lado na cena, e verificar que alternar os grupos à mão no Editor dá o efeito esperado
- [ ] 4.2 Implementar o gatilho de área que dispara uma única vez (decisão 5), com teste PlayMode que entra duas vezes no gatilho e confirma uma única troca
- [ ] 4.3 Trocar o áudio de ambiente no gatilho (som provisório) e verificar manualmente a troca

## 5. Servidor do chat da Mari

- [ ] 5.1 Criar o serviço Node.js em `server/` com o endpoint `POST /mari` e o README de como rodar, e verificar com `curl` que ele responde com um cliente falso no lugar da API
- [ ] 5.2 Escrever a personalidade da Mari do capítulo 1 e a lista do que ela não pode revelar, com teste `node --test` que garante que o prompt do capítulo 1 não menciona o ghosting
- [ ] 5.3 Implementar o limite de 30 mensagens por sessão, com teste que confirma a fala de despedida sem chamada à API na 31ª mensagem
- [ ] 5.4 Ligar o SDK da Anthropic com `ANTHROPIC_API_KEY` e o modelo do design, e verificar com uma chave real que a Mari responde em português e sem revelar a reviravolta
- [ ] 5.5 Confirmar com uma busca no projeto que nenhuma chave ou prompt do servidor aparece em `Assets/`

## 6. Chat no jogo

- [ ] 6.1 Implementar o cliente HTTP do chat com timeout de 10 segundos e as falas de reserva do capítulo 1, com teste EditMode que simula erro e timeout e confirma a fala de reserva
- [ ] 6.2 Mostrar "Mari está digitando…" enquanto espera e a resposta no celular, e verificar manualmente com o servidor ligado e desligado

## 7. Validação integrada

- [ ] 7.1 Rodar `openspec validate --all --strict` e verificar zero erros
- [ ] 7.2 Jogar a cena do começo ao fim no Mac: andar pela viela estreita sem a câmera atravessar paredes, acender a lanterna até zerar a bateria, disparar a queda de luz e trocar pelo menos cinco mensagens com a Mari
- [ ] 7.3 Registrar no PR o que funcionou, o que não funcionou e o que muda no GDD por causa disso

## Workflow follow-up

- Arquivar a mudança depois da revisão do João.
