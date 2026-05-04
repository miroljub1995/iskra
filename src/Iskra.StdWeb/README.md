# Iskra.StdWeb

Iskra.StdWeb provides strongly typed C# wrappers for standard browser APIs. The bindings are generated from WebIDL definitions and are intended for .NET WebAssembly applications that need direct access to the browser platform without a Blazor dependency.

## What It Provides

- Generated wrappers for DOM, Fetch, Canvas, WebGL, Web Audio, WebRTC, and other standard Web APIs.
- Typed C# access to browser globals, interfaces, dictionaries, enums, callbacks, and events.
- Integration with [Iskra.JSCore](../Iskra.JSCore/) for proxy creation, type marshalling, JavaScript object lifetime, and callback interop.
- Generated code based on W3C WebIDL data from [webref](https://github.com/w3c/webref).

## Quick Start

Create a browser WebAssembly project and add the package:

```bash
dotnet new wasmbrowser
dotnet add package Iskra.StdWeb
```

Initialize the StdWeb proxy factory before using generated browser types:

```csharp
using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;
using Iskra.StdWeb;

public static class Program
{
    public static async Task Main()
    {
        await StdWebProxyFactory.InitializeAsync();

        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        var document = window.Document;

        var message = document.CreateElement("div");
        message.TextContent = "Hello from C#!";
        document.Body?.AppendChild(message);

        var button = document.CreateElement("button");
        button.TextContent = "Click me";
        document.Body?.AppendChild(button);

        button.AddEventListener("click", new EventListener(ev =>
        {
            window.Console.Log("Button clicked", ev.JSObject);
        }), false);

        await Task.Delay(Timeout.Infinite);
    }
}
```

## Common Patterns

Access browser globals through `JSObjectProxyFactory`:

```csharp
var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
var document = window.Document;
```

Cast created elements to their more specific generated type when you need type-specific members:

```csharp
var input = (HTMLInputElement)document.CreateElement("input");
input.Value = "Initial value";
```

Keep callback objects alive for as long as JavaScript may invoke them. For one-off application-level handlers, assigning the callback to a field is usually the simplest approach.

## Generation

The generated sources live under [AutoGen](AutoGen/) and are produced by [../Iskra.WebIDLGenerator](../Iskra.WebIDLGenerator/). The generator consumes curated WebIDL definitions from the repository's [../../submodules/webref](../../submodules/webref/) submodule.

## Examples

- [../../examples/Iskra.TodoExample](../../examples/Iskra.TodoExample/) creates and updates DOM nodes directly through StdWeb.
- [../../examples/Iskra.CanvasExample](../../examples/Iskra.CanvasExample/) uses generated Canvas bindings for animation.

## Requirements

- .NET 9.0 or later
- Browser with WebAssembly support
