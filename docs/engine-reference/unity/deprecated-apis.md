# Unity — Deprecated APIs

Last verified: 2026-10-08

| Don't use | Use instead |
|-----------|-------------|
| Dynamic batching | SRP Batcher / GPU instancing |
| `CoreBuildData.developmentBuild` | `CoreBuildData.useDiagnosticChecks` |
| `BuildOptions.ForceEnableAssertions` | `PlayerSettings.SetManagedCodeVariant(target, ManagedCodeVariant.Checked)` |
| `#if UNITY_64` | `IntPtr.Size == 8` |
| `#if DEVELOPMENT_BUILD` | `UNITY_ENABLE_CHECKS` / `UNITY_INCLUDE_INSTRUMENTATION` / `Debug.isDebugBuild` |
| `UIToolkitInputConfiguration.SetRuntimeInputBackend` | Remove the call |
| UXML `UxmlFactory` / `UxmlTraits` | `[UxmlElement]` / `[UxmlAttribute]` |
| Cinemachine 2 (`CinemachineVirtualCamera`, `CinemachineBrain` v2 APIs) | Cinemachine 3 (`CinemachineCamera`, components) |
| URP `ScriptableRenderPass.SetupRenderPasses` / compatibility mode (non-Render Graph) | Render Graph API |
| Progressive CPU Lightmapper | Progressive GPU Lightmapper / Compute Light Baker |
| Legacy Input Manager (`UnityEngine.Input`) | Input System package (`InputAction`, `PlayerInput`) |
| `FindObjectOfType` / `FindObjectsOfType` | `FindFirstObjectByType` / `FindObjectsByType` (deprecated since 2023) |
| `Rigidbody.velocity` | `Rigidbody.linearVelocity` (Unity 6) |
