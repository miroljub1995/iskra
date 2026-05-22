# Iskra.Core

Iskra.Core is the experimental component layer for Iskra. It builds on Iskra.StdWeb and Iskra.Signals to provide components, typed DOM component wrappers, reactive rendering, browser rendering roots, and server-side rendering primitives.

## Before Initial Release

### Bug fixes
- [ ] Fix hot reload (`HotReloadManager`) — currently has bugs. It should know if component needs to remount, or whole app to remount. Dotnet sdk do not support hook before apply changes, which would be ideal for unmounting the components.

### Core features
- [ ] **Assets** — define a way to use assets like avif, webp, ...

### Router
- [ ] **Router** — URL-based navigation, route params, guards, nested routes, with both client-side and server-side rendering support

## What It Provides

- A component contract through `IComponent` and `BaseComponent<TProps, TEvents, TExpose>`.
- Reactive child rendering with `If` and `ForEach`.
- Typed DOM components under [DomComponents](DomComponents/) such as `Div`, `Button`, `Input`, `Canvas`, and standard HTML elements.
- Browser rendering through `DomRenderRoot` and server rendering through `SsrRenderRoot`.
- Host setup for browser WebAssembly client apps through `IskraHostBuilder`.
- Feature propagation through `IFeatureCollection` and `AppFeatures`.

## Basic Shape

Components return child components from `Setup`. Props are usually regular C# objects containing signals, and DOM components receive props, events, refs, and children.

```csharp
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

public sealed class CounterProps
{
    public required IReadOnlySignal<int> Count { get; init; }
}

public sealed class Counter : BaseComponent<CounterProps, BaseEmits, NoSlots, object>
{
    protected override IComponent[] Setup(out object exposed)
    {
        exposed = new object();

        return
        [
            new Div
            {
                Children =
                [
                    new DomText
                    {
                        Text = new Computed<string>(() => $"Count: {Props.Count.Value}")
                    }
                ]
            }
        ];
    }
}
```

## WebAssembly Client App

A browser WebAssembly client app should initialize StdWeb, resolve the root DOM element, and mount the component tree through `IskraHostBuilder`. The host sets up the feature context that components expect while mounting.

```csharp
using System.Runtime.InteropServices.JavaScript;
using Iskra.Core;
using Iskra.Core.RenderRoot;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;

if (!OperatingSystem.IsBrowser())
{
    throw new PlatformNotSupportedException();
}

await StdWebProxyFactory.InitializeAsync();

var window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
var rootElement = window.Document.GetElementById("app")
    ?? throw new InvalidOperationException("App element not found.");

var count = new Signal<int>(0);

using var app = new IskraHostBuilder()
    .UseRootElement(rootElement)
    .UseRootComponent(() => new Counter
    {
        Props = new CounterProps { Count = count }
    })
    .Build()
    .Mount();

await Task.Delay(Timeout.Infinite);
```

Use `UseRootRenderer` instead of `UseRootElement` when you need to provide a custom render root, such as a test DOM root or an SSR root.

## Server Rendering

The [RenderRoot](RenderRoot/) folder also contains SSR types such as `SsrRenderRoot`, `SsrRenderSlot`, `SsrElementNode`, and `SsrTextNode`. DOM component props register separate browser and server effects so the same component tree can target browser DOM or SSR output.

## Slots

Components can accept slot content from their parent via the `Slots` property. Use `BaseComponent<TProps, TEvents, TSlots, TExpose>` (4 type parameters) instead of the 3-parameter variant. Define a POCO class for `TSlots` with `Func<IComponent[]>` properties — one per named slot.

```csharp
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

public sealed class CardSlots
{
    public required Func<IComponent[]> Header { get; init; }
    public Func<IComponent[]>? Footer { get; init; }
}

public sealed class Card : BaseComponent<object, BaseEmits, CardSlots, object>
{
    protected override IComponent[] Setup(out object exposed)
    {
        exposed = new();
        return
        [
            new Header { Children = Slots?.Header() ?? [] },
            new Footer { Children = Slots?.Footer?.Invoke() ?? [] },
        ];
    }
}
```

The parent provides slot content as callbacks:

```csharp
new Card
{
    Props = new(),
    Slots = new CardSlots
    {
        Header = () => [new DomText { Text = new Signal<string>("Title") }],
        Footer = () => [new DomText { Text = new Signal<string>("Footer") }],
    }
}
```

Slots are lazy — the component decides when and whether to call each callback. For scoped slots (passing data back to the caller), change the delegate signature in your slots class, e.g. `Func<IReadOnlySignal<TItem>, IComponent[]>`.

## Examples

See [../Iskra.CoreExample](../Iskra.CoreExample/) for a browser WebAssembly client app using signals, DOM components, refs, events, and `ForEach`.
