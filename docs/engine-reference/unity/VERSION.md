# Unity — Version Reference

| Field | Value |
|-------|-------|
| **Engine Version** | Unity 6000.6.4f1 (Unity 6.6) |
| **Project Pinned** | 2026-10-08 |
| **Last Docs Verified** | 2026-10-08 |
| **LLM Knowledge Cutoff** | May 2025 (template baseline; Unity coverage ~2023.x / early 6000.x) |
| **Risk Level** | HIGH — version is beyond LLM training data |

## Packages in use (Packages/manifest.json)

| Package | Version |
|---------|---------|
| com.unity.render-pipelines.universal (URP) | 17.6.0 |
| com.unity.inputsystem | 1.20.1 |
| com.unity.cinemachine | 6.6.0 (Cinemachine 3 API, now a core package) |
| com.unity.test-framework | 1.8.0 |

## Sources

- Upgrade guide 6.6: https://docs.unity.com/en-us/engine/6000.6/manual/upgrade-guides/upgrade-guide-unity66
- What's new in 6.6: https://docs.unity3d.com/6000.6/Documentation/Manual/WhatsNewUnity66.html
- Planned breaking changes 6.6: https://discussions.unity.com/t/planned-breaking-changes-in-unity-6-6/1715134
- Planned breaking changes 6.7: https://discussions.unity.com/t/planned-breaking-changes-in-unity-6-7/1723293

## Not verified

URP 17.6 and Input System 1.20 package changelogs were not found; check Package Manager changelogs before relying on package-specific APIs.

## Files

- breaking-changes.md, deprecated-apis.md, current-best-practices.md
