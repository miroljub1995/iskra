using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class GlobalHtmlComponentProps<TElement> : BaseDomComponentProps<TElement>
    where TElement : HTMLElement
{
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

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (AccessKey != null)
        {
            register(el => el.SetAttribute("accesskey", AccessKey.Value));
        }

        if (Autocapitalize != null)
        {
            register(el => el.SetAttribute("autocapitalize", Autocapitalize.Value));
        }

        if (Autocorrect != null)
        {
            register(el => SsrAttributes.SetEnumeratedBoolean(el, "autocorrect", Autocorrect.Value, "on", "off"));
        }

        if (Autofocus != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "autofocus", Autofocus.Value));
        }

        if (Class != null)
        {
            register(el => el.SetAttribute("class", Class.Value));
        }

        if (ContentEditable != null)
        {
            register(el => el.SetAttribute("contenteditable", ContentEditable.Value));
        }

        if (Data != null)
        {
            var previousAttrNames = new HashSet<string>();
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

                foreach (var attr in previousAttrNames)
                {
                    if (!nextAttrNames.Contains(attr))
                        el.RemoveAttribute(attr);
                }

                previousAttrNames.Clear();
                foreach (var attr in nextAttrNames)
                {
                    previousAttrNames.Add(attr);
                }
            });
        }

        if (Dir != null)
        {
            register(el => el.SetAttribute("dir", Dir.Value));
        }

        if (Draggable != null)
        {
            register(el => SsrAttributes.SetEnumeratedBoolean(el, "draggable", Draggable.Value));
        }

        if (EnterKeyHint != null)
        {
            register(el => el.SetAttribute("enterkeyhint", EnterKeyHint.Value));
        }

        if (Hidden != null)
        {
            register(el =>
            {
                switch (Hidden.Value)
                {
                    case HiddenOption.True:
                        el.SetAttribute("hidden", null);
                        break;
                    case HiddenOption.False:
                        el.RemoveAttribute("hidden");
                        break;
                    case HiddenOption.UntilFound:
                        el.SetAttribute("hidden", "until-found");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Hidden), Hidden.Value, null);
                }
            });
        }

        if (Id != null)
        {
            register(el => el.SetAttribute("id", Id.Value));
        }

        if (Inert != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "inert", Inert.Value));
        }

        if (InputMode != null)
        {
            register(el => el.SetAttribute("inputmode", InputMode.Value));
        }

        if (Lang != null)
        {
            register(el => el.SetAttribute("lang", Lang.Value));
        }

        if (Nonce != null)
        {
            register(el => el.SetAttribute("nonce", Nonce.Value));
        }

        if (Part != null)
        {
            register(el => el.SetAttribute("part", Part.Value));
        }

        if (Popover != null)
        {
            register(el => SsrAttributes.SetNullableString(el, "popover", Popover.Value));
        }

        if (Role != null)
        {
            register(el => SsrAttributes.SetNullableString(el, "role", Role.Value));
        }

        if (Slot != null)
        {
            register(el => el.SetAttribute("slot", Slot.Value));
        }

        if (Spellcheck != null)
        {
            register(el => SsrAttributes.SetEnumeratedBoolean(el, "spellcheck", Spellcheck.Value));
        }

        if (Style != null)
        {
            register(el => el.SetAttribute("style", Style.Value));
        }

        if (TabIndex != null)
        {
            register(el => SsrAttributes.SetInt(el, "tabindex", TabIndex.Value));
        }

        if (Title != null)
        {
            register(el => el.SetAttribute("title", Title.Value));
        }

        if (Translate != null)
        {
            register(el => SsrAttributes.SetEnumeratedBoolean(el, "translate", Translate.Value, "yes", "no"));
        }

        if (VirtualKeyboardPolicy != null)
        {
            register(el => el.SetAttribute("virtualkeyboardpolicy", VirtualKeyboardPolicy.Value));
        }

        if (WritingSuggestions != null)
        {
            register(el => el.SetAttribute("writingsuggestions", WritingSuggestions.Value));
        }
    }
}