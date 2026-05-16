---
description: "Use when running, debugging, or writing tests for Iskra.Core.Client.Tests or Iskra.WebIDLGenerator.Tests. Covers how browser-wasm tests must be executed via BrowserTestsRunner."
applyTo: "src/Iskra.Core.Client.Tests/**,src/Iskra.WebIDLGenerator.Tests/**,src/Iskra.BrowserTestsRunner/**"
---

# Running Browser-WASM Tests

Do **not** use `dotnet test` — `browser-wasm` tests require a real browser. Use `Iskra.BrowserTestsRunner`, which serves the compiled WASM `AppBundle` and runs tests in headless Chromium via PuppeteerSharp.

To run tests, use the following command from the workspace root — it will automatically build the test project and run the tests:

```bash
dotnet run --project src/Iskra.BrowserTestsRunner -f <tfm> --launch-profile <profile>
```

The `-f` flag is required because `Iskra.BrowserTestsRunner` multi-targets; use the latest .NET version installed on the system.

Available profiles:
- `Iskra.Core.Client.Tests`
- `Iskra.WebIDLGenerator.Tests`
