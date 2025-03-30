using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class Element : Node
{
    protected Element() => throw new();

    public HTMLSlotElement AssignedSlot
    {
        get => throw new();
    }

    public NamedNodeMap Attributes
    {
        get => throw new();
    }

    public int ChildElementCount
    {
        get => throw new();
    }

    public HTMLCollection Children
    {
        get => throw new();
    }

    public DOMTokenList ClassList
    {
        get => throw new();
    }

    public string ClassName
    {
        get => throw new();
        set => throw new();
    }

    public int ClientHeight
    {
        get => throw new();
    }

    public int ClientLeft
    {
        get => throw new();
    }

    public int ClientTop
    {
        get => throw new();
    }

    public int ClientWidth
    {
        get => throw new();
    }

    public double CurrentCSSZoom
    {
        get => throw new();
    }

    // public string ElementTiming
    // {
    //     get => throw new();
    // }

    public Element? FirstElementChild
    {
        get => throw new();
    }

    public string Id
    {
        get => throw new();
        set => throw new();
    }

    public string InnerHTML
    {
        get => throw new();
        set => throw new();
    }

    public Element? LastElementChild
    {
        get => throw new();
    }

    public string LocalName
    {
        get => throw new();
    }

    public string? NamespaceURI
    {
        get => throw new();
    }

    public Element? NextElementSibling
    {
        get => throw new();
    }

    public string OuterHTML
    {
        get => throw new();
        set => throw new();
    }

    public DOMTokenList Part
    {
        get => throw new();
        set => throw new();
    }

    public string? Prefix
    {
        get => throw new();
    }

    public Element? PreviousElementSibling
    {
        get => throw new();
    }

    public double ScrollHeight
    {
        get => throw new();
    }

    public double ScrollLeft
    {
        get => throw new();
        set => throw new();
    }

    public double ScrollTop
    {
        get => throw new();
        set => throw new();
    }

    public double ScrollWidth
    {
        get => throw new();
    }

    public ShadowRoot? ShadowRoot
    {
        get => throw new();
    }

    public string Slot
    {
        get => throw new();
        set => throw new();
    }

    public string TagName
    {
        get => throw new();
    }

    public string AreaAtomic
    {
        get => throw new();
        set => throw new();
    }

    public string AreaAutoComplete
    {
        get => throw new();
        set => throw new();
    }

    public string AriaBrailleLabel
    {
        get => throw new();
        set => throw new();
    }

    public string AriaBrailleRoleDescription
    {
        get => throw new();
        set => throw new();
    }

    public string AriaBusy
    {
        get => throw new();
        set => throw new();
    }

    public string AriaChecked
    {
        get => throw new();
        set => throw new();
    }

    public string AriaColCount
    {
        get => throw new();
        set => throw new();
    }

    public string AriaColIndex
    {
        get => throw new();
        set => throw new();
    }

    public string AriaColIndexText
    {
        get => throw new();
        set => throw new();
    }

    public string AriaColSpan
    {
        get => throw new();
        set => throw new();
    }

    public string AriaCurrent
    {
        get => throw new();
        set => throw new();
    }

    public string AriaDescription
    {
        get => throw new();
        set => throw new();
    }

    public string AriaDisabled
    {
        get => throw new();
        set => throw new();
    }

    public string AriaExpanded
    {
        get => throw new();
        set => throw new();
    }

    public string AriaHasPopup
    {
        get => throw new();
        set => throw new();
    }

    public string AriaHidden
    {
        get => throw new();
        set => throw new();
    }

    public string AriaKeyShortcuts
    {
        get => throw new();
        set => throw new();
    }

    public string AriaLabel
    {
        get => throw new();
        set => throw new();
    }

    public string AriaLevel
    {
        get => throw new();
        set => throw new();
    }

    public string AriaLive
    {
        get => throw new();
        set => throw new();
    }

    public string AriaModal
    {
        get => throw new();
        set => throw new();
    }

    public string AriaMultiline
    {
        get => throw new();
        set => throw new();
    }

    public string AriaMultiSelectable
    {
        get => throw new();
        set => throw new();
    }

    public string AriaOrientation
    {
        get => throw new();
        set => throw new();
    }

    public string AriaPlaceholder
    {
        get => throw new();
        set => throw new();
    }

    public string AriaPosInSet
    {
        get => throw new();
        set => throw new();
    }

    public string AriaPressed
    {
        get => throw new();
        set => throw new();
    }

    public string AriaReadOnly
    {
        get => throw new();
        set => throw new();
    }

    public string AriaRequired
    {
        get => throw new();
        set => throw new();
    }

    public string AriaRoleDescription
    {
        get => throw new();
        set => throw new();
    }

    public string AriaRowCount
    {
        get => throw new();
        set => throw new();
    }

    public string AriaRowIndex
    {
        get => throw new();
        set => throw new();
    }

    public string AriaRowIndexText
    {
        get => throw new();
        set => throw new();
    }

    public string AriaRowSpan
    {
        get => throw new();
        set => throw new();
    }

    public string AriaSelected
    {
        get => throw new();
        set => throw new();
    }

    public string AriaSetSize
    {
        get => throw new();
        set => throw new();
    }

    public string AriaSort
    {
        get => throw new();
        set => throw new();
    }

    public string AriaValueMax
    {
        get => throw new();
        set => throw new();
    }

    public string AriaValueMin
    {
        get => throw new();
        set => throw new();
    }

    public string AriaValueNow
    {
        get => throw new();
        set => throw new();
    }

    public string AriaValueText
    {
        get => throw new();
        set => throw new();
    }

    public void After([AsParams] params OneOf<Node, string>[] nodes) => throw new();
    public void Animate(string el) => throw new();

    // public void Animate() => throw new();

    public void Append([AsParams] params OneOf<Node, string>[] nodes) => throw new();

    public ShadowRoot AttachShadow(ElementAttachShadowOptions options) => throw new();

    public void Before([AsParams] params OneOf<Node, string>[] nodes) => throw new();

    public bool CheckVisibility(ElementCheckVisibilityOptions? options) => throw new();

    public Element? Closest(string selectors) => throw new();

    public StylePropertyMapReadOnly ComputedStyleMap() => throw new();

    public IReadOnlyList<Animation> GetAnimations(ElementGetAnimationsOptions? options) => throw new();

    public string? GetAttribute(string attributeName) => throw new();

    public IReadOnlyList<string> GetAttributeNames() => throw new();

    public Attr GetAttributeNode(string attrName) => throw new();

    public Attr GetAttributeNodeNS(string namespaceValue, string nodeName) => throw new();

    public Attr GetAttributeNS(string namespaceValue, string name) => throw new();

    public DOMRect GetBoundingClientRect() => throw new();

    public DOMRectList GetClientRects() => throw new();

    public HTMLCollection GetElementsByClassName(string names) => throw new();

    public HTMLCollection GetElementsByTagName(string tagName) => throw new();

    public HTMLCollection GetElementsByTagNameNS(string namespaceURI, string localName) => throw new();

    public string GetHTML(ElementGetHTMLOptions? options) => throw new();

    public bool HasAttribute(string name) => throw new();

    public bool HasAttributeNS(string namespaceValue, string localName) => throw new();

    public bool HasAttributes() => throw new();

    public bool HasPointerCapture(int pointerId) => throw new();

    public Element? InsertAdjacentElement(string position, Element element) => throw new();

    public void InsertAdjacentHTML(string position, string text) => throw new();

    public void InsertAdjacentText(string where, string data) => throw new();

    public bool Matches(string selectors) => throw new();

    public void Prepend([AsParams] params OneOf<Node, string>[] nodes) => throw new();

    public Element? QuerySelector(string selectors) => throw new();

    public NodeList QuerySelectorAll(string selectors) => throw new();

    public void ReleasePointerCapture(int pointerId) => throw new();

    public void Remove() => throw new();

    public void RemoveAttribute(string attrName) => throw new();

    public Attr RemoveAttributeNode(Attr attributeNode) => throw new();

    public void RemoveAttributeNS(string namespaceValue, string attrName) => throw new();

    public void ReplaceChildren([AsParams] params OneOf<Node, string>[] nodes) => throw new();

    public void ReplaceWith([AsParams] params OneOf<Node, string>[] nodes) => throw new();

    public Task RequestFullscreen(ElementRequestFullscreenOptions? options) => throw new();

    // requestPointerLock

    public void Scroll(double xCoord, double yCoord) => throw new();

    public void Scroll(ElementScrollOptions? options) => throw new();

    public void ScrollBy(double xCoord, double yCoord) => throw new();

    public void ScrollBy(ElementScrollOptions? options) => throw new();

    public void ScrollIntoView(bool? alignToTop) => throw new();

    public void ScrollIntoView(ElementScrollIntoViewOptions? options) => throw new();

    public void ScrollTo(double xCoord, double yCoord) => throw new();

    public void ScrollTo(ElementScrollOptions? options) => throw new();

    public void SetAttribute(string name, string value) => throw new();

    public Attr? SetAttributeNode(Attr attribute) => throw new();

    public Attr? SetAttributeNodeNS(Attr attributeNode) => throw new();

    public void SetAttributeNS(string namespaceValue, string name, string value) => throw new();

    public void SetHTMLUnsafe(string html) => throw new();

    public void SetPointerCapture(int pointerId) => throw new();

    public bool ToggleAttribute(string name) => throw new();

    public bool ToggleAttribute(string name, bool force) => throw new();
}