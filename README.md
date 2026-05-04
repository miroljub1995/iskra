# Iskra

Iskra is a .NET WebAssembly toolkit for building browser applications in C#. It combines a JavaScript interop foundation, generated browser API bindings, and an experimental component layer for reactive UI rendering.

The repository is split into a few focused projects:

- [src/Iskra.JSCore](src/Iskra.JSCore/) provides the JavaScript proxy system, type marshalling, and low-level interop utilities.
- [src/Iskra.StdWeb](src/Iskra.StdWeb/) contains generated C# bindings for standard Web APIs such as DOM, Fetch, Canvas, WebGL, and related browser interfaces.
- [src/Iskra.Core](src/Iskra.Core/) contains the component model, DOM components, render roots, server-side rendering primitives, and feature infrastructure.
- [src/Iskra.CoreExample](src/Iskra.CoreExample/) is a browser WebAssembly client app that exercises the Core component layer.
- [src/Iskra.Signals](src/Iskra.Signals/) provides reactive primitives used by the component layer.
- [src/Iskra.WebIDLGenerator](src/Iskra.WebIDLGenerator/) generates C# bindings from WebIDL definitions.

## Documentation

- [src/Iskra.StdWeb/README.md](src/Iskra.StdWeb/README.md) explains the generated browser API bindings and direct DOM-style usage.
- [src/Iskra.Core/README.md](src/Iskra.Core/README.md) explains the component framework and rendering model.
- [examples/README.md](examples/README.md) describes the runnable sample applications.

## Quick Start

Create a WebAssembly browser project and reference the Iskra package that matches the layer you want to use:

```bash
dotnet new wasmbrowser
dotnet add package Iskra.StdWeb
```

For direct browser API access, initialize StdWeb and get typed proxies for browser globals:

```csharp
using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;
using Iskra.StdWeb;

await StdWebProxyFactory.InitializeAsync();

var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
var document = window.Document;

var div = document.CreateElement("div");
div.TextContent = "Hello from Iskra";
document.Body?.AppendChild(div);
```

See [src/Iskra.StdWeb/README.md](src/Iskra.StdWeb/README.md) for the full StdWeb overview.
For component-based browser client apps, see [src/Iskra.Core/README.md](src/Iskra.Core/README.md).

## Examples

The [examples](examples/) directory contains package-based examples:

- [examples/Iskra.TodoExample](examples/Iskra.TodoExample/) shows dynamic DOM rendering and keyboard events.
- [examples/Iskra.CanvasExample](examples/Iskra.CanvasExample/) shows Canvas API usage and animation.

Run an example from its directory:

```bash
cd examples/Iskra.TodoExample
dotnet run
```

## Requirements

- .NET 9.0 or later
- Browser with WebAssembly support

## Status

Iskra is under active development. APIs may change as the core abstractions, generated bindings, and packaging mature.

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
