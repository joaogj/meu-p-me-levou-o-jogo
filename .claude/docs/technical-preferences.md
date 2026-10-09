# Technical Preferences

## Engine & Language

- **Engine**: Unity 6000.6.4f1
- **Language**: C#
- **Rendering**: URP 17.6.0 (Render Graph), low-poly with PS2-style filter
- **Physics**: Unity Physics (PhysX, 3D)

## Input & Platform

- **Target Platforms**: PC (Steam)
- **Input Methods**: Keyboard/Mouse, Gamepad
- **Primary Input**: Keyboard/Mouse (WASD, mouse look, E to interact)
- **Gamepad Support**: Partial (equivalent controls for every action)
- **Touch Support**: None
- **Platform Notes**: Input System package 1.20.1 only (no legacy Input Manager). Third-person over-the-shoulder camera via Cinemachine.

## Naming Conventions

- **Classes**: PascalCase (`PlayerController`)
- **Public fields/properties**: PascalCase (`MoveSpeed`)
- **Private fields**: _camelCase (`_moveSpeed`)
- **Methods**: PascalCase (`TakeDamage()`)
- **Signals/Events**: PascalCase, past tense for C# events (`HealthChanged`)
- **Files**: PascalCase matching the class (`PlayerController.cs`)
- **Scenes/Prefabs**: PascalCase (`M0_Caxias.unity`, `Jaime.prefab`)
- **Constants**: PascalCase

## Performance Budgets

- **Target Framerate**: 60 fps
- **Frame Budget**: 16.6 ms
- **Draw Calls**: ~1500 per frame (low-poly; dynamic batching is removed in Unity 6.6, use SRP Batcher/GPU instancing)
- **Memory Ceiling**: 4 GB

## Testing

- **Framework**: Unity Test Framework 1.8.0 (NUnit), EditMode and PlayMode
- **Minimum Coverage**: [TO BE CONFIGURED]
- **Required Tests**: Balance formulas, gameplay systems, networking (if applicable)

## Forbidden Patterns

- [None configured yet — add as architectural decisions are made]

## Allowed Libraries / Addons

- [None configured yet — add as dependencies are approved]

## Architecture Decisions Log

- [No ADRs yet — use /architecture-decision to create one]

## Engine Specialists

- **Primary**: unity-specialist
- **Language/Code Specialist**: unity-specialist (C# review — primary covers it)
- **Shader Specialist**: unity-shader-specialist (Shader Graph, HLSL, URP/HDRP materials)
- **UI Specialist**: unity-ui-specialist (UI Toolkit UXML/USS, UGUI Canvas, runtime UI)
- **Additional Specialists**: unity-dots-specialist (ECS, Jobs system, Burst compiler), unity-addressables-specialist (asset loading, memory management, content catalogs)
- **Routing Notes**: Invoke primary for architecture and general C# code review. Invoke DOTS specialist for any ECS/Jobs/Burst code. Invoke shader specialist for rendering and visual effects. Invoke UI specialist for all interface implementation. Invoke Addressables specialist for asset management systems.

### File Extension Routing

| File Extension / Type | Specialist to Spawn |
|-----------------------|---------------------|
| Game code (.cs files) | unity-specialist |
| Shader / material files (.shader, .shadergraph, .mat) | unity-shader-specialist |
| UI / screen files (.uxml, .uss, Canvas prefabs) | unity-ui-specialist |
| Scene / prefab / level files (.unity, .prefab) | unity-specialist |
| Native extension / plugin files (.dll, native plugins) | unity-specialist |
| General architecture review | unity-specialist |
