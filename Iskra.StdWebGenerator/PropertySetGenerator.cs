using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public static class PropertySetGenerator
{
    public static string Execute(
        MyType type,
        string objVar,
        string inputVar,
        string propertyName,
        GeneratorContext context
    )
    {
        var notNullableType = type with { IsNullable = false };
        var setPropertyMethodRes = JSObjectSetPropertyGenerator.Execute(notNullableType);
        var notNullInputVar = type is { IsNullable: true, Type.IsValueType: true } ? $"{inputVar}.Value" : inputVar;

        var propVar = context.GetNextVariableName();

        var marshall = Marshallers.Instance
            .GetNext(notNullableType, setPropertyMethodRes.ReturnType)
            .Marshall(notNullableType, notNullInputVar, setPropertyMethodRes.ReturnType, propVar, context);

        if (type.IsNullable)
        {
            return $$"""
                     if ({{inputVar}} is null)
                     {
                         {{objVar}}.SetProperty("{{propertyName}}", null as JSObject);
                     }
                     else
                     {
                         {{TypeNameGenerator.Execute(setPropertyMethodRes.ReturnType)}} {{propVar}};
                         {{marshall}}
                         {{objVar}}.{{setPropertyMethodRes.Name}}("{{propertyName}}", {{propVar}});
                     }
                     """;
        }

        return $$"""
                 {{TypeNameGenerator.Execute(setPropertyMethodRes.ReturnType)}} {{propVar}};
                 {{marshall}}
                 {{objVar}}.{{setPropertyMethodRes.Name}}("{{propertyName}}", {{propVar}});
                 """;
    }
}