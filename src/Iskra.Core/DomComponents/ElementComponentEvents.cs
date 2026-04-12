using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ElementComponentEvents<TElement> : BaseDomComponentEvents<TElement>
    where TElement : Element
{
    // Animation events
    public Action<AnimationEvent>? AnimationCancel { get; init; }
    public Action<AnimationEvent>? AnimationEnd { get; init; }
    public Action<AnimationEvent>? AnimationIteration { get; init; }
    public Action<AnimationEvent>? AnimationStart { get; init; }

    // Clipboard events
    public Action<ClipboardEvent>? Copy { get; init; }
    public Action<ClipboardEvent>? Cut { get; init; }
    public Action<ClipboardEvent>? Paste { get; init; }

    // Composition events
    public Action<CompositionEvent>? CompositionEnd { get; init; }
    public Action<CompositionEvent>? CompositionStart { get; init; }
    public Action<CompositionEvent>? CompositionUpdate { get; init; }

    // Focus events
    public Action<FocusEvent>? Blur { get; init; }
    public Action<FocusEvent>? Focus { get; init; }
    public Action<FocusEvent>? FocusIn { get; init; }
    public Action<FocusEvent>? FocusOut { get; init; }

    // Fullscreen events
    public Action<Event>? FullscreenChange { get; init; }
    public Action<Event>? FullscreenError { get; init; }

    // Keyboard events
    public Action<KeyboardEvent>? KeyDown { get; init; }
    public Action<KeyboardEvent>? KeyUp { get; init; }

    // Mouse events
    public Action<PointerEvent>? AuxClick { get; init; }
    public Action<PointerEvent>? Click { get; init; }
    public Action<MouseEvent>? ContextMenu { get; init; }
    public Action<MouseEvent>? DblClick { get; init; }
    public Action<MouseEvent>? MouseDown { get; init; }
    public Action<MouseEvent>? MouseEnter { get; init; }
    public Action<MouseEvent>? MouseLeave { get; init; }
    public Action<MouseEvent>? MouseMove { get; init; }
    public Action<MouseEvent>? MouseOut { get; init; }
    public Action<MouseEvent>? MouseOver { get; init; }
    public Action<MouseEvent>? MouseUp { get; init; }

    // Pointer events
    public Action<PointerEvent>? GotPointerCapture { get; init; }
    public Action<PointerEvent>? LostPointerCapture { get; init; }
    public Action<PointerEvent>? PointerCancel { get; init; }
    public Action<PointerEvent>? PointerDown { get; init; }
    public Action<PointerEvent>? PointerEnter { get; init; }
    public Action<PointerEvent>? PointerLeave { get; init; }
    public Action<PointerEvent>? PointerMove { get; init; }
    public Action<PointerEvent>? PointerOut { get; init; }
    public Action<PointerEvent>? PointerOver { get; init; }
    public Action<PointerEvent>? PointerRawUpdate { get; init; }
    public Action<PointerEvent>? PointerUp { get; init; }

    // Scroll events
    public Action<Event>? Scroll { get; init; }
    public Action<Event>? ScrollEnd { get; init; }
    public Action<SnapEvent>? ScrollSnapChange { get; init; }
    public Action<SnapEvent>? ScrollSnapChanging { get; init; }

    // Touch events
    public Action<TouchEvent>? TouchCancel { get; init; }
    public Action<TouchEvent>? TouchEnd { get; init; }
    public Action<TouchEvent>? TouchMove { get; init; }
    public Action<TouchEvent>? TouchStart { get; init; }

    // Transition events
    public Action<TransitionEvent>? TransitionCancel { get; init; }
    public Action<TransitionEvent>? TransitionEnd { get; init; }
    public Action<TransitionEvent>? TransitionRun { get; init; }
    public Action<TransitionEvent>? TransitionStart { get; init; }

    // Other events
    public Action<InputEvent>? BeforeInput { get; init; }
    public Action<Event>? BeforeMatch { get; init; }
    public Action<Event>? BeforeXrSelect { get; init; }
    public Action<ContentVisibilityAutoStateChangeEvent>? ContentVisibilityAutoStateChange { get; init; }
    public Action<InputEvent>? Input { get; init; }
    public Action<SecurityPolicyViolationEvent>? SecurityPolicyViolation { get; init; }
    public Action<WheelEvent>? Wheel { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Func<TElement, Action>> register)
    {
        base.RegisterClientEffects(register);

        // Animation events
        if (AnimationCancel is not null)
            RegisterEventListener(register, AnimationCancel, "animationcancel");
        if (AnimationEnd is not null)
            RegisterEventListener(register, AnimationEnd, "animationend");
        if (AnimationIteration is not null)
            RegisterEventListener(register, AnimationIteration, "animationiteration");
        if (AnimationStart is not null)
            RegisterEventListener(register, AnimationStart, "animationstart");

        // Clipboard events
        if (Copy is not null)
            RegisterEventListener(register, Copy, "copy");
        if (Cut is not null)
            RegisterEventListener(register, Cut, "cut");
        if (Paste is not null)
            RegisterEventListener(register, Paste, "paste");

        // Composition events
        if (CompositionEnd is not null)
            RegisterEventListener(register, CompositionEnd, "compositionend");
        if (CompositionStart is not null)
            RegisterEventListener(register, CompositionStart, "compositionstart");
        if (CompositionUpdate is not null)
            RegisterEventListener(register, CompositionUpdate, "compositionupdate");

        // Focus events
        if (Blur is not null)
            RegisterEventListener(register, Blur, "blur");
        if (Focus is not null)
            RegisterEventListener(register, Focus, "focus");
        if (FocusIn is not null)
            RegisterEventListener(register, FocusIn, "focusin");
        if (FocusOut is not null)
            RegisterEventListener(register, FocusOut, "focusout");

        // Fullscreen events
        if (FullscreenChange is not null)
            RegisterEventListener(register, FullscreenChange, "fullscreenchange");
        if (FullscreenError is not null)
            RegisterEventListener(register, FullscreenError, "fullscreenerror");

        // Keyboard events
        if (KeyDown is not null)
            RegisterEventListener(register, KeyDown, "keydown");
        if (KeyUp is not null)
            RegisterEventListener(register, KeyUp, "keyup");

        // Mouse events
        if (AuxClick is not null)
            RegisterEventListener(register, AuxClick, "auxclick");
        if (Click is not null)
            RegisterEventListener(register, Click, "click");
        if (ContextMenu is not null)
            RegisterEventListener(register, ContextMenu, "contextmenu");
        if (DblClick is not null)
            RegisterEventListener(register, DblClick, "dblclick");
        if (MouseDown is not null)
            RegisterEventListener(register, MouseDown, "mousedown");
        if (MouseEnter is not null)
            RegisterEventListener(register, MouseEnter, "mouseenter");
        if (MouseLeave is not null)
            RegisterEventListener(register, MouseLeave, "mouseleave");
        if (MouseMove is not null)
            RegisterEventListener(register, MouseMove, "mousemove");
        if (MouseOut is not null)
            RegisterEventListener(register, MouseOut, "mouseout");
        if (MouseOver is not null)
            RegisterEventListener(register, MouseOver, "mouseover");
        if (MouseUp is not null)
            RegisterEventListener(register, MouseUp, "mouseup");

        // Pointer events
        if (GotPointerCapture is not null)
            RegisterEventListener(register, GotPointerCapture, "gotpointercapture");
        if (LostPointerCapture is not null)
            RegisterEventListener(register, LostPointerCapture, "lostpointercapture");
        if (PointerCancel is not null)
            RegisterEventListener(register, PointerCancel, "pointercancel");
        if (PointerDown is not null)
            RegisterEventListener(register, PointerDown, "pointerdown");
        if (PointerEnter is not null)
            RegisterEventListener(register, PointerEnter, "pointerenter");
        if (PointerLeave is not null)
            RegisterEventListener(register, PointerLeave, "pointerleave");
        if (PointerMove is not null)
            RegisterEventListener(register, PointerMove, "pointermove");
        if (PointerOut is not null)
            RegisterEventListener(register, PointerOut, "pointerout");
        if (PointerOver is not null)
            RegisterEventListener(register, PointerOver, "pointerover");
        if (PointerRawUpdate is not null)
            RegisterEventListener(register, PointerRawUpdate, "pointerrawupdate");
        if (PointerUp is not null)
            RegisterEventListener(register, PointerUp, "pointerup");

        // Scroll events
        if (Scroll is not null)
            RegisterEventListener(register, Scroll, "scroll");
        if (ScrollEnd is not null)
            RegisterEventListener(register, ScrollEnd, "scrollend");
        if (ScrollSnapChange is not null)
            RegisterEventListener(register, ScrollSnapChange, "scrollsnapchange");
        if (ScrollSnapChanging is not null)
            RegisterEventListener(register, ScrollSnapChanging, "scrollsnapchanging");

        // Touch events
        if (TouchCancel is not null)
            RegisterEventListener(register, TouchCancel, "touchcancel");
        if (TouchEnd is not null)
            RegisterEventListener(register, TouchEnd, "touchend");
        if (TouchMove is not null)
            RegisterEventListener(register, TouchMove, "touchmove");
        if (TouchStart is not null)
            RegisterEventListener(register, TouchStart, "touchstart");

        // Transition events
        if (TransitionCancel is not null)
            RegisterEventListener(register, TransitionCancel, "transitioncancel");
        if (TransitionEnd is not null)
            RegisterEventListener(register, TransitionEnd, "transitionend");
        if (TransitionRun is not null)
            RegisterEventListener(register, TransitionRun, "transitionrun");
        if (TransitionStart is not null)
            RegisterEventListener(register, TransitionStart, "transitionstart");

        // Other events
        if (BeforeInput is not null)
            RegisterEventListener(register, BeforeInput, "beforeinput");
        if (BeforeMatch is not null)
            RegisterEventListener(register, BeforeMatch, "beforematch");
        if (BeforeXrSelect is not null)
            RegisterEventListener(register, BeforeXrSelect, "beforexrselect");
        if (ContentVisibilityAutoStateChange is not null)
            RegisterEventListener(register, ContentVisibilityAutoStateChange, "contentvisibilityautostatechange");
        if (Input is not null)
            RegisterEventListener(register, Input, "input");
        if (SecurityPolicyViolation is not null)
            RegisterEventListener(register, SecurityPolicyViolation, "securitypolicyviolation");
        if (Wheel is not null)
            RegisterEventListener(register, Wheel, "wheel");
    }
}