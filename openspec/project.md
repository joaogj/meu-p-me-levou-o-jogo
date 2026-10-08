# Contexto do projeto

## Propósito
Paródia de terror psicológico de Silent Hill 2. Jaime Sunderlândio, do Leblon, atravessa a Baixada Fluminense de madrugada atrás da Mari, um match que sumiu há 3 anos e reaparece dizendo "me encontra no meu lugar feliz".

## Tom
Terror sério, com humor que nasce das situações. A piada nunca é o morador: quem é ridicularizado é o preconceito e a covardia do Jaime.

## Stack
- Unity 6 com URP, 3D linear em terceira pessoa (câmera atrás do ombro com Cinemachine), visual low-poly com filtro de PS2
- GDD completo em `docs/GDD.md`
- Primeira proposta: `openspec/changes/prototipo-m0-caxias/` (protótipo de Caxias com câmera, celular, queda de luz e chat com a Mari)
- Controles: padrão de PC para terceira pessoa atrás do ombro (WASD, mouse, E para interagir), com equivalência para controle de videogame
- C# nos scripts do jogo
- Claude API para o chat da Mari e as conversas com NPCs, sempre por um servidor intermediário (a chave nunca vai no cliente)

## Convenções
- Specs e documentação em português; as palavras-chave do formato OpenSpec (SHALL, MUST, WHEN, THEN, Scenario) ficam em inglês para a validação funcionar.
- Toda feature nova começa como proposta em `openspec/changes/`.
