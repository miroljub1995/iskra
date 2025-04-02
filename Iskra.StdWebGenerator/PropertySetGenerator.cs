using Iskra.StdWebGenerator.GeneratorContexts;
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
        var setPropertyMethodRes = JSObjectSetPropertyGenerator.Execute(type);

        var propVar = context.GetNextVariableName();

        var marshall = Marshallers.Instance
            .GetNext(type, setPropertyMethodRes.InputType)
            .Marshall(type, inputVar, setPropertyMethodRes.InputType, propVar, context);

        return $$"""
                 {{TypeNameGenerator.Execute(setPropertyMethodRes.InputType)}} {{propVar}};
                 {{marshall}}
                 {{objVar}}.{{setPropertyMethodRes.Name}}("{{propertyName}}", {{propVar}});
                 """;
    }
}