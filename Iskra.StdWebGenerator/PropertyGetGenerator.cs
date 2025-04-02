using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public static class PropertyGetGenerator
{
    public static string Execute(
        MyType type,
        string objVar,
        string outputVar,
        string propertyName,
        GeneratorContext.GeneratorContext context
    )
    {
        var getPropertyMethodRes = JSObjectGetPropertyGenerator.Execute(type);

        var propVar = context.GetNextVariableName();

        var marshall = Marshallers.Instance
            .GetNext(getPropertyMethodRes.ReturnType, type)
            .Marshall(getPropertyMethodRes.ReturnType, propVar, type, outputVar, context);

        return $$"""
                 {{TypeNameGenerator.Execute(getPropertyMethodRes.ReturnType)}} {{propVar}} = {{objVar}}.{{getPropertyMethodRes.Name}}("{{propertyName}}");
                 {{marshall}}
                 """;
    }
}