# Unity 6.6 — Current Best Practices

Last verified: 2026-10-08

- Use the Input System package with an `.inputactions` asset; keep keyboard/mouse and gamepad bindings in one action map.
- Use Cinemachine 3 for the over-the-shoulder camera.
- URP: write custom passes against Render Graph; avoid compatibility mode.
- Reduce draw calls with the SRP Batcher and GPU instancing (dynamic batching is gone).
- Guard diagnostics with `UNITY_ENABLE_CHECKS` or `Debug.isDebugBuild`, not `DEVELOPMENT_BUILD`.
- Prefer `[SerializeField]` Dictionaries over custom serialization wrappers in new code.
- Build UI with UI Toolkit `UxmlElement` / `UxmlAttribute`.
- Keep gameplay values data-driven (ScriptableObjects) per project coding standards.
- Test with Unity Test Framework: EditMode for logic, PlayMode for scene behavior.
