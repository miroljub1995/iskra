// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSMathValue: global::Iskra.StdWeb.CSSNumericValue
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSMathValue(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSMathOperator Operator
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSMathOperator, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "operator");
    }
}

#nullable disable