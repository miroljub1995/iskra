# Iskra.Templates

dotnet new templates for bootstrapping Iskra applications.

## Included templates

- `iskra`: docs-style Iskra web app with server + WebAssembly client projects, Tailwind CSS integration, and minimal Home/About routing.

## Install from NuGet

```bash
dotnet new install Iskra.Templates
```

Create an app:

```bash
dotnet new iskra -n MyIskraApp
```

Run it:

```bash
dotnet run --project MyIskraApp/MyIskraApp.csproj
```

## Local development

Build and pack:

```bash
dotnet pack src/Iskra.Templates/Iskra.Templates.csproj -c Release -o artifacts/nuget
```

Install local package:

```bash
dotnet new install artifacts/nuget/Iskra.Templates.*.nupkg
```

Reinstall during development:

```bash
dotnet new uninstall Iskra.Templates
dotnet new install artifacts/nuget/Iskra.Templates.*.nupkg
```