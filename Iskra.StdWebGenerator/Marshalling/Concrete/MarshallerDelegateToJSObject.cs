using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerDelegateToJSObject : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsSubclassOf(typeof(Delegate))
           && destination.Type == typeof(JSObjectFunction);

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        var delegateMapper = context.DelegateMappers.GetDelegateMapper(inputType, context);

        return $$"""
                 {{outputVar}} = {{delegateMapper.Name}}({{inputVar}});
                 """;
    }
}