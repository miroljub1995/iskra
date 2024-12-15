using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public static class Reflect
{
    [ManualBinding]
    public static TRes Apply<TRes>(JSObject target, JSObject thisArgument, object?[] argumentList) => throw new();
}