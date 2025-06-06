using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Api;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator.Extensions;

public static class TypeExtensions
{
    public static bool IsStatic(this Type type)
        => type is { IsAbstract: true, IsSealed: true };

    public static bool IsJSObjectWrapper(this Type type)
    {
        return !type.IsSubclassOf(typeof(Delegate)) &&
               type.IsDefined(typeof(GenerateBindingsAttribute), false);
    }

    public static bool IsOneOf(this Type type)
    {
        return type.IsGenericType
               && type.GetGenericTypeDefinition() is { } def
               && (
                   def == typeof(OneOf<,>)
                   || def == typeof(OneOf<,,>)
                   || def == typeof(OneOf<,,,>)
                   || def == typeof(OneOf<,,,,>)
               );
    }

    public static bool IsIReadOnlyList(this Type type)
    {
        return type.IsGenericType
               && type.GetGenericTypeDefinition() is { } def
               && def == typeof(IReadOnlyList<>);
    }

    public static MethodInfo GetDelegateMethodInfo(this Type type)
    {
        var invokeMethod = type.GetMethod("Invoke");
        if (invokeMethod is null)
        {
            throw new Exception($"The type {type.FullName} is not a delegate");
        }

        return invokeMethod;
    }
}