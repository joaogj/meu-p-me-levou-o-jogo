# Unity — Breaking Changes

Last verified: 2026-10-08 (source: official 6.6 upgrade guide)

## 6.6 (6000.6)

| Area | Change | Action |
|------|--------|--------|
| Cinemachine | Cinemachine 3 is a core package; different API and data format from CM2 | Use CM3 API (`CinemachineCamera`, not `CinemachineVirtualCamera`) |
| Rendering | Dynamic batching removed (obsolete) | SRP Batcher, GPU instancing, GPU Resident Drawer |
| Rendering | Render Pipeline Core no longer depends on Terrain | Add `com.unity.modules.terrain` if Terrain is used |
| Rendering | Legacy Rendering Debugger APIs (`DebugState`, `DebugStateAttribute`, legacy `DebugUIDrawer`) fail to compile | Use `IDebugDisplaySettingsData`, `ISerializedDebugDisplaySettings`, UI Toolkit widgets |
| Lighting | Progressive CPU Lightmapper deprecated | Progressive GPU Lightmapper or Unity Compute Light Baker |
| Scripting | `UNITY_64` and `DEVELOPMENT_BUILD` defines deprecated; hard errors in 6.8 | `IntPtr.Size == 8`; `UNITY_ENABLE_CHECKS`, `UNITY_INCLUDE_INSTRUMENTATION`, `Debug.isDebugBuild` |
| Scripting | New Managed Code Variant setting (default Release) strips diagnostics from Development Builds | Set Checked/Debug when diagnostics are needed |
| Serialization | `Dictionary<TKey,TValue>` now serialized with `[SerializeField]` | Migrate custom wrappers optionally |
| Editor | YAML word wrapping disabled; "Reduce Version Control Noise" removed | Expect one-time YAML diffs; reserialize assets once |
| UI Toolkit | `UIToolkitInputConfiguration.SetRuntimeInputBackend` removed; UXML Factory/Traits removed | Delete calls; use `UxmlElement`/`UxmlAttribute` |
| Android | Minimum OpenGL ES 3.1; legacy/round icons removed | Not relevant (PC target) |

## Deprecated in 6.6 per release notes
EntityId implicit conversion to int; `GameObject.GetScene(int instanceID)`; managed components (DOTS) deprecated.

## Upcoming
- No CoreCLR before 6.7 (so no C# 14 in 6.6); CoreCLR-related breaks expected around 6.8.
- 6.8: `UNITY_64` and `DEVELOPMENT_BUILD` become compile errors.
