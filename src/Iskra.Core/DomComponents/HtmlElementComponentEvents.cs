using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class HtmlElementComponentEvents<TElement> : ElementComponentEvents<TElement>
    where TElement : HTMLElement
{
    // Drag & drop events
    public Action<DragEvent>? Drag { get; init; }
    public Action<DragEvent>? DragEnd { get; init; }
    public Action<DragEvent>? DragEnter { get; init; }
    public Action<DragEvent>? DragLeave { get; init; }
    public Action<DragEvent>? DragOver { get; init; }
    public Action<DragEvent>? DragStart { get; init; }
    public Action<DragEvent>? Drop { get; init; }

    // Toggle events
    public Action<ToggleEvent>? BeforeToggle { get; init; }
    public Action<ToggleEvent>? Toggle { get; init; }

    // Other events
    public Action<Event>? Change { get; init; }
    public Action<CommandEvent>? Command { get; init; }
    public Action<ErrorEvent>? Error { get; init; }
    public Action<Event>? Load { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Func<TElement, Action>> register)
    {
        base.RegisterClientEffects(register);

        // Drag & drop events
        if (Drag is not null)
            RegisterEventListener(register, Drag, "drag");
        if (DragEnd is not null)
            RegisterEventListener(register, DragEnd, "dragend");
        if (DragEnter is not null)
            RegisterEventListener(register, DragEnter, "dragenter");
        if (DragLeave is not null)
            RegisterEventListener(register, DragLeave, "dragleave");
        if (DragOver is not null)
            RegisterEventListener(register, DragOver, "dragover");
        if (DragStart is not null)
            RegisterEventListener(register, DragStart, "dragstart");
        if (Drop is not null)
            RegisterEventListener(register, Drop, "drop");

        // Toggle events
        if (BeforeToggle is not null)
            RegisterEventListener(register, BeforeToggle, "beforetoggle");
        if (Toggle is not null)
            RegisterEventListener(register, Toggle, "toggle");

        // Other events
        if (Change is not null)
            RegisterEventListener(register, Change, "change");
        if (Command is not null)
            RegisterEventListener(register, Command, "command");
        if (Error is not null)
            RegisterEventListener(register, Error, "error");
        if (Load is not null)
            RegisterEventListener(register, Load, "load");
    }
}