using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public record MarshallerOutGeneratorRes(
    TypeWithNullabilityInfo InputType,
    string Output
);

public static class MarshallerOutGenerator
{
    public static MarshallerOutGeneratorRes Execute(TypeWithNullabilityInfo type, string inputVar)
    {
        var isMarshallingNeeded = type switch
        {
            _ when type.Type == typeof(bool) => false,
            _ when type.Type == typeof(bool?) => false,
            _ when type.Type == typeof(bool) => false,
            _ when type.Type == typeof(bool?) => false,
            _ when type.Type == typeof(int) => false,
            _ when type.Type == typeof(int?) => false,
            _ when type.Type == typeof(long) => false,
            _ when type.Type == typeof(long?) => false,
            _ when type.Type == typeof(double) => false,
            _ when type.Type == typeof(double?) => false,
            _ when type.Type == typeof(string) => false,
            _ when type.Type == typeof(JSObject) => false,
            _ => true,
        };

        if (!isMarshallingNeeded)
        {
            return new(InputType: type, Output: inputVar);
        }

        if (type.Type.IsJSObjectWrapper())
        {
            var nullableState = type.IsFromReadState ? type.NullabilityInfo.ReadState : type.NullabilityInfo.WriteState;
            var isNullable = nullableState == NullabilityState.Nullable;

            var output = isNullable
                ? $$"""
                    ({{inputVar}} is null ? null : WrapperFactory.GetWrapper<{{TypeNameGenerator.Execute(type.Type, null)}}>({{inputVar}}))
                    """
                : $"""
                   WrapperFactory.GetWrapper<{TypeNameGenerator.Execute(type.Type, null)}>({inputVar});
                   """;

            return new(
                InputType: type with { Type = typeof(JSObject) },
                Output: output
            );
        }

        throw new($"Type {type.Type} is not supported.");
    }
}