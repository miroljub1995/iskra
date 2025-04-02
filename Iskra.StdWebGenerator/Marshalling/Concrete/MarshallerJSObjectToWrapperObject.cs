using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerJSObjectToWrapperObject : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type == typeof(JSObject)
           && destination.Type.IsJSObjectWrapper();

    public override string Marshall(
        MyType inputType,
        string inputVar,
        MyType outputType,
        string outputVar,
        GeneratorContext.GeneratorContext context
    )
    {
        EnsureCanMarshall(inputType, outputType);

        return $$"""
                 {{outputVar}} = WrapperFactory.GetWrapper<{{TypeNameGenerator.Execute(outputType)}}>({{inputVar}});
                 """;
    }
}