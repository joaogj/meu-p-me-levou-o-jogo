# GDD: Meu P** Me Levou a Lugares Que Eu Não Iria Nem Armado

**Game Design Document, versão 0.1** (8 out. 2026). Documento vivo: cada seção reflete as decisões já tomadas e marca o que ainda é proposta. As regras que o jogo precisa cumprir ficam em `openspec/specs/`; este documento explica o porquê.

**Legenda:** ✅ decidido pelo João · 🟡 proposta minha, aguardando confirmação · ❓ pergunta em aberto

---

## 1. Visão geral

**Resumo:** terror psicológico em 3D, em terceira pessoa, que parodia Silent Hill 2. Jaime Sunderlândio, analista de marketing do Leblon, recebe uma mensagem da Mari, um match que sumiu há 3 anos: "me encontra no meu lugar feliz". Ele atravessa a Baixada Fluminense de trem, de madrugada, e descobre que o maior monstro da viagem é o próprio preconceito.

**Gênero:** terror psicológico, exploração e puzzles, com humor situacional. ✅
**Câmera:** 3D, terceira pessoa atrás do ombro. ✅
**Plataforma:** PC (Windows) em primeiro lugar, via Unity 6 com URP. 🟡
**Idioma:** português do Brasil, com textos preparados para localização futura. 🟡
**Duração estimada:** 4 a 6 horas na primeira vez, cinco fases. 🟡
**Classificação indicativa:** 14 anos (terror, linguagem). 🟡

## 2. Pilares de design

1. **O medo é do Jaime, não da Baixada.** A cidade espelha o que o visitante carrega por dentro, como em Silent Hill 2. Os moradores são as pessoas mais normais e gentis do jogo. ✅
2. **Terror sério, humor nas situações.** A câmera, a trilha e os sustos são levados a sério; a graça nasce do contraste com o cotidiano brasileiro e do próprio Jaime. ✅
3. **Vulnerável, não herói.** O Jaime é fraco de propósito. A tensão vem de fugir, se esconder e decidir, não de lutar. ✅
4. **A IA serve à história.** O Claude dá vida ao chat da Mari e aos moradores, e nunca estraga a reviravolta. ✅

## 3. Tom e regra de conteúdo ✅

O humor mira o preconceito, o medo e a covardia do Jaime. Nenhum diálogo, NPC, documento ou texto de cenário pode retratar moradores da Baixada como perigosos, burros ou caricatos. Todo conteúdo novo passa por esta regra antes de entrar (ver spec `narrativa`).

Exemplos de humor que funciona: a musiquinha do caminhão de gás vira tema de perseguição; o boneco de posto representa ansiedade; o "depois eu respondo" vira monstro. Exemplos do que evitar: piada com sotaque, pobreza ou criminalidade dos moradores.

## 4. História

### 4.1 Premissa
Três anos atrás, Jaime marcou um encontro com a Mari, que morava na Baixada. No dia, inventou uma desculpa e sumiu. Agora, de madrugada, o app de namoro mostra uma mensagem dela: "me encontra no meu lugar feliz". O perfil some logo depois. Ele pega o trem.

### 4.2 Reviravolta ✅
O Jaime deu ghosting na Mari por preconceito com o lugar onde ela morava. Tudo o que ele enfrenta é ele se convencendo de que "lá é perigoso" para não admitir que foi covarde. Se a Mari está viva e quem mandou a mensagem ficam em aberto até o final.

### 4.3 Estrutura em atos
| Ato | Fases | Sentimento | O que o jogador descobre |
|---|---|---|---|
| 1 | Duque de Caxias | Negação | A mensagem, as regras do Outro Lado, o celular |
| 2 | Nova Iguaçu, São João de Meriti | Aparência e sufoco | Maria, Edinho, Laurinha, pistas de que a Mari era querida |
| 3 | Nilópolis | Memória | O áudio de WhatsApp com a verdade |
| 4 | Japeri | Aceitação | O confronto final e o final escolhido |

## 5. Personagens

| Personagem | Papel | Notas |
|---|---|---|
| **Jaime Sunderlândio**, 34 | Protagonista | Analista de marketing do Leblon. Nunca passou do Galeão pro norte. Dramático, preconceituoso, covarde. Fala "a gente precisa marcar" e nunca marca. |
| **Mari 🌻**, 31 | O date | Match de 3 anos atrás. Aparece pelo chat; tem corpo físico só em memórias e no final. |
| **Maria** | Versão idealizada da Mari | "Versão filtro do Instagram": mais ousada, mais disponível, idêntica nas fotos. Tenta fazer o Jaime desistir. |
| **Ângela** | Moça procurando a mãe | Carrega o lado mais sério e pesado da história. |
| **Edinho** | Quem só queria um podrão em paz | Acha que todo mundo está zoando ele. Alívio cômico com um fundo triste. |
| **Laurinha** | Criança da rua | Conhecia a Mari. Zoa o Jaime sem dó e o guia (e às vezes o enrola). |
| **Moradores** | NPCs de conversa livre | Dono do bar, senhora do ponto, motorista de van. Sempre prestativos e normais. |

## 6. Fases ✅

O trem é o hub entre as fases, no papel da rua principal de Silent Hill.

1. **Duque de Caxias (negação).** O Uber cancela na Linha Vermelha e o Jaime cai a pé no centro, com as chamas da refinaria no horizonte. Tutorial: ele se apavora com tudo e nada acontece até a primeira queda de luz.
2. **Nova Iguaçu (aparência).** Calçadão de lojas de "tudo a 19,90" com manequins que se mexem quando você não olha. Uma UPA no papel do hospital. Aqui ele conhece a Maria.
3. **São João de Meriti (sufoco).** Usamos o apelido histórico de "formigueiro das Américas": vielas que se rearranjam, puzzles de becos. Edinho e Laurinha aparecem aqui.
4. **Nilópolis (memória).** Uma quadra de escola de samba vazia às 3 da manhã, com um ensaio fantasma tocando. Lá fica o "lugar feliz" e o áudio de WhatsApp com a verdade.
5. **Japeri (aceitação).** Última estação do ramal, literalmente o fim da linha. Chefe final e finais.

**Estrutura de cada fase (🟡):** chegada, exploração livre de uma área pequena, uma queda de luz que leva ao Outro Lado, um puzzle central, um encontro com a criatura da fase e o retorno ao trem.

## 7. Gameplay

### 7.1 Loop principal ✅
Explorar, achar pistas e itens, resolver puzzles, fugir das criaturas, conversar, voltar ao trem.

### 7.2 Exploração e puzzles
Chaves, documentos, códigos, portas trancadas e enigmas de becos. O jogo diz que falta algo, nunca onde achar. Dificuldade média, sem quebra-cabeças que exijam conhecimento externo. 🟡

### 7.3 Fuga no lugar de combate ✅
O Jaime só tem armas improvisadas (cano, tábua, chinelo) e golpes lentos. O jogador despista ou se esconde (armário, lixeira grande, banca fechada). O Homem do Gás não se derrota: só se escapa.

### 7.4 Saúde e itens 🟡
Barra de saúde que se recupera com itens do cenário (por exemplo, "guaraná gelado"). Inventário simples com chaves, documentos e poucos itens de recuperação. Sem crafting. Saúde zerada volta ao último save.

### 7.5 Saves ✅
Lanchonetes 24h e bares com a TV ligada. Interagir com a TV salva o jogo e recarrega a bateria do celular.

## 8. Câmera e controles

**Câmera atrás do ombro** com Cinemachine, com colisão para não atravessar paredes em vielas. **Ângulos fixos** só em momentos pontuais: chegada em Caxias, quadra de Nilópolis e cena final em Japeri. Balanço de câmera leve com opção para desligar. ✅

**Controles (🟡):** teclado e mouse ou controle. Andar, correr, esquivar, golpe, interagir, esconder-se, abrir o celular, lanterna.

## 9. O celular ✅

O celular é a ferramenta central e a identidade do jogo.

- **Lanterna:** gasta bateria.
- **Bateria:** recurso escasso; só recarrega nos pontos de save. Com 0%, lanterna e chat ficam indisponíveis.
- **Alerta de criaturas:** vibra e mostra "Mari está digitando…" quando há criatura por perto (o rádio de Silent Hill).
- **Chat com a Mari:** conversa livre controlada pelo Claude (seção 10).

## 10. Claude no jogo ✅

**Chat da Mari.** O jogador escreve livremente e o Claude responde como a Mari. Ele recebe o capítulo atual, o que o jogador já descobriu e a lista do que não pode revelar, para nunca entregar a reviravolta antes de Nilópolis.

**Moradores com conversa livre.** Cada NPC tem uma ficha de personalidade, conhecimento local e a regra de tom no prompt. Sempre prestativos e coerentes.

**Julgamento escondido.** O Claude classifica, sem o jogador saber, como ele trata os moradores (desconfiado e grosso, ou aberto e gentil). Isso pesa na escolha do final.

**Infraestrutura (🟡):**
- Servidor intermediário: a chave da API nunca vai no jogo.
- Modelo rápido e barato para as conversas (Haiku).
- Limite de mensagens por NPC por cena.
- Falas de reserva pré-escritas para jogo offline ou API fora do ar.
- Filtro de segurança: as respostas passam por uma checagem da regra de tom antes de aparecer.

## 11. Criaturas ✅

| Criatura | Representa | Comportamento |
|---|---|---|
| **Homem do Gás** | O castigo que o Jaime acha que merece | Cabeça de botijão e chave de grifo gigante. Anunciado pela musiquinha do caminhão de gás, que fica mais lenta e distorcida conforme se aproxima. Indestrutível. |
| **Boneco de Posto** | A ansiedade | Boneco inflável que se debate sem parar, preso e sufocado. |
| **Senhas** | A espera e o "depois eu respondo" | Atendentes sem rosto chamando "senha 47" em loop. |
| **Manequins do Calçadão** | O ideal de aparência | Corpos perfeitos sem cabeça que se mexem quando ninguém olha. |
| **Mosquitão** | Alívio cômico | Inimigo voador irritante e barulhento, mais piada que ameaça. |

## 12. Finais ✅

O final depende do julgamento escondido (seção 10) e de escolhas na fase final.

| Final | Condição | Resultado |
|---|---|---|
| **Pedir desculpas** | Maioria de conversas gentis e aceitar a culpa | Ele manda a mensagem que devia ter mandado há 3 anos e volta de trem. |
| **Maria** | Maioria de conversas desconfiadas ou grosseiras | Escolhe a versão idealizada e o ciclo recomeça. |
| **Ficou** | Conversas gentis e visitou todos os bares | Aluga uma kitnet em Nilópolis e vira passista. Final "bom" e cômico. |
| **Caramelo** | Secreto | Revela que tudo foi controlado por um vira-lata caramelo num painel de controle. 🟡 condição a definir |

## 13. Direção de arte 🟡

- Low-poly com filtro de PS2: resolução baixa, dithering, névoa de distância, texturas sujas.
- **Mundo normal:** madrugada quente, postes amarelos, ruas reais e reconhecíveis, sempre tratadas com respeito.
- **Outro Lado ("caiu a luz"):** ferrugem, gambiarra viva, fios, postes piscando, tons de laranja e verde doente.
- Referências de tom: Silent Hill 2 (atmosfera), paródia brasileira (cotidiano).

## 14. Áudio 🟡

- Trilha de ambiente em drone, com samples da Baixada processados (trem, rádio, chuva).
- A musiquinha do caminhão de gás é o tema do Homem do Gás.
- A quadra de Nilópolis tem um ensaio fantasma como música diegética.
- Sem dublagem de início: textos legendados. ❓ dublagem da Mari e do Jaime.

## 15. Interface 🟡

HUD mínimo: saúde discreta e o celular como menu principal. Menus em estética de app de namoro envelhecido. Textos em TextMeshPro.

## 16. Técnico 🟡

- Unity 6, URP, C#.
- Cinemachine para a câmera.
- AI Navigation (NavMesh) para criaturas.
- Servidor da IA em serviço separado (a definir) com a chave da API do Claude.
- Estrutura do repositório e specs em OpenSpec; cada feature começa como proposta em `openspec/changes/`.

## 17. Escopo e marcos 🟡

| Marco | Entrega |
|---|---|
| **M0: Protótipo** | Projeto Unity, Jaime andando com câmera atrás do ombro, uma queda de luz, chat da Mari funcionando em Caxias |
| **M1: Fase 1 completa** | Caxias jogável do começo ao fim, Homem do Gás, save, celular completo |
| **M2: Fases 2 a 4** | Nova Iguaçu, São João de Meriti e Nilópolis, NPCs com IA |
| **M3: Fase 5 e finais** | Japeri, julgamento escondido e os 4 finais |
| **M4: Polimento** | Áudio, balanceamento, opções, testes |

## 18. Riscos

| Risco | Mitigação |
|---|---|
| Humor soar como estereótipo | Regra de tom nas specs, revisão de todo conteúdo, moradores sempre gentis |
| Custo e latência da IA | Modelo barato, limite por cena, falas de reserva, "digitando…" mascara a espera |
| IA revelar a reviravolta | Lista de proibições no prompt e checagem das respostas |
| Volume de arte 3D | Low-poly PS2, assets reaproveitados entre fases |
| Escopo grande | Marcos pequenos; M0 antes de qualquer outra coisa |

## 19. Perguntas em aberto ❓

1. Plataforma: só PC ou também web/mobile?
2. Dublagem: textos legendados ou voz para Jaime e Mari?
3. Condição do final secreto "Caramelo".
4. Arte: o João tem referências visuais? Usaremos assets prontos (loja do Unity) ou arte própria?
5. Haverá modo de dificuldade?
