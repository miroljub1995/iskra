# Iskra ⚡

A .NET library for WebAssembly development, featuring automatic C# bindings generation from WebIDL specifications for seamless JavaScript interop.

## Overview

Iskra provides tools and infrastructure for building WebAssembly applications with .NET. At its core is a powerful WebIDL code generator that automatically creates strongly-typed C# wrappers for browser APIs, enabling you to use web platform APIs (DOM, WebGL, Canvas, etc.) with full IntelliSense support and compile-time type safety.

### Key Features

- **🔄 Automatic Code Generation**: Generates C# bindings from WebIDL specifications
- **🌐 Comprehensive Browser API Coverage**: Access to Web APIs through auto-generated, strongly-typed C# wrappers
- **🎯 Type-Safe**: Leverage C#'s type system for safer JavaScript interactions
- **📦 Standards-Based**: Uses official W3C WebIDL specifications from [webref](https://github.com/w3c/webref)
- **🚀 No Blazor Required**: Works with any .NET WebAssembly project, not tied to Blazor

## Architecture

### Core Libraries

- **Iskra.JSCore**: Core JavaScript interop layer with proxy system, type marshalling, and utilities
- **Iskra.StdWeb**: Auto-generated wrappers for standard Web APIs (DOM, Fetch, Canvas, WebGL, etc.)

### Tools

- **Iskra.WebIDLGenerator**: Command-line tool that generates C# code from WebIDL specifications
- **Iskra.WebIDLGenerator.Tests**: Comprehensive test suite for the generator

## Quick Start

### Use in Your Project

1. Create a new WebAssembly project:
   ```bash
   dotnet new wasmbrowser
   ```
2. Install the `Iskra.StdWeb` NuGet package
3. Use the generated bindings:

```csharp
using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;
using Iskra.StdWeb;

public static class Program
{
    static async Task Main(string[] args)
    {
        // Initialize the proxy factory
        await StdWebProxyFactory.InitializeAsync();

        // Get the window object
        var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        var document = window.Document;

        // Create and append a div
        var div = document.CreateElement("div");
        div.TextContent = "Hello from C#!";
        document.Body?.AppendChild(div);

        // Add event listener
        var button = document.CreateElement("button");
        button.TextContent = "Click me";
        document.Body?.AppendChild(button);
        
        button.AddEventListener("click", new EventListener(e =>
        {
            window.Console.Log("Button clicked!", e.JSObject);
        }), false);

        await Task.Delay(Timeout.Infinite);
    }
}
```

### Try the Examples

See the [examples](examples/) directory for sample projects demonstrating:
- Interactive todo list
- Canvas animations

## Project Structure

```
src/
├── Iskra.JSCore/            # JavaScript interop foundation
├── Iskra.StdWeb/            # Generated web API wrappers
├── Iskra.WebIDLGenerator/   # Code generation tool
├── Iskra.WebIDLGenerator.Tests/  # Generator tests
└── Iskra.App*/              # Component framework and examples

examples/                    # Package-based examples
├── Iskra.TodoExample/       # Todo list application
└── Iskra.CanvasExample/     # Canvas animation demo
```

## Contributing

We welcome contributions! Please see our [issue templates](.github/ISSUE_TEMPLATE/) for:

- [Bug Reports](.github/ISSUE_TEMPLATE/bug_report.md)
- [Feature Requests](.github/ISSUE_TEMPLATE/feature_request.md)

## Requirements

- .NET 9.0 or later
- Browser with WebAssembly support

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Status

🚧 **Active Development**: This project is actively being developed. Additional features and improvements are planned for future releases.
