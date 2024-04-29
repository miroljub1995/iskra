using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb.Dom;

public class Document(JSObject obj) : Node(obj)
{
    public TElement CreateElement<TElement>(ElementCreationOptions? options = null)
        where TElement : Element
    {
        return (TElement)CreateElement(GetHtmlElementTagName<TElement>(), options);
    }

    public Element CreateElement(HtmlElementTagNames tagName, ElementCreationOptions? options = null)
    {
        Utils.JSFunction func = JSObject.GetPropertyAsJSFunction("createElement")
                                ?? throw new("Create element is null");

        JSObject element = func.Call<JSObject>(Enum.GetName(tagName), options?.JSObject);

        return From(element, tagName);
    }

    public Text CreateTextNode(string data)
    {
        JSFunction func = JSObject.GetPropertyAsJSFunction("createTextNode")
                          ?? throw new("createTextNode is not defined");

        JSObject jsObj = func.Call<JSObject>(data);
        return new(jsObj);
    }

    public Element? GetElementById(string elementId)
    {
        Utils.JSFunction func = JSObject.GetPropertyAsJSFunction("getElementById")
                                ?? throw new("getElementById not found");

        object? resObj = func.Call(elementId);

        if (resObj is null)
        {
            return null;
        }

        JSObject res = resObj as JSObject ?? throw new($"Res {resObj.GetType()} is not JSObject");

        string tagName = res.GetPropertyAsString("tagName")
                         ?? throw new("TagName doesn't exist.");

        if (!Enum.TryParse(tagName, out HtmlElementTagNames htmlTagName))
        {
            throw new($"Can not parse {tagName}.");
        }

        return From(res, htmlTagName);
    }

    public TElement? GetElementById<TElement>(string elementId)
        where TElement : Element
    {
        Element? element = GetElementById(elementId);
        if (element is null)
        {
            return null;
        }

        if (element is TElement tElement)
        {
            return tElement;
        }

        throw new($"Element of type {element.GetType()} is not {typeof(TElement)}");
    }

    private static HtmlElementTagNames GetHtmlElementTagName<TElement>()
        => typeof(TElement) switch
        {
            _ when typeof(TElement) == typeof(HtmlDivElement) => HtmlElementTagNames.DIV,
            _ when typeof(TElement) == typeof(HtmlInputElement) => HtmlElementTagNames.INPUT,
            _ => throw new Exception($"{typeof(TElement)} is not supported."),
        };

    private static Element From(JSObject obj, HtmlElementTagNames tagName)
        => tagName switch
        {
            HtmlElementTagNames.DIV => new HtmlDivElement(obj),
            HtmlElementTagNames.INPUT => new HtmlInputElement(obj),
            _ => throw new($"Tag name {tagName} not supported.")
        };
}