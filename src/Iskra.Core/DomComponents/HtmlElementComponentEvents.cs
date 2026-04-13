using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class HtmlElementComponentEvents<TElement> : ElementComponentEvents<TElement>
    where TElement : HTMLElement
{
    // Drag & drop events
    public Action<DragEvent>? OnDrag { get; init; }
    public Action<DragEvent>? OnDragEnd { get; init; }
    public Action<DragEvent>? OnDragEnter { get; init; }
    public Action<DragEvent>? OnDragLeave { get; init; }
    public Action<DragEvent>? OnDragOver { get; init; }
    public Action<DragEvent>? OnDragStart { get; init; }
    public Action<DragEvent>? OnDrop { get; init; }

    // Toggle events
    public Action<ToggleEvent>? OnBeforeToggle { get; init; }
    public Action<ToggleEvent>? OnToggle { get; init; }

    // Other events
    public Action<Event>? OnChange { get; init; }
    public Action<CommandEvent>? OnCommand { get; init; }
    public Action<ErrorEvent>? OnError { get; init; }
    public Action<Event>? OnLoad { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Func<TElement, Action>> register)
    {
        base.RegisterClientEffects(register);

        // Drag & drop events
        if (OnDrag is not null)
            RegisterEventListener(register, OnDrag, "drag");
        if (OnDragEnd is not null)
            RegisterEventListener(register, OnDragEnd, "dragend");
        if (OnDragEnter is not null)
            RegisterEventListener(register, OnDragEnter, "dragenter");
        if (OnDragLeave is not null)
            RegisterEventListener(register, OnDragLeave, "dragleave");
        if (OnDragOver is not null)
            RegisterEventListener(register, OnDragOver, "dragover");
        if (OnDragStart is not null)
            RegisterEventListener(register, OnDragStart, "dragstart");
        if (OnDrop is not null)
            RegisterEventListener(register, OnDrop, "drop");

        // Toggle events
        if (OnBeforeToggle is not null)
            RegisterEventListener(register, OnBeforeToggle, "beforetoggle");
        if (OnToggle is not null)
            RegisterEventListener(register, OnToggle, "toggle");

        // Other events
        if (OnChange is not null)
            RegisterEventListener(register, OnChange, "change");
        if (OnCommand is not null)
            RegisterEventListener(register, OnCommand, "command");
        if (OnError is not null)
            RegisterEventListener(register, OnError, "error");
        if (OnLoad is not null)
            RegisterEventListener(register, OnLoad, "load");
    }
}