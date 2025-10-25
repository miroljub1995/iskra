using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore.Extensions;

namespace Iskra.JSCore.Generics;

public static partial class ArrayLikeMarshaller
{
    [JSImport("construct", "iskra")]
    private static partial JSObject ConstructArray(JSObject obj, string constructorName, int length);


    public static TElement[] ToManaged<TElement, TMarshaller>(JSObject input)
        where TMarshaller : IArrayLikeElementMarshaller<TElement>
    {
        var length = input.GetPropertyAsDoubleV2("length");
        var lengthInt = Convert.ToInt32(length);

        var res = new TElement[lengthInt];
        for (var i = 0; i < lengthInt; i++)
        {
            res[i] = TMarshaller.Get(input, i);
        }

        return res;
    }

    public static JSObject ToJS<TElement, TMarshaller>(TElement[] input)
        where TMarshaller : IArrayLikeElementMarshaller<TElement>
    {
        var res = ConstructArray(JSHost.GlobalThis, "Array", input.Length);

        for (var i = 0; i < input.Length; i++)
        {
            TMarshaller.Set(res, i, input[i]);
        }

        return res;
    }
}