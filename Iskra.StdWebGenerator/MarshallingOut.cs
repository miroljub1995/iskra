using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public record MarshallingOutRes(
    TypeWithNullabilityInfo FromType,
    string? Output,
    string OutputVar
);

public static class MarshallingOut
{
    public static MarshallingOutRes Execute(TypeWithNullabilityInfo type, string inputVar, GeneratorContext context)
    {
        var nullabilityState = type.IsFromReadState ? type.NullabilityInfo.ReadState : type.NullabilityInfo.WriteState;
        var isNullable = nullabilityState == NullabilityState.Nullable;

        var isNeeded = type switch
        {
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
            _ when type.Type.IsOneOf() => false,
            _ => true,
        };

        if (!isNeeded)
        {
            return new(
                FromType: type,
                Output: null,
                OutputVar: inputVar
            );
        }

        if (type.Type.IsArray && type.Type.GetElementType() is { } elementType && type.NullabilityInfo.ElementType is
                { } elementNullabilityInfo)
        {
            // var resVar = context.GetNextVariableName();

            // var elementMarshallingRes = Execute(
            //     new(
            //         Type: elementType,
            //         NullabilityInfo: elementNullabilityInfo,
            //         true
            //     ),
            //     inputVar,
            //     context
            // );

            return new(
                FromType: type with { Type = typeof(JSObject) },
                Output: null,
                OutputVar: inputVar
            );
        }

        if (type.Type.IsJSObjectWrapper())
        {
            var resVar = context.GetNextVariableName();

            if (isNullable)
            {
                var output = $$"""
                               {{TypeNameGenerator.Execute(type.Type, type.NullabilityInfo, type.IsFromReadState)}} {{resVar}};
                               if({{inputVar}} is null)
                               {
                                   {{resVar}} = null;
                               }
                               else
                               {
                                   {{resVar}} = WrapperFactory.GetWrapper<{{TypeNameGenerator.Execute(type.Type, null)}}>({{inputVar}});
                               }
                               """;

                return new(
                    FromType: type with { Type = typeof(JSObject) },
                    Output: output,
                    OutputVar: resVar
                );
            }
            else
            {
                var typeName = TypeNameGenerator.Execute(type.Type, type.NullabilityInfo, type.IsFromReadState);
                var output = $"{typeName} {resVar} = WrapperFactory.GetWrapper<{typeName}>({inputVar});";

                return new(
                    FromType: type with { Type = typeof(JSObject) },
                    Output: output,
                    OutputVar: resVar
                );
            }
        }

        throw new($"Type {type.Type} is not supported.");
    }
}