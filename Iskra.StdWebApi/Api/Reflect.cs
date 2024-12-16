using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public static class Reflect
{
    [ManualBinding]
    public static void Apply(JSObject target, JSObject? thisArgument, object?[] argumentList) => throw new();

    [ManualBinding]
    public static object Apply<TRes>(JSObject target, JSObject? thisArgument, object?[] argumentList) => throw new();

    [ManualBinding]
    public static JSObject Construct(JSObject constructor, object?[] args) => throw new();

    [ManualBinding]
    public static JSObject Construct(JSObject constructor, object?[] args, JSObject newTarget) => throw new();
}