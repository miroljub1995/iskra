using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public static class SignalBindingExtensions
{
    public static Action<InputEvent>? ToDomInputEvent(this ISignal<string> signal, bool reset = true)
    {
        if (!OperatingSystem.IsBrowser())
        {
            return null;
        }

        return CreateInputEventHandler(signal, reset);
    }

    public static Action<Event>? ToDomEvent(this ISignal<string> signal, bool reset = true)
    {
        if (!OperatingSystem.IsBrowser())
        {
            return null;
        }

        return CreateEventHandler(signal, reset);
    }

    [SupportedOSPlatform("browser")]
    private static Action<InputEvent> CreateInputEventHandler(ISignal<string> signal, bool reset)
    {
        return ev =>
        {
            var target = ev.Target;

            if (target is null)
            {
                return;
            }

            BindValue(target, signal, reset);
        };
    }

    [SupportedOSPlatform("browser")]
    private static Action<Event> CreateEventHandler(ISignal<string> signal, bool reset)
    {
        return ev =>
        {
            var target = ev.Target;

            if (target is null)
            {
                return;
            }

            BindValue(target, signal, reset);
        };
    }

    [SupportedOSPlatform("browser")]
    private static void BindValue(EventTarget target, ISignal<string> signal, bool reset)
    {
        if (target is HTMLInputElement input)
        {
            signal.Value = input.Value;

            if (reset)
            {
                input.Value = signal.Value;
            }
        }
        else if (target is HTMLTextAreaElement textArea)
        {
            signal.Value = textArea.Value;

            if (reset)
            {
                textArea.Value = signal.Value;
            }
        }
        else if (target is HTMLSelectElement select)
        {
            signal.Value = select.Value;

            if (reset)
            {
                select.Value = signal.Value;
            }
        }
    }
}
