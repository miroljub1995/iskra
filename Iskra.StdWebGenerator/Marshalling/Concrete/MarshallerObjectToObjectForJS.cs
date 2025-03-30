namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerObjectToObjectForJS : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type == typeof(object)
           && destination.Type == typeof(ObjectForJS);

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        var oneOfVar = context.GetNextVariableName();
        var jsObjectWrapperVar = context.GetNextVariableName();

        return $$"""
                 if ({{inputVar}} is OneOf {{oneOfVar}})
                 {
                     {{outputVar}} = {{oneOfVar}}.Value;
                 }
                 else if ({{inputVar}} is JSObjectWrapper {{jsObjectWrapperVar}})
                 {
                     {{outputVar}} = {{jsObjectWrapperVar}}.JSObject;
                 }
                 else
                 {
                     {{outputVar}} = {{inputVar}};
                 }
                 """;
    }
}