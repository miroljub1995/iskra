using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ElementComponentEvents<TElement> : BaseDomComponentEvents<TElement>
    where TElement : Element
{
    // Animation events
    public Action<AnimationEvent>? OnAnimationCancel { get; init; }
    public Action<AnimationEvent>? OnAnimationEnd { get; init; }
    public Action<AnimationEvent>? OnAnimationIteration { get; init; }
    public Action<AnimationEvent>? OnAnimationStart { get; init; }

    // Clipboard events
    public Action<ClipboardEvent>? OnCopy { get; init; }
    public Action<ClipboardEvent>? OnCut { get; init; }
    public Action<ClipboardEvent>? OnPaste { get; init; }

    // Composition events
    public Action<CompositionEvent>? OnCompositionEnd { get; init; }
    public Action<CompositionEvent>? OnCompositionStart { get; init; }
    public Action<CompositionEvent>? OnCompositionUpdate { get; init; }

    // Focus events
    public Action<FocusEvent>? OnBlur { get; init; }
    public Action<FocusEvent>? OnFocus { get; init; }
    public Action<FocusEvent>? OnFocusIn { get; init; }
    public Action<FocusEvent>? OnFocusOut { get; init; }

    // Fullscreen events
    public Action<Event>? OnFullscreenChange { get; init; }
    public Action<Event>? OnFullscreenError { get; init; }

    // Keyboard events
    public Action<KeyboardEvent>? OnKeyDown { get; init; }
    public Action<KeyboardEvent>? OnKeyUp { get; init; }

    // Mouse events
    public Action<PointerEvent>? OnAuxClick { get; init; }
    public Action<PointerEvent>? OnClick { get; init; }
    public Action<MouseEvent>? OnContextMenu { get; init; }
    public Action<MouseEvent>? OnDblClick { get; init; }
    public Action<MouseEvent>? OnMouseDown { get; init; }
    public Action<MouseEvent>? OnMouseEnter { get; init; }
    public Action<MouseEvent>? OnMouseLeave { get; init; }
    public Action<MouseEvent>? OnMouseMove { get; init; }
    public Action<MouseEvent>? OnMouseOut { get; init; }
    public Action<MouseEvent>? OnMouseOver { get; init; }
    public Action<MouseEvent>? OnMouseUp { get; init; }

    // Pointer events
    public Action<PointerEvent>? OnGotPointerCapture { get; init; }
    public Action<PointerEvent>? OnLostPointerCapture { get; init; }
    public Action<PointerEvent>? OnPointerCancel { get; init; }
    public Action<PointerEvent>? OnPointerDown { get; init; }
    public Action<PointerEvent>? OnPointerEnter { get; init; }
    public Action<PointerEvent>? OnPointerLeave { get; init; }
    public Action<PointerEvent>? OnPointerMove { get; init; }
    public Action<PointerEvent>? OnPointerOut { get; init; }
    public Action<PointerEvent>? OnPointerOver { get; init; }
    public Action<PointerEvent>? OnPointerRawUpdate { get; init; }
    public Action<PointerEvent>? OnPointerUp { get; init; }

    // Scroll events
    public Action<Event>? OnScroll { get; init; }
    public Action<Event>? OnScrollEnd { get; init; }
    public Action<SnapEvent>? OnScrollSnapChange { get; init; }
    public Action<SnapEvent>? OnScrollSnapChanging { get; init; }

    // Touch events
    public Action<TouchEvent>? OnTouchCancel { get; init; }
    public Action<TouchEvent>? OnTouchEnd { get; init; }
    public Action<TouchEvent>? OnTouchMove { get; init; }
    public Action<TouchEvent>? OnTouchStart { get; init; }

    // Transition events
    public Action<TransitionEvent>? OnTransitionCancel { get; init; }
    public Action<TransitionEvent>? OnTransitionEnd { get; init; }
    public Action<TransitionEvent>? OnTransitionRun { get; init; }
    public Action<TransitionEvent>? OnTransitionStart { get; init; }

    // Other events
    public Action<InputEvent>? OnBeforeInput { get; init; }
    public Action<Event>? OnBeforeMatch { get; init; }
    public Action<Event>? OnBeforeXrSelect { get; init; }
    public Action<ContentVisibilityAutoStateChangeEvent>? OnContentVisibilityAutoStateChange { get; init; }
    public Action<InputEvent>? OnInput { get; init; }
    public Action<SecurityPolicyViolationEvent>? OnSecurityPolicyViolation { get; init; }
    public Action<WheelEvent>? OnWheel { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Func<TElement, Action>> register)
    {
        base.RegisterClientEffects(register);

        // Animation events
        if (OnAnimationCancel is not null)
            RegisterEventListener(register, OnAnimationCancel, "animationcancel");
        if (OnAnimationEnd is not null)
            RegisterEventListener(register, OnAnimationEnd, "animationend");
        if (OnAnimationIteration is not null)
            RegisterEventListener(register, OnAnimationIteration, "animationiteration");
        if (OnAnimationStart is not null)
            RegisterEventListener(register, OnAnimationStart, "animationstart");

        // Clipboard events
        if (OnCopy is not null)
            RegisterEventListener(register, OnCopy, "copy");
        if (OnCut is not null)
            RegisterEventListener(register, OnCut, "cut");
        if (OnPaste is not null)
            RegisterEventListener(register, OnPaste, "paste");

        // Composition events
        if (OnCompositionEnd is not null)
            RegisterEventListener(register, OnCompositionEnd, "compositionend");
        if (OnCompositionStart is not null)
            RegisterEventListener(register, OnCompositionStart, "compositionstart");
        if (OnCompositionUpdate is not null)
            RegisterEventListener(register, OnCompositionUpdate, "compositionupdate");

        // Focus events
        if (OnBlur is not null)
            RegisterEventListener(register, OnBlur, "blur");
        if (OnFocus is not null)
            RegisterEventListener(register, OnFocus, "focus");
        if (OnFocusIn is not null)
            RegisterEventListener(register, OnFocusIn, "focusin");
        if (OnFocusOut is not null)
            RegisterEventListener(register, OnFocusOut, "focusout");

        // Fullscreen events
        if (OnFullscreenChange is not null)
            RegisterEventListener(register, OnFullscreenChange, "fullscreenchange");
        if (OnFullscreenError is not null)
            RegisterEventListener(register, OnFullscreenError, "fullscreenerror");

        // Keyboard events
        if (OnKeyDown is not null)
            RegisterEventListener(register, OnKeyDown, "keydown");
        if (OnKeyUp is not null)
            RegisterEventListener(register, OnKeyUp, "keyup");

        // Mouse events
        if (OnAuxClick is not null)
            RegisterEventListener(register, OnAuxClick, "auxclick");
        if (OnClick is not null)
            RegisterEventListener(register, OnClick, "click");
        if (OnContextMenu is not null)
            RegisterEventListener(register, OnContextMenu, "contextmenu");
        if (OnDblClick is not null)
            RegisterEventListener(register, OnDblClick, "dblclick");
        if (OnMouseDown is not null)
            RegisterEventListener(register, OnMouseDown, "mousedown");
        if (OnMouseEnter is not null)
            RegisterEventListener(register, OnMouseEnter, "mouseenter");
        if (OnMouseLeave is not null)
            RegisterEventListener(register, OnMouseLeave, "mouseleave");
        if (OnMouseMove is not null)
            RegisterEventListener(register, OnMouseMove, "mousemove");
        if (OnMouseOut is not null)
            RegisterEventListener(register, OnMouseOut, "mouseout");
        if (OnMouseOver is not null)
            RegisterEventListener(register, OnMouseOver, "mouseover");
        if (OnMouseUp is not null)
            RegisterEventListener(register, OnMouseUp, "mouseup");

        // Pointer events
        if (OnGotPointerCapture is not null)
            RegisterEventListener(register, OnGotPointerCapture, "gotpointercapture");
        if (OnLostPointerCapture is not null)
            RegisterEventListener(register, OnLostPointerCapture, "lostpointercapture");
        if (OnPointerCancel is not null)
            RegisterEventListener(register, OnPointerCancel, "pointercancel");
        if (OnPointerDown is not null)
            RegisterEventListener(register, OnPointerDown, "pointerdown");
        if (OnPointerEnter is not null)
            RegisterEventListener(register, OnPointerEnter, "pointerenter");
        if (OnPointerLeave is not null)
            RegisterEventListener(register, OnPointerLeave, "pointerleave");
        if (OnPointerMove is not null)
            RegisterEventListener(register, OnPointerMove, "pointermove");
        if (OnPointerOut is not null)
            RegisterEventListener(register, OnPointerOut, "pointerout");
        if (OnPointerOver is not null)
            RegisterEventListener(register, OnPointerOver, "pointerover");
        if (OnPointerRawUpdate is not null)
            RegisterEventListener(register, OnPointerRawUpdate, "pointerrawupdate");
        if (OnPointerUp is not null)
            RegisterEventListener(register, OnPointerUp, "pointerup");

        // Scroll events
        if (OnScroll is not null)
            RegisterEventListener(register, OnScroll, "scroll");
        if (OnScrollEnd is not null)
            RegisterEventListener(register, OnScrollEnd, "scrollend");
        if (OnScrollSnapChange is not null)
            RegisterEventListener(register, OnScrollSnapChange, "scrollsnapchange");
        if (OnScrollSnapChanging is not null)
            RegisterEventListener(register, OnScrollSnapChanging, "scrollsnapchanging");

        // Touch events
        if (OnTouchCancel is not null)
            RegisterEventListener(register, OnTouchCancel, "touchcancel");
        if (OnTouchEnd is not null)
            RegisterEventListener(register, OnTouchEnd, "touchend");
        if (OnTouchMove is not null)
            RegisterEventListener(register, OnTouchMove, "touchmove");
        if (OnTouchStart is not null)
            RegisterEventListener(register, OnTouchStart, "touchstart");

        // Transition events
        if (OnTransitionCancel is not null)
            RegisterEventListener(register, OnTransitionCancel, "transitioncancel");
        if (OnTransitionEnd is not null)
            RegisterEventListener(register, OnTransitionEnd, "transitionend");
        if (OnTransitionRun is not null)
            RegisterEventListener(register, OnTransitionRun, "transitionrun");
        if (OnTransitionStart is not null)
            RegisterEventListener(register, OnTransitionStart, "transitionstart");

        // Other events
        if (OnBeforeInput is not null)
            RegisterEventListener(register, OnBeforeInput, "beforeinput");
        if (OnBeforeMatch is not null)
            RegisterEventListener(register, OnBeforeMatch, "beforematch");
        if (OnBeforeXrSelect is not null)
            RegisterEventListener(register, OnBeforeXrSelect, "beforexrselect");
        if (OnContentVisibilityAutoStateChange is not null)
            RegisterEventListener(register, OnContentVisibilityAutoStateChange, "contentvisibilityautostatechange");
        if (OnInput is not null)
            RegisterEventListener(register, OnInput, "input");
        if (OnSecurityPolicyViolation is not null)
            RegisterEventListener(register, OnSecurityPolicyViolation, "securitypolicyviolation");
        if (OnWheel is not null)
            RegisterEventListener(register, OnWheel, "wheel");
    }
}