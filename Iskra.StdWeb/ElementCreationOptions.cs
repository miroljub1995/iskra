using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb;

public class ElementCreationOptions : IJSObject
{
    private readonly JSObject _obj;

    private ElementCreationOptions()
    {
        _obj = JSObjectCreator.Create();
    }

    public JSObject JsObject => _obj;

    public string? Is
    {
        get => _obj.GetPropertyAsString("is");
        set => _obj.SetProperty("is", value);
    }
}