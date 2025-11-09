# Iskra Examples

This directory contains example projects demonstrating how to use Iskra framework.

## Running Examples

Each example is independent. Just navigate to the directory and run:

```bash
cd Iskra.TodoExample
dotnet run
```

> **Note:** To test with local packages instead of NuGet, build and pack the packages first:
> ```bash
> dotnet pack src/Iskra.JSCore/Iskra.JSCore.csproj -c Release
> dotnet pack src/Iskra.StdWeb/Iskra.StdWeb.csproj -c Release
> ```
> The `nuget.config` in this directory is configured to use local package sources.

## Examples

### 1. Iskra.TodoExample - Todo List
An interactive todo list application showcasing dynamic list rendering and keyboard events.

**Run:**
```bash
cd Iskra.TodoExample
dotnet run
```
Opens on http://localhost:9002

---

### 2. Iskra.CanvasExample - Bouncing Balls
A canvas animation demonstrating Canvas API usage and requestAnimationFrame.

**Run:**
```bash
cd Iskra.CanvasExample
dotnet run
```
Opens on http://localhost:9003
