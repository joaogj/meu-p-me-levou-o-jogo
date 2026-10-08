## ADDED Requirements

### Requirement: Cena de Caxias jogável
O protótipo SHALL conter uma cena de Duque de Caxias com vielas simples, na qual o Jaime pode andar, usar a câmera atrás do ombro e chegar ao gatilho da queda de luz.

#### Scenario: Caminho até a queda de luz
- **WHEN** o jogador anda pelas vielas até a área marcada
- **THEN** o gatilho de queda de luz é ativado uma única vez

### Requirement: Validação das decisões de risco
O protótipo SHALL ser avaliado nos três pontos de risco do GDD: câmera em vielas, troca de cenário pela queda de luz e chat com a Mari pela API.

#### Scenario: Câmera em viela apertada
- **WHEN** o jogador anda em uma viela de largura menor que três vezes o ombro do Jaime
- **THEN** a câmera não atravessa parede em nenhum momento

#### Scenario: Chat com a Mari sem internet
- **WHEN** a API não responde em tempo limite
- **THEN** a Mari responde com uma fala pré-escrita e o jogo continua
