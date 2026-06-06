using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class GlobalHtmlComponentProps<TElement> : BaseDomComponentProps<TElement>
    where TElement : HTMLElement
{
    private static readonly Func<object, SsrAttributeValue?> s_hiddenSelector =
        static obj => ((IReadOnlySignal<HiddenOption>)obj).Value switch
        {
            HiddenOption.True => new SsrAttributeValue(null),
            HiddenOption.False => null,
            HiddenOption.UntilFound => new SsrAttributeValue("until-found"),
            _ => throw new ArgumentOutOfRangeException(),
        };

    public IReadOnlySignal<string>? AccessKey { get; init; }
    public IReadOnlySignal<string>? Autocapitalize { get; init; }
    public IReadOnlySignal<bool>? Autocorrect { get; init; }
    public IReadOnlySignal<bool>? Autofocus { get; init; }
    public IReadOnlySignal<string>? Class { get; init; }
    public IReadOnlySignal<string>? ContentEditable { get; init; }
    public IReadOnlySignal<IDictionary<string, string>>? Data { get; init; }
    public IReadOnlySignal<string>? Dir { get; init; }
    public IReadOnlySignal<bool>? Draggable { get; init; }
    public IReadOnlySignal<string>? EnterKeyHint { get; init; }
    public IReadOnlySignal<HiddenOption>? Hidden { get; init; }
    public IReadOnlySignal<string>? Id { get; init; }
    public IReadOnlySignal<bool>? Inert { get; init; }
    public IReadOnlySignal<string>? InputMode { get; init; }
    public IReadOnlySignal<string>? Lang { get; init; }
    public IReadOnlySignal<string>? Nonce { get; init; }
    public IReadOnlySignal<string>? Part { get; init; }
    public IReadOnlySignal<string?>? Popover { get; init; }
    public IReadOnlySignal<string?>? Role { get; init; }
    public IReadOnlySignal<string>? Slot { get; init; }
    public IReadOnlySignal<bool>? Spellcheck { get; init; }
    public IReadOnlySignal<string>? Style { get; init; }
    public IReadOnlySignal<int>? TabIndex { get; init; }
    public IReadOnlySignal<string>? Title { get; init; }
    public IReadOnlySignal<bool>? Translate { get; init; }
    public IReadOnlySignal<string>? VirtualKeyboardPolicy { get; init; }
    public IReadOnlySignal<string>? WritingSuggestions { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<TElement>> register)
    {
        base.RegisterClientEffects(register);

        if (AccessKey != null)
        {
            register(el => el.AccessKey = AccessKey.Value);
        }

        if (Autocapitalize != null)
        {
            register(el => el.Autocapitalize = Autocapitalize.Value);
        }

        if (Autocorrect != null)
        {
            register(el => el.Autocorrect = Autocorrect.Value);
        }

        if (Autofocus != null)
        {
            register(el => el.Autofocus = Autofocus.Value);
        }

        if (Class != null)
        {
            register(el => el.ClassList.Value = Class.Value);
        }

        if (ContentEditable != null)
        {
            register(el => el.ContentEditable = ContentEditable.Value);
        }

        if (Data != null)
        {
            register(el =>
            {
                var dict = Data.Value;
                var nextAttrNames = new HashSet<string>(dict.Count);

                foreach (var kvp in dict)
                {
                    var attrName = "data-" + kvp.Key;
                    nextAttrNames.Add(attrName);
                    el.SetAttribute(attrName, kvp.Value);
                }

                var attrNames = (string[])el.GetAttributeNames();
                foreach (var attr in attrNames)
                {
                    if (attr.StartsWith("data-") && !nextAttrNames.Contains(attr))
                        el.RemoveAttribute(attr);
                }
            });
        }

        if (Dir != null)
        {
            register(el => el.Dir = Dir.Value);
        }

        if (Draggable != null)
        {
            register(el => el.Draggable = Draggable.Value);
        }

        if (EnterKeyHint != null)
        {
            register(el => el.EnterKeyHint = EnterKeyHint.Value);
        }

        if (Hidden != null)
        {
            register(el => el.Hidden = Hidden.Value switch
            {
                HiddenOption.True => true,
                HiddenOption.False => false,
                HiddenOption.UntilFound => "until-found",
                _ => throw new ArgumentOutOfRangeException(nameof(Hidden), Hidden.Value, null),
            });
        }

        if (Id != null)
        {
            register(el => el.Id = Id.Value);
        }

        if (Inert != null)
        {
            register(el => el.Inert = Inert.Value);
        }

        if (InputMode != null)
        {
            register(el => el.InputMode = InputMode.Value);
        }

        if (Lang != null)
        {
            register(el => el.Lang = Lang.Value);
        }

        if (Nonce != null)
        {
            register(el => el.Nonce = Nonce.Value);
        }

        if (Part != null)
        {
            register(el => el.Part.Value = Part.Value);
        }

        if (Popover != null)
        {
            register(el => el.Popover = Popover.Value);
        }

        if (Role != null)
        {
            register(el => el.Role = Role.Value);
        }

        if (Slot != null)
        {
            register(el => el.Slot = Slot.Value);
        }

        if (Spellcheck != null)
        {
            register(el => el.Spellcheck = Spellcheck.Value);
        }

        if (Style != null)
        {
            register(el => el.Style.CssText = Style.Value);
        }

        if (TabIndex != null)
        {
            register(el => el.TabIndex = TabIndex.Value);
        }

        if (Title != null)
        {
            register(el => el.Title = Title.Value);
        }

        if (Translate != null)
        {
            register(el => el.Translate = Translate.Value);
        }

        if (VirtualKeyboardPolicy != null)
        {
            register(el => el.VirtualKeyboardPolicy = VirtualKeyboardPolicy.Value);
        }

        if (WritingSuggestions != null)
        {
            register(el => el.WritingSuggestions = WritingSuggestions.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (AccessKey != null)
        {
            el.SetAttribute("accesskey", AccessKey);
        }

        if (Autocapitalize != null)
        {
            el.SetAttribute("autocapitalize", Autocapitalize);
        }

        if (Autocorrect != null)
        {
            el.SetEnumeratedBoolOnOff("autocorrect", Autocorrect);
        }

        if (Autofocus != null)
        {
            el.SetBoolean("autofocus", Autofocus);
        }

        if (Class != null)
        {
            el.SetAttribute("class", Class);
        }

        if (ContentEditable != null)
        {
            el.SetAttribute("contenteditable", ContentEditable);
        }

        if (Data != null)
        {
            el.SetDataAttributes(Data);
        }

        if (Dir != null)
        {
            el.SetAttribute("dir", Dir);
        }

        if (Draggable != null)
        {
            el.SetEnumeratedBoolTrueFalse("draggable", Draggable);
        }

        if (EnterKeyHint != null)
        {
            el.SetAttribute("enterkeyhint", EnterKeyHint);
        }

        if (Hidden != null)
        {
            el.SetAttribute("hidden", Hidden, s_hiddenSelector);
        }

        if (Id != null)
        {
            el.SetAttribute("id", Id);
        }

        if (Inert != null)
        {
            el.SetBoolean("inert", Inert);
        }

        if (InputMode != null)
        {
            el.SetAttribute("inputmode", InputMode);
        }

        if (Lang != null)
        {
            el.SetAttribute("lang", Lang);
        }

        if (Nonce != null)
        {
            el.SetAttribute("nonce", Nonce);
        }

        if (Part != null)
        {
            el.SetAttribute("part", Part);
        }

        if (Popover != null)
        {
            el.SetNullableString("popover", Popover);
        }

        if (Role != null)
        {
            el.SetNullableString("role", Role);
        }

        if (Slot != null)
        {
            el.SetAttribute("slot", Slot);
        }

        if (Spellcheck != null)
        {
            el.SetEnumeratedBoolTrueFalse("spellcheck", Spellcheck);
        }

        if (Style != null)
        {
            el.SetAttribute("style", Style);
        }

        if (TabIndex != null)
        {
            el.SetInt("tabindex", TabIndex);
        }

        if (Title != null)
        {
            el.SetAttribute("title", Title);
        }

        if (Translate != null)
        {
            el.SetEnumeratedBoolYesNo("translate", Translate);
        }

        if (VirtualKeyboardPolicy != null)
        {
            el.SetAttribute("virtualkeyboardpolicy", VirtualKeyboardPolicy);
        }

        if (WritingSuggestions != null)
        {
            el.SetAttribute("writingsuggestions", WritingSuggestions);
        }
    }
}