## 1. Projeto base
- [ ] 1.1 Criar o projeto Unity 6 com URP (3D)
- [ ] 1.2 Configurar a cena de teste de Caxias com um cenário de vielas simples (blocos cinza)
- [ ] 1.3 Adicionar o pacote Cinemachine

## 2. Jaime e câmera
- [ ] 2.1 Criar o Jaime com movimento WASD, Shift e Espaço, conforme `controles`
- [ ] 2.2 Câmera atrás do ombro com giro pelo mouse e troca de ombro com Q
- [ ] 2.3 Colisão da câmera nas vielas (a câmera se aproxima em vez de atravessar a parede)

## 3. Celular
- [ ] 3.1 Abrir o celular com Tab e fechar com Tab ou Esc
- [ ] 3.2 Lanterna com F, que consome bateria; com 0% a lanterna não acende
- [ ] 3.3 Mostrar a bateria no HUD

## 4. Queda de luz
- [ ] 4.1 Gatilho de área que apaga a iluminação e troca o cenário para o Outro Lado
- [ ] 4.2 Trilha muda no gatilho (pode ser um som provisório)

## 5. Chat com a Mari
- [ ] 5.1 Servidor mínimo que recebe a mensagem do jogador e chama a API do Claude com o estado do capítulo e a lista do que não pode revelar
- [ ] 5.2 Limite de mensagens por sessão de teste
- [ ] 5.3 Falas de reserva pré-escritas para quando a API não responde em tempo limite
- [ ] 5.4 Chave da API só no servidor, nunca no build do jogo

## 6. Validação
- [ ] 6.1 Rodar `openspec validate --all --strict` sem erros
- [ ] 6.2 Testar manualmente: andar pela viela sem atravessar parede, acender a lanterna até zerar a bateria, disparar a queda de luz e conversar com a Mari
- [ ] 6.3 Registrar no PR o que funcionou e o que não funcionou
